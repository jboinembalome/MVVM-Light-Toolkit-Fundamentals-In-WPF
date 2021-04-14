using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;

namespace EventToCommandSamples.Helpers
{
    public class MouseButtonEventArgsToPointConverter : IEventArgsConverter
    {
        public object Convert(object value, object parameter)
        {
            var args = (MouseButtonEventArgs)value;
            var element = (FrameworkElement)parameter;

            var point = args.GetPosition(element);
            return point;
        }
    }
}
