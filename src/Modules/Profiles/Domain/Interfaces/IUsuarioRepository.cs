using Modules.Profiles.Domain.Entities;

namespace Modules.Profiles.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        void AddUsuario(Usuario usuario);
        List<Usuario> GetAllUsuarios();
        Usuario? GetUsuarioById(int id);
    }
}
