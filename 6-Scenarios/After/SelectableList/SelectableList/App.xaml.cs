using GalaSoft.MvvmLight.Threading;
using System.Windows;

namespace SelectableList
{
    public partial class App : Application
    {
        static App()
        {
            DispatcherHelper.Initialize();
        }
    }
}
