using System;
using Modules.Ui;

namespace CampusLove
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Cambio el color de la consola para hacer más bonito el título
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==============================================");
            Console.WriteLine("     Bienvenido a Campus Love 💕 (Beta 1.0)   ");
            Console.WriteLine("==============================================");
            Console.ResetColor(); // Regreso el color normal
            
            // Llamo directamente al menú de login para empezar el flujo
            MenuLogin.MostrarMenu();
        }
    }
}
