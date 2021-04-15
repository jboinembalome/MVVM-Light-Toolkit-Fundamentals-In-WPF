using GalaSoft.MvvmLight.Threading;
using System.Windows;

namespace PlugInSample
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            DispatcherHelper.Initialize();
        }
    }
}
