using LibrosCM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            BookList = connection.GetBooks();
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
    }
}
