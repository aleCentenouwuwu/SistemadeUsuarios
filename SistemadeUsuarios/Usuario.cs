using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeUsuarios
{
    public class Usuario
    {
        public string Correo { get; set; }
        public string Contraseña { get; set; }

        public Usuario(string correo, string contraseña)
        {
            Correo = correo;
            Contraseña = contraseña;
        }
    }
}