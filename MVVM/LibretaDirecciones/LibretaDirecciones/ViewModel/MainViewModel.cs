using LibretaDirecciones.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibretaDirecciones.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<Contact> contactList = default!;
        public ObservableCollection<Contact> ContactList
        {
            get => contactList;
            set
            {
                contactList = value;
                OnPropertyChanged(nameof(ContactList));
            }
        }

        private Contact? selectedContact;
        public Contact? SelectedContact
        {
            get => selectedContact;
            set
            {
                selectedContact = value;
                OnPropertyChanged(nameof(SelectedContact));
            }
        }

        private bool editAndDeleteEnabled;
        public bool EditAndDeleteEnabled
        {
            get => editAndDeleteEnabled;
            set
            {
                editAndDeleteEnabled = value;
                OnPropertyChanged(nameof(EditAndDeleteEnabled));
            }
        }

        public ICommand NewContactCommand { get; set; }
        public ICommand RemoveContactCommand { get; set; }
        public ICommand SaveAllCommand { get; set; }

        public MainViewModel()
        {
            ContactList = new ObservableCollection<Contact>(DataHandler.ReadAll());

            PropertyChanged += EventHandler;
            EditAndDeleteEnabled = false;

            NewContactCommand = new Command(NewContactAction);
            RemoveContactCommand = new Command(RemoveContactAction);
            SaveAllCommand = new Command(SaveAllAction);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName)
            );
        }

        private void EventHandler(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(SelectedContact):
                    EditAndDeleteEnabled = SelectedContact != null;
                    break;
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
    }
}
