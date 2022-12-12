using GestionPedidosARG_4.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GestionPedidosARG_4.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            // Setup commands
            NewOrderCommand = new Command(NewOrderAction);
            EditOrRemoveOrderCommand = new Command(EditOrRemoveOrderAction);

            // Setup other stuff
            newOrderWindow = new NewOrderWindow();
            editOrRemoveOrderWindow = new EditOrRemoveOrderWindow();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName)
            );
        }

        public ICommand NewOrderCommand { get; set; }
        public ICommand EditOrRemoveOrderCommand { get; set; }

        private void NewOrderAction(object parameter)
        {
            newOrderWindow.Show();
        }

        private void EditOrRemoveOrderAction(object parameter)
        {
            editOrRemoveOrderWindow.Show();
        }

        private NewOrderWindow newOrderWindow;
        private EditOrRemoveOrderWindow editOrRemoveOrderWindow;
    }
}
