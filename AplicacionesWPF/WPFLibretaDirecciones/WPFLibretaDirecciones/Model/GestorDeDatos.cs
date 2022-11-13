using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFLibretaDirecciones.Model
{
    internal class GestorDeDatos
    {
        private const string archivoDatos = "contactos.txt";
        public Contacto[] LeeTodosLosRegistros()
        {
            if (!File.Exists(archivoDatos))
            {
                return Array.Empty<Contacto>();
            }
            string[] registros = File.ReadAllLines(archivoDatos);
            Contacto[] resultado = new Contacto[registros.Length];
            for (int i = 0; i < registros.Length; i++)
            {
                string[] campos = registros[i].Split('\t');
                Contacto contacto = new Contacto
                {
                    Nombre = campos[0],
                    Apellidos = campos[1],
                    Telefono = campos[2],
                    Email = campos[3],
                    Direccion = campos[4],
                    Funcion = campos[5],
                    Empresa = campos[6]
                };
                resultado[i] = contacto;
            }
            return resultado;
        }

        public void Registrar(IEnumerable<Contacto> contactos)
        {
            StringBuilder builder = new StringBuilder();
            foreach (Contacto c in contactos)
            {
                builder.AppendLine(string.Format(
                    "{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}",
                    c.Nombre,
                    c.Apellidos,
                    c.Telefono,
                    c.Email,
                    c.Direccion,
                    c.Funcion,
                    c.Empresa
                ));
            }
        }
    }
}
