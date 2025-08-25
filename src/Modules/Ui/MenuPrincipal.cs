using System;

namespace Modules.Ui
{
    public class MenuPrincipal
    {
        public void MostrarMenuPrincipal()
        {
            do
            {
                int opcion;
                Console.Clear();
                Console.WriteLine("======================");
                Console.WriteLine("====MENU PRINCIPAL====");
                Console.WriteLine("======================");
                Console.WriteLine("1. Ver Perfiles");
                Console.WriteLine("2. Ver Mis Coincidencias");
                Console.WriteLine("3. Ver Estadisticas");
                Console.WriteLine("4. Salir");
                Console.WriteLine("======================");
                Console.Write("Seleccione: ");
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción inválida\nPresione una tecla para reintentar...");
                    Console.ReadKey();
                    continue;
                }
                switch (opcion)
                {
                    case 1:
                        // Lógica para ver perfiles
                        Console.WriteLine("Mostrando Perfiles...");
                        break;
                    case 2:
                        // Lógica para ver coincidencias
                        Console.WriteLine("Mostrando Mis Coincidencias...");
                        break;
                    case 3:
                        // Lógica para ver estadísticas
                        Console.WriteLine("Mostrando Estadísticas...");
                        break;
                    case 4:
                        Console.WriteLine("Saliendo...");
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }

                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                
            } while (true);
        }
    }
}
