using System;
using Modules.Ui;

namespace CampusLove
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Configurar colores de la consola
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==============================================");
            Console.WriteLine("     Bienvenido a Campus Love 💕 (Beta 1.0)   ");
            Console.WriteLine("==============================================");
            Console.ResetColor();
            // Ejecutamos el menú de login directamente
            // Aquí el usuario podrá iniciar sesión, registrarse o salir
            MenuLogin.MostrarMenu(null);

        }
    }
}
