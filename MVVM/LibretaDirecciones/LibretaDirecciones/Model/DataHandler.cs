using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibretaDirecciones.Model
{
    internal class DataHandler
    {
        private const string dataFile = "contacts.txt";

        public static Contact[] ReadAll()
        {
            if (!File.Exists(dataFile))
            {
                return Array.Empty<Contact>();
            }

            string[] contents = File.ReadAllLines(dataFile);
            Contact[] result = new Contact[contents.Length];
            for (int i = 0; i < contents.Length; i++)
            {
                string[] fields = contents[i].Split('\t');
                result[i] = new Contact
                {
                    Name = fields[0],
                    Surname = fields[1],
                    Phone = fields[2],
                    Email = fields[3],
                    Address = fields[4],
                    Function = fields[5],
                    Company = fields[6],
                };
            }
            return result;
        }

        public static void Save(IEnumerable<Contact> contacts)
        {
            StringBuilder builder = new StringBuilder();
            foreach (Contact contact in contacts)
            {
                builder.AppendLine(string.Format(
                    "{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}",
                    contact.Name,
                    contact.Surname,
                    contact.Phone,
                    contact.Email,
                    contact.Address,
                    contact.Function,
                    contact.Company
                ));
            }
            File.WriteAllText(dataFile, builder.ToString());
        }
    }
}
