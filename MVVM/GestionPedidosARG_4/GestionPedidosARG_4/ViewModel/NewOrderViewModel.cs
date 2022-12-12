using GestionPedidosARG_4.Model;
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
    internal class NewOrderViewModel : INotifyPropertyChanged
    {

        private Connection connection;
        public NewOrderViewModel()
        {
            // Setup the event handler
            PropertyChanged += EventHandler;

            // Setup commands
            NewOrderCommand = new Command(NewOrderAction);
            SaveCommand = new Command(SaveAction);

            // Setup other stuff
            EmptyFields();
            connection = new Connection();
            NewBtnEnabled = true;
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

        private void EmptyFields()
        {
            Client = "";
            DNI = "";
            Number = "";
            Quantity = 0;
            Date = "";
        }

        public ICommand NewOrderCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        private void NewOrderAction(object parameter)
        {
            EmptyFields();
        }
        private void SaveAction(object parameter)
        {
            connection.Add(new Order()
            {
                Client = Client,
                DNI = DNI,
                Number = Number,
                Quantity = Quantity,
                Date = Date
            });
        }

        private Boolean newBtnEnabled;
        public Boolean NewBtnEnabled
        {
            get => newBtnEnabled;
            set
            {
                newBtnEnabled = value;
                OnPropertyChanged(nameof(newBtnEnabled));
            }
        }

        private Boolean saveBtnEnabled;
        public Boolean SaveBtnEnabled
        {
            get => saveBtnEnabled;
            set
            {
                saveBtnEnabled = value;
                OnPropertyChanged(nameof(SaveBtnEnabled));
            }
        }
    }
}
