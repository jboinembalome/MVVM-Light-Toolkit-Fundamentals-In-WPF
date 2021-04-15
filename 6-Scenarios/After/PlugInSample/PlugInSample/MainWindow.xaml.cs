using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using PlugInSample.Contracts;
using PlugInSample.Helpers;
using PlugInSample.ViewModel;
using System.Windows;

namespace PlugInSample
{
    public partial class MainWindow : IPlugInHost
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += (s, e) => SimpleIoc.Default.Register<IPlugInHost>(() => this);

            Closing += (s, e) =>
            {
                SimpleIoc.Default.Unregister<IPlugInHost>(this);
                ViewModelLocator.Cleanup();
            };
        }

        public void Clear()
        {
            Messenger.Default.Send(
                new NotificationMessage(Notifications.CleanupNotification));

            PlugInHost1.Child = null;
            PlugInHost2.Child = null;
        }

        public void PlacePlugIn(IPlugIn plugIn, object dataContext)
        {
            var bootstrapper = ServiceLocator.Current.GetInstance<Bootstrapper>();

            FrameworkElement element = null;

            try
            {
                element = bootstrapper.GetElement(plugIn);
            }
            catch
            {
                MessageBox.Show(
                    "Error when creating element for plugin " + plugIn.GetType());
            }

            if (element == null)
            {
                return;
            }

            element.DataContext = dataContext;

            if (PlugInHost1.Child == null)
            {
                PlugInHost1.Child = element;
                return;
            }

            if (PlugInHost2.Child == null)
            {
                PlugInHost2.Child = element;
                return;
            }

            MessageBox.Show("No more room");
        }
    }
}
