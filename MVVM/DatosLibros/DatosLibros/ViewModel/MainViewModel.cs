using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DatosLibros.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private OleDbConnection Connection;
        private OleDbDataAdapter Adapter;
        private DataSet DataSet;
        private OleDbCommandBuilder CommandBuilder;


        public event PropertyChangedEventHandler PropertyChanged;

        /*
        private ObservableCollection<Contact> contactList = default!;
        private Contact? selectedContact;
        */

        public ICommand FirstPageCommand { get; set; }
        public ICommand NextPageCommand { get; set; }
        public ICommand PreviousPageCommand { get; set; }
        public ICommand LastPageCommand { get; set; }
        public ICommand NewBookCommand { get; set; }
        public ICommand InsertBookCommand { get; set; }
        public ICommand EditBookCommand { get; set; }
        public ICommand DeleteBookCommand { get; set; }
        public ICommand RefreshCommand { get; set; } 

        public MainViewModel()
        {
            Connection = new OleDbConnection
            {
                ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\\Users\\Tu madre\\Downloads\\Librerias.accdb'"
            };
            Adapter = new OleDbDataAdapter("SELECT * FROM libros", Connection);
            CommandBuilder = new OleDbCommandBuilder();
            DataSet = new DataSet();

            Connection.Open();
            Adapter.Fill(DataSet, "libros");
            Connection.Close();

            /*
            ContactList = new ObservableCollection<Contact>(DataHandler.ReadAll());
            NewContactCommand = new Command(NewContactAction);
            RemoveContactCommand = new Command(RemoveContactAction);
            SaveAllCommand = new Command(SaveAllAction);
            */

            FirstPageCommand = new Command(FirstPageAction);
            NextPageCommand = new Command(NextPageAction);
            PreviousPageCommand = new Command(PreviousPageAction);
            LastPageCommand = new Command(LastPageAction);
            NewBookCommand = new Command(NewBookAction);
            InsertBookCommand = new Command(InsertBookAction);
            EditBookCommand = new Command(EditBookAction);
            DeleteBookCommand = new Command(DeleteBookAction);
            RefreshCommand = new Command(RefreshCAction);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName)
            );
        }

        private void FirstPageAction(object parameter)
        {
        }
        private void NextPageAction(object parameter)
        {
        }
        private void PreviousPageAction(object parameter)
        {
        }
        private void LastPageAction(object parameter)
        {
        }
        private void NewBookAction(object parameter)
        {
        }
        private void InsertBookAction(object parameter)
        {
        }
        private void EditBookAction(object parameter)
        {
        }
        private void DeleteBookAction(object parameter)
        {
        }
        private void RefreshCAction(object parameter)
        {
        }

        /*
        public ObservableCollection<Contact> ContactList
        {
            get => contactList;
            set
            {
                contactList = value;
                OnPropertyChanged(nameof(ContactList));
            }
        }

        public Contact? SelectedContact
        {
            get => selectedContact;
            set
            {
                selectedContact = value;
                OnPropertyChanged(nameof(SelectedContact));
            }
        }

        private void NewContactAction(object parameter)
        {
            Contact contact = new();
            ContactList.Add(contact);
        }

        private void RemoveContactAction(object parametor)
        {
            if (selectedContact != null)
            {
                ContactList.Remove(selectedContact);
            }
        }

        private void SaveAllAction(object parameter)
        {
            DataHandler.Save(ContactList);
        }
        */
    }
}
