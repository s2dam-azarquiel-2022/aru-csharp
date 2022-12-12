using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GestionPedidosARG_4.Model
{
    internal class Connection
    {
        private OleDbConnection DbConnection;
        private OleDbCommand Command;
        private OleDbDataReader Reader;

        private string ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Z:\\MVVM\\GestionPedidosARG_4\\GestionPedidosARG_4\\DatabasePedidos.accdb";


        public ObservableCollection<Order> Get()
        {
            DbConnection = new OleDbConnection(ConnectionString);
            Command = new OleDbCommand(@"
                SELECT *
                FROM tpedidos
            ", DbConnection)
            {
                CommandType = CommandType.Text
            };
            ObservableCollection<Order> result = new ObservableCollection<Order>();
            try
            {
                DbConnection.Open();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    result.Add(new Order
                    {
                        Number = Reader["NPedido"].ToString(),
                        Client = Reader["Cliente"].ToString(),
                        DNI = Reader["DNI"].ToString(),
                        Quantity = (int) Reader["Cantidad"],
                        Date = Reader["Fecha"].ToString(),
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

        public void Add(Order order)
        {
            DbConnection = new OleDbConnection(ConnectionString);
            Command = new OleDbCommand
            {
                Connection = DbConnection,
                CommandType = CommandType.Text,
                CommandText = @"
                    INSERT INTO tpedidos
                    (npedido, cliente, dni, cantidad, fecha)
                    VALUES (@p1, @p2, @p3, @p4, @p5);
                "
            };
            Command.Parameters.AddWithValue("@p1", order.Number);
            Command.Parameters.AddWithValue("@p2", order.Client);
            Command.Parameters.AddWithValue("@p3", order.DNI);
            Command.Parameters.AddWithValue("@p4", order.Quantity);
            Command.Parameters.AddWithValue("@p5", order.Date);
            DbConnection.Open();
            Command.ExecuteNonQuery();
            MessageBox.Show("Registro agregado exitosamente");
            DbConnection.Close();
        }

        public int Remove(string number)
        {
            DbConnection = new OleDbConnection(ConnectionString);
            Command = new OleDbCommand(@"
                DELETE FROM tpedidos
                WHERE npedido = @p0
            ", DbConnection)
            {
                CommandType = CommandType.Text
            };
            Command.Parameters.AddWithValue("@p0", number);
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

        public int Update(Order order)
        {
            DbConnection = new OleDbConnection(ConnectionString);
            Command = new OleDbCommand(@"
                UPDATE tpedidos
                SET cliente = @p2,
                    dni = @p3,
                    cantidad = @p4,
                    fecha = @p5
                WHERE npedido = @p1
            ", DbConnection)
            {
                CommandType = CommandType.Text
            };
            Command.Parameters.AddWithValue("@p1", order.Number);
            Command.Parameters.AddWithValue("@p2", order.Client);
            Command.Parameters.AddWithValue("@p3", order.DNI);
            Command.Parameters.AddWithValue("@p4", order.Quantity);
            Command.Parameters.AddWithValue("@p5", order.Date);
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
