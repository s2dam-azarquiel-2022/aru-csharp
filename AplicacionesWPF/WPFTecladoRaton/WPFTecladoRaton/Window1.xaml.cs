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
public delegate void KeyEventHandler(object sender, KeyEventArgs e);
public delegate void TextCompositionEventHandler(object sender,
TextCompositionEventArgs e);

namespace WPFTecladoRaton
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            KeyDown += Window_ManipulacionTeclaTeclado;
            TextInput += MainWindow_TextInput;
        }
        void MainWindow_TextInput(object sender, TextCompositionEventArgs e)
        {
            Console.WriteLine(e.Text);
        }
        private void Window_ManipulacionTeclaTeclado(object sender, KeyEventArgs e)
        {
            Console.WriteLine("{0}\tIsUp = {1}\tIsDown= {2}\tKeyStates = {3}", e.Key, e.IsUp, e.IsDown, e.KeyStates);
        }
    }
}



