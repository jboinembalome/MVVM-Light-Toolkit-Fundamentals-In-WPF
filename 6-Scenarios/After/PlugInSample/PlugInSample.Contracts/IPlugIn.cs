using System.Windows;

namespace PlugInSample.Contracts
{
    public interface IPlugIn
    {
        string Name
        {
            get;
        }

        FrameworkElement GetElement();
    }
}
