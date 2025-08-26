using Modules.Profiles.Domain.Entities;

namespace Modules.Profiles.Application
{
    public class MatchService
    {
        private readonly List<UsuarioPerfil> _usuarios;

        public MatchService(List<UsuarioPerfil> usuarios)
        {
            _usuarios = usuarios;
        }

        // Devuelve la lista de coincidencias de un usuario
        public List<UsuarioPerfil> GetMatches(int usuarioId)
        {
            var usuario = _usuarios.FirstOrDefault(u => u.Id == usuarioId);
            if (usuario == null) return new List<UsuarioPerfil>();

            var matches = new List<UsuarioPerfil>();

            foreach (var idLiked in usuario.LikesDados)
            {
                var otro = _usuarios.FirstOrDefault(u => u.Id == idLiked);
                if (otro != null && otro.LikesDados.Contains(usuario.Id))
                {
                    matches.Add(otro);
                }
            }

            return matches;
        }
    }
}