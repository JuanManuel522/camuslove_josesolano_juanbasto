using System;
using System.Collections.Generic;

namespace Modules.Ui
{
    public static class MenuLogin
    {
        // Lista en memoria que hace de "base de datos" para guardar los usuarios registrados
        private static List<Usuario> usuarios = new List<Usuario>();

        // Aquí se guarda el usuario que inicia sesión correctamente
        public static Usuario? UsuarioActual { get; private set; }

        // Método principal del menú de login (aquí empieza todo este módulo)
        public static void MostrarMenu(Usuario? usuarioActual)
        {
            int opcion = 0;

            // Usamos un bucle para que el menú se repita hasta que el usuario decida salir
            do
            {
                Console.Clear(); // Limpia la pantalla para que el menú se vea limpio
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("===== Bienvenido a Campus Love ❤️ =====");
                Console.ResetColor();

                // Opciones del menú login
                Console.WriteLine("1. Iniciar Sesión");
                Console.WriteLine("2. Registrarse");
                Console.WriteLine("3. Salir");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Selecciona una opción: ");
                Console.ResetColor();

                // Validamos que la opción ingresada sea un número
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1: // Opción para iniciar sesión
                            IniciarSesion();
                            break;

                        case 2: // Opción para registrarse
                            Registrarse();
                            break;

                        case 3: // Opción para salir
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("¡Gracias por usar Campus Love! Nos vemos pronto 😉");
                            Console.ResetColor();
                            break;

                        default: // Si pone un número fuera del menú
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Opción inválida, intenta de nuevo...");
                            Console.ResetColor();
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    // Si el usuario escribe algo que no es un número
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Debes ingresar un número válido...");
                    Console.ResetColor();
                    Console.ReadKey();
                }

            } while (opcion != 3); // El bucle se repite hasta que elija salir
        }

        // Método para registrar un nuevo usuario
        private static void Registrarse()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("===== Registro de Usuario =====");
            Console.ResetColor();

            // Pedimos los datos básicos del nuevo usuario
            Console.Write("Ingresa tu nombre de usuario: ");
            string nombre = Console.ReadLine() ?? "";

            Console.Write("Ingresa tu contraseña: ");
            string contrasena = Console.ReadLine() ?? "";

            // Recorremos la lista para verificar que ese nombre de usuario no esté repetido
            foreach (var user in usuarios)
            {
                if (user.Nombre == nombre)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("⚠️ Ese nombre de usuario ya está en uso. Intenta con otro.");
                    Console.ResetColor();
                    Console.ReadKey();
                    return; // Salimos del método porque no se puede registrar
                }
            }

            // Creamos un nuevo objeto Usuario con los datos ingresados
            Usuario nuevo = new Usuario(nombre, contrasena);

            // Lo agregamos a la lista (simulando guardar en una base de datos)
            usuarios.Add(nuevo);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("🎉 Registro exitoso. Ahora puedes iniciar sesión.");
            Console.ResetColor();
            Console.ReadKey();
        }

        // Método para iniciar sesión
        private static void IniciarSesion()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("===== Iniciar Sesión =====");
            Console.ResetColor();

            // Pedimos las credenciales
            Console.Write("Usuario: ");
            string nombre = Console.ReadLine() ?? "";

            Console.Write("Contraseña: ");
            string contrasena = Console.ReadLine() ?? "";

            // Recorremos la lista buscando si el usuario existe y la contraseña coincide
            foreach (var user in usuarios)
            {
                if (user.Nombre == nombre && user.Contrasena == contrasena)
                {
                    UsuarioActual = user; // Guardamos al usuario como "logueado"

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"✅ Bienvenido {UsuarioActual.Nombre}, iniciando tu sesión...");
                    Console.ResetColor();
                    Console.ReadKey();

                    // Aquí lo enviamos al Menú Principal que hizo tu amigo
                   // MenuPrincipal menuPrincipal = new MenuPrincipal();
                    // menuPrincipal.MostrarMenuPrincipal();

                    return; // Salimos porque ya entró al sistema
                }
            }

            // Si no encontró coincidencia
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ Usuario o contraseña incorrectos. Intenta de nuevo.");
            Console.ResetColor();
            Console.ReadKey();
        }
    }

    // Clase Usuario (molde básico para cada persona que se registra en el sistema)
    public class Usuario
    {
        public string Nombre { get; set; } // Nombre de usuario
        public string Contrasena { get; set; } // Contraseña

        // Constructor para inicializar un usuario nuevo con nombre y contraseña
        public Usuario(string nombre, string contrasena)
        {
            Nombre = nombre;
            Contrasena = contrasena;
        }
    }
}
