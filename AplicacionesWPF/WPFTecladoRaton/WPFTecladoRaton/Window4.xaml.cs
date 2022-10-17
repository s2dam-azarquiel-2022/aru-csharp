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

namespace WPFTecladoRaton
{
    /// <summary>
    /// Lógica de interacción para Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
        }

        private void Elipse_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var ellipse = (Ellipse)sender;
                DragDrop.DoDragDrop(ellipse, ellipse.Fill.ToString(),
                DragDropEffects.Copy);
            }

        }

        private void Rectangle_Drop(object sender, DragEventArgs e)
        {
            Rectangle rectangle = sender as Rectangle;
            if (rectangle != null)
            {
                //Se comprueba la existencia de un dato almacenado
                //para la acción de arrastrar y colocar
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {

                    string dataString =
    (string)e.Data.GetData(DataFormats.StringFormat);
                    //Se utiliza un objeto BrushConverter para transformar
                    //esta cadena de caracteres en Brush aplicable
                    //a la propiedad Fill del rectángulo
                    BrushConverter converter = new BrushConverter();
                    if (converter.IsValid(dataString))
                    {
                        Brush newFill =
                        (Brush)converter.ConvertFromString(dataString);
                        rectangle.Fill = newFill;
                    }
                }
            }
        }

    }
}
