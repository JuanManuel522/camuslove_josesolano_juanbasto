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
            var perfiles = _repo.GetAllUsuarios().Where(u => u.Id != usuarioActual.Id).ToList();

            foreach (var perfil in perfiles)
            {
                Console.Clear();
                Console.WriteLine($"Nombre: {perfil.Nombre} | Edad: {perfil.Edad}");
                Console.WriteLine($"Carrera: {perfil.Carrera}");
                Console.WriteLine($"Intereses: {perfil.Intereses}");
                Console.WriteLine($"Frase: {perfil.FrasePerfil}");
                Console.WriteLine("====================");
                Console.WriteLine("1. Like  |  2. Dislike  |  3. Salir");
                Console.Write("Seleccione: ");
                string opcion = Console.ReadLine() ?? "3";

                if (opcion == "1")
                {
                    _matchService.DarLike(usuarioActual, perfil);
                    Console.WriteLine("💖 Like enviado!");
                }
                else if (opcion == "2")
                {
                    Console.WriteLine("❌ Dislike");
                }
                else if (opcion == "3")
                {
                    return;
                }

                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}