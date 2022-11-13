using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFLibretaDirecciones.ViewModel
{
    internal class Command : ICommand
    {
        readonly Action<Object> accionAEjecutar;
        
        public Command(Action<Object> execute, Predicate<object> callExecute)
        {
            accionAEjecutar = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            accionAEjecutar(parameter);
        }
    }
}
