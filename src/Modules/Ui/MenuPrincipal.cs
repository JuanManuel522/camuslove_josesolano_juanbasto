using System;
using Modules.Profiles.Domain.Interfaces;
using Modules.Profiles.Application.Services;
using Modules.Profiles.Ui;

namespace Modules.Ui
{
    public class MenuPrincipal
    {
        private readonly IUsuarioRepository _repository;
        private readonly MatchService _matchService;
        private readonly PerfilMenu _perfilMenu;

        public MenuPrincipal(IUsuarioRepository repository)
        {
            _repository = repository;
            _matchService = new MatchService(_repository);
            _perfilMenu = new PerfilMenu(_repository, _matchService);
        }

        public void MostrarMenuPrincipal()
        {
            do
            {
                int opcion;
                Console.Clear();
                Console.WriteLine("======================");
                Console.WriteLine("====MENU PRINCIPAL====");
                Console.WriteLine("======================");
                Console.WriteLine($"Usuario: {MenuLogin.UsuarioActual?.Nombre}");
                Console.WriteLine($"Likes disponibles: {MenuLogin.UsuarioActual?.LikesDisponibles}");
                Console.WriteLine("======================");
                Console.WriteLine("1. Ver Perfiles");
                Console.WriteLine("2. Ver Mis Coincidencias");
                Console.WriteLine("3. Ver Estadísticas");
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
                        if (MenuLogin.UsuarioActual != null)
                            _perfilMenu.MostrarPerfiles(MenuLogin.UsuarioActual);
                        break;
                    case 2:
                        MostrarCoincidencias();
                        break;
                    case 3:
                        MostrarEstadisticas();
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

        private void MostrarCoincidencias()
        {
            if (MenuLogin.UsuarioActual == null) return;

            var matches = _matchService.GetMatches(MenuLogin.UsuarioActual.Id);

            Console.Clear();
            Console.WriteLine("=== MIS COINCIDENCIAS ===");

            if (matches.Count == 0)
            {
                Console.WriteLine("No tienes coincidencias aún. ¡Sigue dando likes! 💖");
            }
            else
            {
                foreach (var match in matches)
                {
                    Console.WriteLine($"💘 {match.Nombre}, {match.Edad} años");
                    Console.WriteLine($"   Carrera: {match.Carrera}");
                    Console.WriteLine($"   {match.FrasePerfil}");
                    Console.WriteLine("   ─────────────────");
                }
            }
        }

        private void MostrarEstadisticas()
        {
            if (MenuLogin.UsuarioActual == null) return;

            var usuario = MenuLogin.UsuarioActual;
            var matches = _matchService.GetMatches(usuario.Id);

            Console.Clear();
            Console.WriteLine("=== MIS ESTADÍSTICAS ===");
            Console.WriteLine($"📊 Likes dados: {usuario.LikesDados.Count}");
            Console.WriteLine($"❤️ Likes recibidos: {usuario.ContadorLikesRecibidos}");
            Console.WriteLine($"💖 Matches: {matches.Count}");
            Console.WriteLine($"⚡ Likes disponibles: {usuario.LikesDisponibles}");
        }
    }
}