using Modules.Profiles.Domain.Entities;

namespace Modules.Profiles.Domain.Interfaces
{
    // Mi interfaz que define qué operaciones puedo hacer con los usuarios
    // La hago como interfaz para que sea más profesional y fácil de testear después
    public interface IUsuarioRepository
    {
        void AddUsuario(Usuario usuario); // Agregar un usuario nuevo
        List<Usuario> GetAllUsuarios(); // Obtener todos los usuarios registrados
        Usuario? GetUsuarioById(int id); // Buscar usuario por su ID
        Usuario? GetUsuarioByNombre(string nombre); // Buscar usuario por nombre (para login)
        void UpdateUsuario(Usuario usuario); // Actualizar datos de un usuario
        void LoadFromDatabase(); // Cargar datos iniciales (simulando base de datos)
    }
}