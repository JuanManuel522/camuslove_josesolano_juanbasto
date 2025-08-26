using System;
using Modules.Profiles.Domain.Entities;
using Modules.Profiles.Infrastructure;
using Modules.Profiles.Domain.Interfaces;

namespace Modules.Ui
{
    public static class MenuLogin
    {
        // Creo una instancia del repositorio para manejar los usuarios
        private static IUsuarioRepository _repository = new UsuarioRepository();
        
        // Variable estática para guardar el usuario que está logueado actualmente
        public static Usuario? UsuarioActual { get; private set; }

        // Método principal que muestra el menú de login
        public static void MostrarMenu()
        {
            int opcion = 0;

            // Bucle principal del menú - se repite hasta que el usuario elija salir
            do
            {
                Console.Clear(); // Limpio la pantalla para que se vea ordenado
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("===== Bienvenido a Campus Love ❤️ =====");
                Console.ResetColor();

                // Muestro las opciones disponibles
                Console.WriteLine("1. Iniciar Sesión");
                Console.WriteLine("2. Registrarse");
                Console.WriteLine("3. Salir");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Selecciona una opción: ");
                Console.ResetColor();

                // Valido que ingrese un número válido
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            IniciarSesion(); // Llamo al método de login
                            break;
                        case 2:
                            Registrarse(); // Llamo al método de registro
                            break;
                        case 3:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("¡Gracias por usar Campus Love! Nos vemos pronto 😉");
                            Console.ResetColor();
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Opción inválida, intenta de nuevo...");
                            Console.ResetColor();
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    // Si no ingresó un número
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Debes ingresar un número válido...");
                    Console.ResetColor();
                    Console.ReadKey();
                }

            } while (opcion != 3); // Continúo hasta que elija salir
        }

        // Método para registrar un nuevo usuario
        private static void Registrarse()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("===== Registro de Usuario =====");
            Console.ResetColor();

            // Pido el nombre de usuario y verifico que no exista
            Console.Write("Nombre de usuario: ");
            string nombre = Console.ReadLine() ?? "";

            if (_repository.GetUsuarioByNombre(nombre) != null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("⚠️ Ese nombre de usuario ya está en uso.");
                Console.ResetColor();
                Console.ReadKey();
                return; // Salgo si ya existe
            }

            // Pido todos los datos del perfil
            Console.Write("Contraseña: ");
            string contrasena = Console.ReadLine() ?? "";

            Console.Write("Edad: ");
            int edad = int.Parse(Console.ReadLine() ?? "18");

            Console.Write("Género (M/F): ");
            string genero = Console.ReadLine() ?? "";

            Console.Write("Carrera: ");
            string carrera = Console.ReadLine() ?? "";

            Console.Write("Intereses: ");
            string intereses = Console.ReadLine() ?? "";

            Console.Write("Frase de perfil: ");
            string frase = Console.ReadLine() ?? "";

            // Creo el nuevo usuario con todos los datos
            Usuario nuevo = new Usuario(0, nombre, contrasena, edad, genero, carrera, intereses, frase);
            _repository.AddUsuario(nuevo); // Lo guardo en el repositorio

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

            // Pido las credenciales
            Console.Write("Usuario: ");
            string nombre = Console.ReadLine() ?? "";

            Console.Write("Contraseña: ");
            string contrasena = Console.ReadLine() ?? "";

            // Busco el usuario en el repositorio
            var usuario = _repository.GetUsuarioByNombre(nombre);
            
            // Verifico que exista y la contraseña sea correcta
            if (usuario != null && usuario.Contrasena == contrasena)
            {
                UsuarioActual = usuario; // Guardo el usuario como logueado

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"✅ Bienvenido {UsuarioActual.Nombre}!");
                Console.ResetColor();
                Console.ReadKey();

<<<<<<< HEAD
                // Voy al menú principal pasándole el repositorio
                MenuPrincipal menuPrincipal = new MenuPrincipal(_repository);
                menuPrincipal.MostrarMenuPrincipal();
                return;
=======
                    // Aquí lo enviamos al Menú Principal que hizo tu amigo
                    MenuPrincipal menuPrincipal = new MenuPrincipal();
                    menuPrincipal.MostrarMenuPrincipal();

                    return; // Salimos porque ya entró al sistema
                }
>>>>>>> b32af503e0f27beda6886759544291c37fe823bc
            }

            // Si las credenciales no son válidas
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ Usuario o contraseña incorrectos.");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}