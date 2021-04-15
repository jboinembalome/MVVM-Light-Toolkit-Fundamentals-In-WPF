
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using PlugInSample.Contracts;
using PlugInSample.Helpers;
using PlugInSample.Model;

namespace PlugInSample.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IDataService, DataService>();

            SimpleIoc.Default.Register<Bootstrapper>();
            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}