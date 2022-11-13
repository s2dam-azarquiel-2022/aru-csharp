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
using WPFSeleccion;

namespace WPFControlesSeleccion
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MenuItem_Click_ListView(object sender, RoutedEventArgs e)
        {
            new Window2().Show();
        }

        private void MenuItem_Click_TreeView(object sender, RoutedEventArgs e)
        {
            new Window1().Show();
        }

        private void MenuItem_Click_End(object sender, RoutedEventArgs e)
        {
            //Aplicaciones WF
            //Aplication.Exit()

            //Aplicaciones WPF
            App.Current.Shutdown();
        }
    }
}
