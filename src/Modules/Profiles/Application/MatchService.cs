using Modules.Profiles.Domain.Entities;
using Modules.Profiles.Domain.Interfaces;

namespace Modules.Profiles.Application.Services
{
    // Mi servicio que maneja toda la lógica de likes y matches
    // Lo separé en su propio servicio para mantener el código organizado
    public class MatchService
    {
        private readonly IUsuarioRepository _repository;

        // Recibo el repositorio por inyección para poder acceder a los usuarios
        public MatchService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        // Método principal para dar like a otro usuario
        public void DarLike(Usuario from, Usuario to)
        {
            // Primero valido que el usuario tenga likes disponibles
            if (from.LikesDisponibles <= 0) 
            {
                Console.WriteLine("❌ No tienes likes disponibles.");
                return;
            }

            // Verifico que no haya dado like ya a esta persona (evitar duplicados)
            if (from.LikesDados.Contains(to.Id))
            {
                Console.WriteLine("❌ Ya diste like a este perfil.");
                return;
            }

            // Proceso el like: actualizo las listas y contadores
            from.LikesDados.Add(to.Id); // Agrego el ID del usuario al que dió like
            from.LikesDisponibles--; // Le resto un like disponible
            to.LikesRecibidos.Add(from.Id); // Al otro usuario le agrego quien le dió like
            to.ContadorLikesRecibidos++; // Incremento su contador de likes recibidos

            // Guardo los cambios en el repositorio
            _repository.UpdateUsuario(from);
            _repository.UpdateUsuario(to);

            // Verifico si se formó un match (ambos se dieron like mutuamente)
            if (EsMatch(from.Id, to.Id))
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"🎉 ¡MATCH! Tú y {to.Nombre} se han gustado mutuamente!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("💖 Like enviado!");
            }
        }

        // Método que verifica si dos usuarios hicieron match
        public bool EsMatch(int userId, int otherId)
        {
            var user = _repository.GetUsuarioById(userId);
            var other = _repository.GetUsuarioById(otherId);
            
            // Es match si ambos usuarios se dieron like el uno al otro
            return user != null && other != null &&
                   user.LikesDados.Contains(otherId) &&
                   other.LikesDados.Contains(userId);
        }

        // Método que devuelve todos los matches de un usuario
        public List<Usuario> GetMatches(int usuarioId)
        {
            var usuario = _repository.GetUsuarioById(usuarioId);
            if (usuario == null) return new List<Usuario>(); // Si no existe el usuario, devuelvo lista vacía

            var matches = new List<Usuario>();
            var todosUsuarios = _repository.GetAllUsuarios();

            // Reviso cada usuario al que le dió like
            foreach (var idLiked in usuario.LikesDados)
            {
                var otro = todosUsuarios.FirstOrDefault(u => u.Id == idLiked);
                // Si ese usuario también le dió like de vuelta, es un match
                if (otro != null && otro.LikesDados.Contains(usuario.Id))
                {
                    matches.Add(otro);
                }
            }

            return matches;
        }
    }
}