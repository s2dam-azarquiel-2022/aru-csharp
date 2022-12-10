using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;

namespace LibrosCM.Model
{
    internal class Connection
    {
        private OleDbConnection DbConnection;
        private OleDbCommand Command;
        private OleDbDataReader Reader;

        private string ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='Z:\\MVVM\\DatosLibros\\DatosLibros\\Librerias.accdb'";

        public ObservableCollection<Book> Get()
        {
            DbConnection = new OleDbConnection(ConnectionString);
            Command = new OleDbCommand(@"
                SELECT *
                FROM libros
            ", DbConnection)
            {
                CommandType = CommandType.Text
            };
            ObservableCollection<Book> result = new ObservableCollection<Book>();
            try
            {
                DbConnection.Open();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    result.Add(new Book
                    {
                        Title = Reader["Titulo"].ToString(),
                        Isbn = Reader["ISBN"].ToString(),
                        Author = Reader["Autor"].ToString(),
                        Editorial = Reader["Editorial"].ToString(),
                    });
                }
            } catch (Exception e)
            {
                throw e;
            } finally
            {
                DbConnection.Close();
            }

            return result;
        }

        public void Add(Book book)
        {
            DbConnection = new OleDbConnection(ConnectionString);
            Command = new OleDbCommand
            {
                Connection = DbConnection,
                CommandType = CommandType.Text,
                CommandText = @"
                    INSERT INTO libros
                    (titulo, isbn, autor, editorial)
                    VALUES (@p1, @p2, @p3, @p4);
                "
            };
            Command.Parameters.AddWithValue("@p1", book.Title);
            Command.Parameters.AddWithValue("@p2", book.Isbn);
            Command.Parameters.AddWithValue("@p3", book.Author);
            Command.Parameters.AddWithValue("@p4", book.Editorial);
            DbConnection.Open();
            Command.ExecuteNonQuery();
            MessageBox.Show("Registro agregado exitosamente");
            DbConnection.Close();
        }

        public int Remove(string isbn)
        {
            DbConnection = new OleDbConnection();
            Command = new OleDbCommand(@"
                DELETE FROM libros
                WHERE isbn = @p0
            ", DbConnection)
            {
                CommandType = CommandType.Text
            };
            Command.Parameters.AddWithValue("@p0", isbn);
            try
            {
                DbConnection.Open();
                return Command.ExecuteNonQuery();
            } catch (Exception e)
            {
                throw e;
            } finally
            {
                DbConnection.Close();
            }
        }

        public int Update(Book book)
        {
            DbConnection = new OleDbConnection(ConnectionString);
            Command = new OleDbCommand(@"
                UPDATE libros
                SET titulo = @p1,
                    isbn = @p2,
                    autor = @p3,
                    editorial = @p4
                WHERE isbn = @p2
            ", DbConnection)
            {
                CommandType = CommandType.Text
            };
            Command.Parameters.AddWithValue("@p1", book.Title);
            Command.Parameters.AddWithValue("@p2", book.Isbn);
            Command.Parameters.AddWithValue("@p3", book.Author);
            Command.Parameters.AddWithValue("@p4", book.Editorial);
            try
            {
                DbConnection.Open();
                return Command.ExecuteNonQuery();
            } catch (Exception e)
            {
                throw e;
            }
            finally
            {
                DbConnection.Close();
            }
        }
    }
}
