using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator.Commands
{
    public class DelegateCommand<T> : ICommand
    {
        #region Data
        private readonly Action<T> _executeMethod;
        private readonly Func<T, bool> _canExecuteMethod;
        #endregion

        #region Constructors
        public DelegateCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            if (executeMethod == null)
            {
                throw new NullReferenceException();
            }
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }
        #endregion

        #region Private Methods
        private bool CanExecute(T parameter)
        {
            return _canExecuteMethod == null || _canExecuteMethod(parameter);
        }

        private void Execute(T parameter)
        {
            _executeMethod?.Invoke(parameter);
        }
        #endregion

        #region ICommand Members
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            if (parameter == null && typeof(T).IsValueType)
            {
                return (_canExecuteMethod == null);
            }
            return (CanExecute((T)parameter));
        }

        public void Execute(object parameter)
        {
            Execute((T)parameter);
        }
        #endregion
    }
}
