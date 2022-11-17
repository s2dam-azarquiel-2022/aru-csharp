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

        private string title;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        private string isbn;
        public string Isbn
        {
            get => isbn;
            set
            {
                isbn = value;
                OnPropertyChanged(nameof(Isbn));
            }
        }

        private string author;
        public string Author
        {
            get => author;
            set
            {
                author = value;
                OnPropertyChanged(nameof(Author));
            }
        }

        private string editorial;
        public string Editorial
        {
            get => editorial;
            set
            {
                editorial = value;
                OnPropertyChanged(nameof(Editorial));
            }
        }

        private int currentPage;
        public int CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }

        private int totalPages;
        public int TotalPages
        {
            get => totalPages;
            set
            {
                totalPages = value;
                OnPropertyChanged(nameof(TotalPages));
            }
        }

        private string currentPageStr;
        public string CurrentPageStr
        {
            get => currentPageStr;
            set
            {
                currentPageStr = value;
                OnPropertyChanged(nameof(CurrentPageStr));
            }
        }

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


            CurrentPage = 1;
            TotalPages = DataSet.Tables["Libros"].Rows.Count;

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

        private void ViewData()
        {
            DataRow dataRow = DataSet.Tables["Libros"].Rows[CurrentPage - 1];
            if (dataRow.RowState == DataRowState.Deleted) return;
            Title = dataRow["Titulo"].ToString();
            Isbn = dataRow["ISBN"].ToString();
            Author = dataRow["Autor"].ToString();
            Editorial = dataRow["Editorial"].ToString();
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName)
            );
        }

        private void UpdateCurrentPageStr()
        {
            CurrentPageStr = String.Format("Libro {0} de {1}", CurrentPage, TotalPages);
        }

        private void FirstPageAction(object parameter)
        {
            CurrentPage = 1;
        }
        private void NextPageAction(object parameter)
        {
            if (CurrentPage == TotalPages) return;
            CurrentPage++;
        }
        private void PreviousPageAction(object parameter)
        {
            if (CurrentPage == 1) return;
            CurrentPage--;
        }
        private void LastPageAction(object parameter)
        {
            CurrentPage = DataSet.Tables["Libros"].Rows.Count;
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
    }
}
