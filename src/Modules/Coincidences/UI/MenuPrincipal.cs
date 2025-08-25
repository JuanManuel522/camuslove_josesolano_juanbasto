using Modules.Profiles.Domain.Entities;
using Modules.Profiles.Application;

namespace Modules.Ui
{
    public class MenuCoincidencias
    {
        private readonly List<UsuarioPerfil> usuarios = new();
        private readonly MatchService matchService;

        private int usuarioActivoId = 1; // Simulación: usuario en sesión

        public MenuCoincidencias()
        {
            // Datos de ejemplo
            usuarios.Add(new UsuarioPerfil { Id = 1, Nombre = "Ana", Edad = 20 });
            usuarios.Add(new UsuarioPerfil { Id = 2, Nombre = "Luis", Edad = 22 });
            usuarios.Add(new UsuarioPerfil { Id = 3, Nombre = "Sofía", Edad = 21 });

            // Likes de ejemplo
            usuarios.First(u => u.Id == 1).LikesDados.Add(2); // Ana → Luis
            usuarios.First(u => u.Id == 2).LikesDados.Add(1); // Luis → Ana (Match)

            usuarios.First(u => u.Id == 3).LikesDados.Add(1); // Sofía → Ana (no match aún)

            // Inyectamos lista de usuarios al servicio
            matchService = new MatchService(usuarios);
        }

        public void Show()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=== MENÚ CAMPUS LOVE ===");
                Console.WriteLine("1. Ver Mis Coincidencias");
                Console.WriteLine("2. Salir");
                Console.Write("Seleccione: ");

                if (!int.TryParse(Console.ReadLine(), out opcion)) continue;

                switch (opcion)
                {
                    case 1:
                        VerCoincidencias();
                        break;
                    case 2:
                        return;
                }

            } while (true);
        }

        private void VerCoincidencias()
        {
            var matches = matchService.GetMatches(usuarioActivoId);

            Console.Clear();
            Console.WriteLine("=== MIS COINCIDENCIAS ===");

            if (matches.Count == 0)
            {
                Console.WriteLine("No tienes coincidencias aún.");
            }
            else
            {
                foreach (var match in matches)
                {
                    Console.WriteLine($"💘 {match.Nombre}, {match.Edad} años");
                }
            }

            Console.WriteLine("\nPresiona una tecla para volver...");
            Console.ReadKey();
        }
    }
}
