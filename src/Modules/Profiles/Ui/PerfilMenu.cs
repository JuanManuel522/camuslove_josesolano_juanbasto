using Modules.Profiles.Application.Services;
using Modules.Profiles.Domain.Entities;
using Modules.Profiles.Domain.Interfaces;

namespace Modules.Profiles.Ui
{
    public class PerfilMenu
    {
        private readonly IUsuarioRepository _repo;
        private readonly MatchService _matchService;

        public PerfilMenu(IUsuarioRepository repo, MatchService matchService)
        {
            _repo = repo;
            _matchService = matchService;
        }

        public void MostrarPerfiles(Usuario usuarioActual)
        {
            var perfiles = _repo.GetAllUsuarios()
                .Where(u => u.Id != usuarioActual.Id && u.Edad > 0) // Solo perfiles completos
                .ToList();

            if (perfiles.Count == 0)
            {
                Console.WriteLine("No hay más perfiles disponibles.");
                return;
            }

            foreach (var perfil in perfiles)
            {
                // Skip si ya dio like
                if (usuarioActual.LikesDados.Contains(perfil.Id))
                    continue;

                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════╗");
                Console.WriteLine($"║ {perfil.Nombre.PadRight(32)} ║");
                Console.WriteLine($"║ {perfil.Edad} años - {perfil.Genero.PadRight(26)} ║");
                Console.WriteLine("╠══════════════════════════════════╣");
                Console.WriteLine($"║ Carrera: {perfil.Carrera.PadRight(23)} ║");
                Console.WriteLine($"║ Intereses: {perfil.Intereses.PadRight(21)} ║");
                Console.WriteLine("╠══════════════════════════════════╣");
                Console.WriteLine($"║ \"{perfil.FrasePerfil}\"".PadRight(35) + "║");
                Console.WriteLine("╚══════════════════════════════════╝");
                Console.WriteLine();
                Console.WriteLine("1. ❤️ Like  |  2. ❌ Dislike  |  3. 🚪 Salir");
                Console.Write("Seleccione: ");
                
                string opcion = Console.ReadLine() ?? "3";

                if (opcion == "1")
                {
                    _matchService.DarLike(usuarioActual, perfil);
                }
                else if (opcion == "2")
                {
                    Console.WriteLine("❌ Perfil rechazado");
                }
                else if (opcion == "3")
                {
                    return;
                }

                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            }

            Console.WriteLine("Has visto todos los perfiles disponibles.");
        }
    }
}