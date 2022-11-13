using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFSeleccion
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public List<RegionesDelMundo> Regiones { get; set; }
        public Window1()
        {
            InitializeComponent();
            Regiones = new List<RegionesDelMundo>
            {
                new RegionesDelMundo
                {
                    NombreRegion = "Europa",
                    ListaPaises = new List<Pais>
                    {
                        new Pais { Nombre = "Reino Unido" },
                        new Pais { Nombre = "Dinamarca" },
                        new Pais { Nombre = "Suecia" }
                    }
                }
            };
            this.DataContext = this;
        }
    }
}
