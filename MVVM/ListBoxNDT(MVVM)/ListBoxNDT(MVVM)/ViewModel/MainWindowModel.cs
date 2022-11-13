using ListBoxNDT_MVVM_.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ListBoxNDT_MVVM_.ViewModel
{
    public class MainWindowModel : INotifyPropertyChanged
    {

        private List<Contacto> listaContactos;

        public List<Contacto> ListaContactos
        {
            get { return listaContactos; }

            set 
            { 
                listaContactos = value;

                OnPropertyChanged("ListaContactos");
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
            }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }

            set
            {
                nombre = value;

                OnPropertyChanged("Nombre");
            }
        }

        private string apellidos;

        public string Apellidos
        {
            get { return apellidos; }

            set
            {
                apellidos = value;

                OnPropertyChanged("Apellidos");
            }
        }

        private string telefono;

        public string Telefono
        {
            get { return telefono; }

            set
            {
                telefono = value;

                OnPropertyChanged("Telefono");
            }
        }

        public ICommand ComandoMostrarContacto { get; set; }

        public MainWindowModel()
        {
            ListaContactos = new List<Contacto>
            {
                new Contacto() {Nombre="Pepe", Apellidos="Apellidos1", Telefono="Teléfono1"},
                new Contacto() {Nombre="Nombre2", Apellidos="Apellidos2", Telefono="Teléfono2"},
                new Contacto() {Nombre="Nombre3", Apellidos="Apellidos3", Telefono="Teléfono3"}
            };

            ComandoMostrarContacto = new Command(AccionMostrarContacto);
        }

        private void AccionMostrarContacto(object obj)
        {
            Nombre = ContactoSeleccionado.Nombre;

            Apellidos=ContactoSeleccionado.Apellidos;

            Telefono= ContactoSeleccionado.Telefono;

        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new
                PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
