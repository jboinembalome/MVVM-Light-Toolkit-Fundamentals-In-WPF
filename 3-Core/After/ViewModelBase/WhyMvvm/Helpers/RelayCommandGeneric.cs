using System;
using System.Windows.Input;

namespace GalaSoft.MvvmLight.Command
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;

        private readonly Func<T, bool> _canExecute;

        public RelayCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            _execute = execute;

            if (canExecute != null)
            {
                _canExecute = canExecute;
            }
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }

            if (parameter == null
                && typeof(T).IsValueType)
            {
                return _canExecute(default(T));
            }

            return _canExecute((T) parameter);
        }

        public virtual void Execute(object parameter)
        {
            var val = parameter;

            if (parameter != null
                && parameter.GetType() != typeof(T))
            {
                if (parameter is IConvertible)
                {
                    val = Convert.ChangeType(parameter, typeof (T), null);
                }
            }

            if (CanExecute(val)
                && _execute != null)
            {
                if (val == null)
                {
                    if (typeof(T).IsValueType)
                    {
                        _execute(default(T));
                    }
                    else
                    {
                        _execute((T)val);
                    }
                }
                else
                {
                    _execute((T)val);
                }
            }
        }
    }
}