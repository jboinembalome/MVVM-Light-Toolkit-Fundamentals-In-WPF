using PlugInSample.Contracts;
using System.Windows;

namespace PlugIn2
{
    public class PlugInManager : IPlugIn
    {
        public string Name
        {
            get
            {
                return "Plug-in # 2";
            }
        }

        public FrameworkElement GetElement()
        {
            return new AnotherPlugInControl();
        }
    }
}
