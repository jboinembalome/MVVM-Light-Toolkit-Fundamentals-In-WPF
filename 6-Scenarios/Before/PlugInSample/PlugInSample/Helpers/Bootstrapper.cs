using PlugInSample.Contracts;
using PlugInSample.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;

namespace PlugInSample.Helpers
{
    public class Bootstrapper
    {
        public IList<IPlugIn> PlugIns
        {
            get;
            private set;
        }

        public void Refresh()
        {
            PlugIns = new List<IPlugIn>();
            var projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            var folderPath = projectPath + (string)Settings.Default["PlugInFolderPath"];

            if (string.IsNullOrEmpty(folderPath))
            {
                throw new InvalidOperationException("PlugInFolderPath not found");
            }

            var folder = new DirectoryInfo(folderPath);

            if (!folder.Exists)
            {
                throw new InvalidOperationException(string.Format("Folder {0} does not exist", folderPath));
            }

            foreach (var file in folder.GetFiles("*.dll"))
            {
                var assembly = Assembly.LoadFrom(file.FullName);

                foreach (var type in assembly.GetTypes())
                {
                    if (typeof(IPlugIn).IsAssignableFrom(type)
                        && !type.IsInterface)
                    {
                        var constructor = type.GetConstructor(
                            new Type[]
                            {
                            });

                        if (constructor == null)
                        {
                            throw new InvalidOperationException("No default constructor for plug in manager found");
                        }

                        var manager = constructor.Invoke(
                            new object[]
                            {
                            });

                        PlugIns.Add((IPlugIn)manager);
                    }
                }
            }
        }

        public FrameworkElement GetElement(IPlugIn plugInManager)
        {
            var fullType = plugInManager.GetType();

            var method = fullType.GetMethod("GetElement");

            var element = method.Invoke(
                plugInManager,
                new object[]
                {
                });

            return element as FrameworkElement;
        }
    }
}
