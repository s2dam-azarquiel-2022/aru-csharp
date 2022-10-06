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

namespace ContextoDeDatos
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
                Button BntNuevo =  new Button();

            BntNuevo.Name = "btnNuevo";
            BntNuevo.Height = 30;
            BntNuevo.Width = 30;
            BntNuevo.Content = "Esto es un boton";

            Rejilla.Children.Add(BntNuevo);



            BntNuevo.Click += BntNuevo_Click;
        }

        private void BntNuevo_Click(object sender, RoutedEventArgs e)
        {
           // throw new NotImplementedException();
        }
    }
}
