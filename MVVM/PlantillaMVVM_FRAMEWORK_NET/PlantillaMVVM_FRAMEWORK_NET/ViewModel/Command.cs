using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlantillaMVVM_FRAMEWORK_NET.ViewModel
{
    internal class Command : ICommand
    {
        readonly Action<object> action;
        public event EventHandler CanExecuteChanged;

        public Command(Action<object> action)
        {
            this.action = action;
        }

        public bool CanExecute(object param) => true;

        public void Execute(object param) => action(param);
    }
}
