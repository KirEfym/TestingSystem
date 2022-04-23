using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFTestingSystem.CommandFolder
{
   public class ScrollButtonCommand: ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        private Action execute;
        private Func<bool> canExecute;
        public ScrollButtonCommand(Action execute, Func<bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute();
        }

        public void Execute(object parameter)
        {
            this.execute();
        }
    }
}
