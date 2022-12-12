using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPedidosARG_4.Model
{
    internal class Order
    {
        public String Number { get; set; }
        public String Client { get; set; }
        public String DNI { get; set; }
        public int Quantity { get; set; }
        public String Date { get; set; }
    }
}
