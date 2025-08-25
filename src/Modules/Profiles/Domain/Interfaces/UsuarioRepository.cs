using Modules.Profiles.Domain.Entities;
using Modules.Profiles.Domain.Interfaces;

namespace Modules.Profiles.Infrastructure
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly List<Usuario> usuarios = new();

        public void AddUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        public List<Usuario> GetAllUsuarios()
        {
            return usuarios;
        }

        public Usuario? GetUsuarioById(int id)
        {
            return usuarios.FirstOrDefault(u => u.Id == id);
        }
    }
}
