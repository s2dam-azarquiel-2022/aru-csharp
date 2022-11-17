using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Windows.Input;

namespace DatosLibros.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private const string DB_NAME = "Libros";

        private readonly OleDbConnection Connection;
        private readonly OleDbDataAdapter Adapter;
        private readonly DataSet DataSet;
        private readonly OleDbCommandBuilder CommandBuilder;

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

        private bool textEnabled;
        public bool TextEnabled
        {
            get => textEnabled;
            set
            {
                textEnabled = value;
                OnPropertyChanged(nameof(TextEnabled));
            }
        }

        private bool buttonsEnabled;
        public bool ButtonsEnabled
        {
            get => buttonsEnabled;
            set
            {
                buttonsEnabled = value;
                OnPropertyChanged(nameof(ButtonsEnabled));
            }
        }

        private bool insertBtnEnabled;
        public bool InsertBtnEnabled
        {
            get => insertBtnEnabled;
            set
            {
                insertBtnEnabled = value;
                OnPropertyChanged(nameof(InsertBtnEnabled));
            }
        }

        private bool editBtnEnabled;
        public bool EditBtnEnabled
        {
            get => editBtnEnabled;
            set
            {
                editBtnEnabled = value;
                OnPropertyChanged(nameof(EditBtnEnabled));
            }
        }

        private string editBtnText;
        public string EditBtnText
        {
            get => editBtnText;
            set
            {
                editBtnText = value;
                OnPropertyChanged(nameof(EditBtnText));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
                ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='Z:\\MVVM\\DatosLibros\\DatosLibros\\Librerias.accdb'"
            };
            Adapter = new OleDbDataAdapter("SELECT * FROM " + DB_NAME, Connection);
            CommandBuilder = new OleDbCommandBuilder(Adapter);
            DataSet = new DataSet();

            Connection.Open();
            Adapter.Fill(DataSet, DB_NAME);
            Connection.Close();

            PropertyChanged += EventHandler;

            CurrentPage = 1;
            UpdateTotalPageCount();

            TextEnabled = false;
            ButtonsEnabled = true;

            InsertBtnEnabled = false;

            EditBtnEnabled = ButtonsEnabled;
            EditBtnText = "Modificar";

            FirstPageCommand = new Command(FirstPageAction);
            NextPageCommand = new Command(NextPageAction);
            PreviousPageCommand = new Command(PreviousPageAction);
            LastPageCommand = new Command(LastPageAction);
            NewBookCommand = new Command(NewBookAction);
            InsertBookCommand = new Command(InsertBookAction);
            EditBookCommand = new Command(EditBookAction);
            DeleteBookCommand = new Command(DeleteBookAction);
            RefreshCommand = new Command(RefreshAction);
        }

        private void ViewData()
        {
            if (currentPage < 1)
            {
                EmptyFields();
                return;
            }

            DataRow dataRow = DataSet.Tables[DB_NAME].Rows[CurrentPage - 1];
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

        private void EventHandler(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(TotalPages):
                    UpdateCurrentPageStr();
                    break;

                case nameof(CurrentPage):
                    UpdateCurrentPageStr();
                    ViewData();
                    break;

                case nameof(ButtonsEnabled):
                    TextEnabled = !ButtonsEnabled;
                    break;

                case nameof(InsertBtnEnabled):
                    ButtonsEnabled = !InsertBtnEnabled;
                    EditBtnEnabled = ButtonsEnabled;
                    break;
            }
        }

        private void FirstPageAction(object parameter)
        {
            if (CurrentPage <= 1) return;
            CurrentPage = 1;
        }

        private void NextPageAction(object parameter)
        {
            if (CurrentPage == TotalPages) return;
            CurrentPage++;
        }

        private void PreviousPageAction(object parameter)
        {
            if (CurrentPage <= 1) return;
            CurrentPage--;
        }

        private void LastPageAction(object parameter)
        {
            LastPage();
        }

        private void NewBookAction(object parameter)
        {
            EmptyFields();
            InsertBtnEnabled = true;
        }

        private void EmptyFields()
        {
            Title = "";
            Isbn = "";
            Author = "";
            Editorial = "";
        }

        private void InsertBookAction(object parameter)
        {
            DataRow dataRow = DataSet.Tables[DB_NAME].NewRow();
            dataRow["Titulo"] = Title;
            dataRow["ISBN"] = Isbn;
            dataRow["Autor"] = Author;
            dataRow["Editorial"] = Editorial;
            DataSet.Tables[DB_NAME].Rows.Add(dataRow);
            UpdateTotalPageCount();
            LastPage();
            InsertBtnEnabled = false;
        }

        private void EditBookAction(object parameter)
        {
            ButtonsEnabled = !ButtonsEnabled;
            if (ButtonsEnabled)
            {
                DataRow dataRow = DataSet.Tables[DB_NAME].Rows[CurrentPage-1];
                dataRow.BeginEdit();
                dataRow["Titulo"] = Title;
                dataRow["ISBN"] = Isbn;
                dataRow["Autor"] = Author;
                dataRow["Editorial"] = Editorial;
                dataRow.EndEdit();
                EditBtnText = "Modificar";
            } else
            {
                EditBtnText = "Aceptar";
            }
        }

        private void DeleteBookAction(object parameter)
        {
            if (CurrentPage < 1) return;
            DataSet.Tables[DB_NAME].Rows[CurrentPage - 1].Delete();
            Refresh();
        }

        private void RefreshAction(object parameter)
        {
            Refresh();
        }

        private void Refresh()
        {
            Connection.Open();
            Adapter.Update(DataSet, DB_NAME);
            Connection.Close();
            UpdateTotalPageCount();
            CheckCurrentPage();
        }

        private void LastPage()
        {
            CurrentPage = TotalPages;
        }

        private void UpdateTotalPageCount()
        {
            TotalPages = DataSet.Tables[DB_NAME].Rows.Count;
        }

        private void CheckCurrentPage()
        {
            CurrentPage = CurrentPage > TotalPages ? TotalPages : CurrentPage;
        }

        private void UpdateCurrentPageStr()
        {
            CurrentPageStr = String.Format(
                "Libro {0} de {1}",
                CurrentPage,
                TotalPages
            );
        }
    }
}
