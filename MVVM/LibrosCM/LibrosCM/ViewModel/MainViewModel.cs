using LibrosCM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LibrosCM.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            // Setup the event handler
            PropertyChanged += EventHandler;

            // Setup commands
            // ...

            // Setup other stuff
            connection = new Connection();
            BookList = connection.Get();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand NewCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand CancelCommand { get; set; }

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
                case nameof(SelectedBook):
                    if (SelectedBook == null) break;
                    Title = SelectedBook.Title;
                    Isbn = SelectedBook.Isbn;
                    Author = SelectedBook.Author;
                    Editorial = SelectedBook.Editorial;
                    break;
            }
        }

        private Connection connection;

        private ObservableCollection<Book> bookList;
        public ObservableCollection<Book> BookList
        {
            get => bookList;
            set
            {
                bookList = value;
                OnPropertyChanged(nameof(BookList));
            }
        }

        private Book selectedBook;
        public Book SelectedBook
        {
            get => selectedBook;
            set
            {
                selectedBook = value;
                OnPropertyChanged(nameof(SelectedBook));
            }
        }

        private String title;
        public String Title
        {
            get => title;
            set
            {
                title = value;
                Console.WriteLine(value);
                OnPropertyChanged(nameof(Title));
            }
        }

        private String isbn;
        public String Isbn
        {
            get => isbn;
            set
            {
                isbn = value;
                Console.WriteLine(value);
                OnPropertyChanged(nameof(Isbn));
            }
        }

        private String author;
        public String Author
        {
            get => author;
            set
            {
                author = value;
                Console.WriteLine(value);
                OnPropertyChanged(nameof(Author));
            }
        }

        private String editorial;
        public String Editorial
        {
            get => editorial;
            set
            {
                editorial = value;
                Console.WriteLine(value);
                OnPropertyChanged(nameof(Editorial));
            }
        }

        private void EmptyFields()
        {
            Title = "";
            Isbn = "";
            Author = "";
            Editorial = "";
        }

        private void ShowNoSelectedBookMessage()
        {
            MessageBox.Show(
                "No hay ningun libro seleccionado",
                "Informacion",
                MessageBoxButton.OK,
                MessageBoxImage.Information
            );
        }

        private void NewAction(object parameter)
        {
            EmptyFields();
        }

        private void RemoveAction(object parameter)
        {
            if (SelectedBook != null)
            {
                if (MessageBox.Show(
                        "Estas seguro de querer eliminar el libro seleccionado?",
                        "Confirmar",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Warning
                    ) == MessageBoxResult.Yes)
                {
                    int result = 0;
                    try
                    {
                        result = connection.Remove(Isbn);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                    if (result > 0)
                    {
                        BookList.Remove(SelectedBook);
                        EmptyFields();
                    }
                }
                SelectedBook = null;
            }
            else ShowNoSelectedBookMessage();
        }

        private void EditAction(object parameter)
        {
            if (SelectedBook != null)
            {

            }
            else ShowNoSelectedBookMessage();
        }

        private void UpdateAction(object parameter)
        {
            try
            {
                int result = 0;
                result = connection.Update(SelectedBook);
                if (result > 0)
                {
                    BookList = connection.Get();
                }
            } catch (Exception e)
            {
                MessageBox.Show(e.Message);
            } finally
            {
                
            }
        }

        private void SaveAction(object parameter)
        {
            Book newBook = new Book
            {
                Title = Title,
                Isbn = Isbn,
                Author = Author,
                Editorial = Editorial
            };
            try
            {
                connection.Add(newBook);
                BookList.Add(newBook);
            } catch (Exception e)
            {
                MessageBox.Show(e.Message);
            } finally
            {

            }
        }

        private void CancelAction(object parameter)
        {
            SelectedBook = null;
            EmptyFields();
        }
    }
}
