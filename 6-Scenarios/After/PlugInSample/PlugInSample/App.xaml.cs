using GalaSoft.MvvmLight.Threading;
using System.Windows;

namespace PlugInSample
{
    public partial class App : Application
    {
        static App()
        {
            DispatcherHelper.Initialize();
        }
    }
}
