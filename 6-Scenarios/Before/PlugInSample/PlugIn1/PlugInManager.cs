using PlugInSample.Contracts;
using System.Windows;

namespace PlugIn1
{
    public class PlugInManager : IPlugIn
    {
        public string Name
        {
            get
            {
                return "Plug-in # 1";
            }
        }

        public FrameworkElement GetElement()
        {
            return new PlugInControl1();
        }
    }
}
