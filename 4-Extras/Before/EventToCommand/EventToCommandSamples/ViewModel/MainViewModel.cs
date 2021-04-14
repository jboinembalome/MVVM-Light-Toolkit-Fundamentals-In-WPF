using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;

namespace EventToCommandSamples.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private RelayCommand _sayHelloCommand;

        /// <summary>
        /// Gets the SayHelloCommand.
        /// </summary>
        public RelayCommand SayHelloCommand
        {
            get
            {
                return _sayHelloCommand
                    ?? (_sayHelloCommand = new RelayCommand(
                        () =>
                        {
                            MessageBox.Show("Hello");
                        }));
            }
        }

        private RelayCommand<Point> _showPointCommand;

        /// <summary>
        /// Gets the ShowPointCommand.
        /// </summary>
        public RelayCommand<Point> ShowPointCommand
        {
            get
            {
                return _showPointCommand
                    ?? (_showPointCommand = new RelayCommand<Point>(
                        point =>
                        {
                            var message = string.Format(
                                "{0} : {1}",
                                point.X,
                                point.Y);

                            MessageBox.Show(message);
                        }));
            }
        }
    }
}