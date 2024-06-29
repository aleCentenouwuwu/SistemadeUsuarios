using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeUsuarios
{
    public class Sistema
    {
        private List<Usuario> usuarios;
        private Usuario usuarioActual;

        public Sistema()
        {
            usuarios = new List<Usuario>();
            usuarios.Add(new Usuario("aleale@gmail.com", "contrasena123"));
            usuarios.Add(new Usuario("uwu@gmail.com", "omg12345"));
        }

        public bool IniciarSesion(string correo, string contraseña)
        {
            foreach (var usuario in usuarios)
            {
                if (usuario.Correo == correo && usuario.Contraseña == contraseña)
                {
                    usuarioActual = usuario;
                    return true;
                }
            }
            return false;
        }

        public bool CerrarSesion()
        {
            if (usuarioActual != null)
            {
                usuarioActual = null;
                return true;
            }
            return false;
        }

        public bool CrearCuenta(string correo, string contraseña)
        {
            if (!EsCorreoValido(correo))
            {
                Console.WriteLine("Correo electrónico no válido.");
                return false;
            }

            if (contraseña.Length < 8)
            {
                Console.WriteLine("La contraseña debe tener al menos 8 caracteres.");
                return false;
            }

            foreach (var usuario in usuarios)
            {
                if (usuario.Correo == correo)
                {
                    Console.WriteLine("El correo electrónico ya está en uso.");
                    return false;
                }
            }

            usuarios.Add(new Usuario(correo, contraseña));
            Console.WriteLine("Cuenta creada exitosamente.");
            return true;
        }

        private bool EsCorreoValido(string correo)
        {
            bool verificador_Arroba = false;
            bool verificador_Punto = false;
            bool verificador_Punto_despues_de_Arroba = false;
            {
                foreach (var item in correo)
                {
                    if (item == '@')
                    {
                        verificador_Arroba = true;
                    }
                    else if (item == '.')
                    {
                        verificador_Punto = true;

                        if (verificador_Arroba == true)
                        {
                            verificador_Punto_despues_de_Arroba = true;
                        }
                    }
                }
                if (verificador_Punto_despues_de_Arroba)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

    }
}