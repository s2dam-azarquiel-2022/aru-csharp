using GestionPedidosARG_4.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GestionPedidosARG_4.ViewModel
{
    internal class EditOrRemoveOrderViewModel : INotifyPropertyChanged
    {
        private Connection connection;
        public EditOrRemoveOrderViewModel()
        {
            // Setup the event handler
            PropertyChanged += EventHandler;

            // Setup commands
            RemoveCommand = new Command(RemoveAction);
            UpdateCommand = new Command(UpdateAction);

            // Setup other stuff
            EmptyFields();
            connection = new Connection();
            orders = connection.Get();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName)
            );
        }

        private void EventHandler(object sender, PropertyChangedEventArgs args)
        {
            switch (args.PropertyName)
            {
            }
        }

        private String client;
        public String Client
        {
            get => client;
            set
            {
                client = value;
                OnPropertyChanged(nameof(Client));
            }
        }

        private String dni;
        public String DNI
        {
            get => dni;
            set
            {
                dni = value;
                OnPropertyChanged(nameof(DNI));
            }
        }

        private String number;
        public String Number
        {
            get => number;
            set
            {
                number = value;
                OnPropertyChanged(nameof(Number));
            }
        }

        private int quantity;
        public int Quantity
        {
            get => quantity;
            set
            {
                quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        private String date;
        public String Date
        {
            get => date;
            set
            {
                date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        private ObservableCollection<Order> orders;
        public ObservableCollection<Order> Orders
        {
            get => orders;
            set
            {
                orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        private void EmptyFields()
        {
            Client = "";
            DNI = "";
            Number = "";
            Quantity = 0;
            Date = "";
        }

        public ICommand RemoveCommand { get; set; }
        public ICommand UpdateCommand { get; set; }

        private void RemoveAction(object parameter)
        {
            EmptyFields();
            connection.Remove(Number);
        }
        private void UpdateAction(object parameter)
        {
            connection.Update(new Order()
            {
                Client = Client,
                DNI = DNI,
                Number = Number,
                Quantity = Quantity,
                Date = Date
            });
        }
    }
}
