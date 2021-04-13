using GalaSoft.MvvmLight.Threading;
using System.Windows;

namespace DispatcherHelperSample
{
    public partial class App : Application
    {
        static App()
        {
            DispatcherHelper.Initialize();
        }
    }
}
