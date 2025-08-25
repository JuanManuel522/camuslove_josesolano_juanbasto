using Modules.Profiles.Domain.Entities;

namespace Modules.Profiles.Application.Services
{
    public class MatchService
    {
        // Diccionario: Usuario -> lista de usuarios a los que dio like
        private readonly Dictionary<int, List<int>> _likes = new();

        public void DarLike(Usuario from, Usuario to)
        {
            if (from.LikesDisponibles <= 0) return;

            if (!_likes.ContainsKey(from.Id))
                _likes[from.Id] = new List<int>();

            _likes[from.Id].Add(to.Id);
            from.LikesDisponibles--;
            to.LikesRecibidos++;
        }

        public bool EsMatch(int userId, int otherId)
        {
            return _likes.ContainsKey(userId) && _likes[userId].Contains(otherId)
                && _likes.ContainsKey(otherId) && _likes[otherId].Contains(userId);
        }

        public List<(Usuario, Usuario)> ObtenerMatches(List<Usuario> usuarios)
        {
            var matches = new List<(Usuario, Usuario)>();
            foreach (var u in usuarios)
            {
                foreach (var v in usuarios)
                {
                    if (u.Id != v.Id && EsMatch(u.Id, v.Id))
                        matches.Add((u, v));
                }
            }
            return matches.Distinct().ToList();
        }
    }
}
