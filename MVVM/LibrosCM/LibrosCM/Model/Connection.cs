using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

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
    }
}
