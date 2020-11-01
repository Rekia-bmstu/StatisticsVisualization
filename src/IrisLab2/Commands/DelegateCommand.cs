using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IrisLab2.Commands
{
    internal class DelegateCommand : ICommand
    {
        private readonly Action<object> execute;

        private readonly Func<object, bool> canExecute;

        public DelegateCommand(Action<object> execute)
            : this(execute, o => true)
        {
        }

        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
