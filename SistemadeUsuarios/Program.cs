using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SistemadeUsuarios
{
    public class Program
    {
        private static Sistema sistema = new Sistema();

        public static void Main(string[] args)
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("             Bienvenido              ");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Que deseas hacer?");
                Console.WriteLine("1. Crear cuenta");
                Console.WriteLine("2. Iniciar sesión");
                Console.WriteLine("3. Salir");
                string opc = Console.ReadLine();

                switch (opc)
                {
                    case "1":
                        Console.Clear();
                        CrearCuenta();
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        IniciarSesion();
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Vuelve pronto!");
                        salir = true;
                        Console.ReadKey();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opción no válida, intentelo de nuevo.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void CrearCuenta()
        {
            Console.Write("Ingrese su correo electrónico: ");
            string correo = Console.ReadLine();
            Console.Write("Ingrese su contraseña: ");
            string contraseña = Console.ReadLine();
            Console.Write("Confirme su contraseña: ");
            string confirmarContraseña = Console.ReadLine();

            if (contraseña != confirmarContraseña)
            {
                Console.WriteLine("Las contraseñas no coinciden.");
                return;
            }

            sistema.CrearCuenta(correo, contraseña);
        }

        private static void IniciarSesion()
        {
            Console.Write("Ingrese su correo electrónico: ");
            string correo = Console.ReadLine();
            Console.Write("Ingrese su contraseña: ");
            string contraseña = Console.ReadLine();

            if (sistema.IniciarSesion(correo, contraseña))
            {
                Console.WriteLine("Inicio de sesión exitoso.");
                MenuSesion();
            }
            else
            {
                Console.WriteLine("Correo o contraseña incorrectos.");
            }
        }

        private static void MenuSesion()
        {
            bool cerrarSesion = false;
            while (!cerrarSesion)
            {
                try
                {
                Console.WriteLine("1. Cerrar sesión");
                Console.WriteLine("2. Volver");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":

                            Console.Clear();
                            Console.WriteLine("Sesión cerrada exitosamente.");
                            cerrarSesion = true;
                            Console.ReadKey();
                       
                        break;
                    case "2":
                        Console.Clear();
                        cerrarSesion = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opción no válida.");
                        break;
                }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.Clear();
                    Console.WriteLine("Error, intentelo de nuevo.");
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese los datos de manera correcta, por favor.");
                }
                catch (OverflowException)
                {
                    Console.Clear();
                    Console.WriteLine("Error, intentelo de nuevo");
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Error, intentelo de nuevo");
                }
            }
        }
    }
}
