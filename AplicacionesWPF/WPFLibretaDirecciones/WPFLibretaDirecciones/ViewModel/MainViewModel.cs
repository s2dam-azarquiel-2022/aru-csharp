using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFLibretaDirecciones.Model;

namespace WPFLibretaDirecciones.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private GestorDeDatos GestorDeDatos;
        private ObservableCollection<Contacto> listaContactos;

        public ObservableCollection<Contacto> ListaContactos
        {
            get { return listaContactos; }
            set
            {
                listaContactos = value;
                OnPropertyChanged("ListaContactos");
            }
        }

        public MainViewModel()
        {
            GestorDeDatos = new GestorDeDatos();
            ListaContactos = new ObservableCollection<Contacto>(GestorDeDatos.LeeTodosLosRegistros());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            } 
        }

        public ICommand ComandoNuevoContacto { get; set; }
        public ICommand ComandoEliminarContacto { get; set; }
        public ICommand ComandoGuardarTodo { get; set; }

        private void AccionNuevoContacto(object parametro)
        {
            Contacto contacto = new Contacto
            {
                Nombre = "Manolo",
                Apellidos = "El Lamedor"
            };
            ListaContactos.Add(contacto);
        }

        private void AccionGuardarTodo(object parametro)
        {
            GestorDeDatos.Registrar(ListaContactos);
        }
        private void AccionEliminarContacto(object parametro)
        {
            if (ContactoSeleccionado != null)
            {
                ListaContactos.Remove(ContactoSeleccionado);
            }
        }

        private Contacto contactoSeleccionado;
        public Contacto ContactoSeleccionado
        {
            get { return contactoSeleccionado; }
            set
            {
                contactoSeleccionado = value;
                OnPropertyChanged("ContactoSeleccionado");
                if (contactoSeleccionado == null)
                {
                    ActivarEliminacionYEdicion = false;
                } else
                {
                    ActivarEliminacionYEdicion = true;
                }
            }
        }

        private bool activarEliminacionYEdicion;
        public bool ActivarEliminacionYEdicion
        {
            get { return activarEliminacionYEdicion; }
            set
            {
                activarEliminacionYEdicion= value;
                OnPropertyChanged("ActivarEliminicaionYEdicion");
            }
        }
    }
}
