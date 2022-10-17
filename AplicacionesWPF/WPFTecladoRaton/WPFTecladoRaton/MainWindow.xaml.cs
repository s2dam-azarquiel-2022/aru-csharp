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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFTecladoRaton
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            switch (((RadioButton)sender).Content.ToString())
            {
                case "Evento Teclado Ventana":
                    Window1 Ventana1 = new();
                    Ventana1.Show();
                    break;
                case "Eventos Teclado Ventana II":
                    Window2 Ventana2 = new();
                    Ventana2.Show();
                    break;
                case "Eventos Raton":
                    Window3 Ventana3 = new();
                    Ventana3.Show();
                    break;
                case "Arrastrar y Colocar":
                    Window4 Ventana4 = new();
                    Ventana4.Show();
                    break;
            }
        }
    }
}
