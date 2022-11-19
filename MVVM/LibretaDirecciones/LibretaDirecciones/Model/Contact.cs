using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibretaDirecciones.Model
{
    internal class Contact
    {
        public string Name { get; set; } = "New Contact";
        public string Surname { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string Function { get; set; } = default!;
        public string Company { get; set; } = default!;
    }
}
