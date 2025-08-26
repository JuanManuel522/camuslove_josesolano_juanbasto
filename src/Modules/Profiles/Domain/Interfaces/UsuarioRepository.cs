using Modules.Profiles.Domain.Entities;
using Modules.Profiles.Domain.Interfaces;

namespace Modules.Profiles.Infrastructure
{
    // Mi implementación del repositorio - aquí manejo todos los usuarios en memoria
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly List<Usuario> usuarios = new(); // Lista donde guardo todos los usuarios
        private int nextId = 1; // Para generar IDs únicos automáticamente

        public UsuarioRepository()
        {
            // En cuanto se crea el repositorio, cargo los datos de ejemplo
            LoadFromDatabase();
        }

        // Método que simula cargar datos desde una base de datos
        // Pongo usuarios de ejemplo con perfiles completos para probar
        public void LoadFromDatabase()
        {
            usuarios.AddRange(new List<Usuario>
            {
                new Usuario(1, "Maria", "pass123", 22, "F", "Ingeniería de Sistemas", 
                          "Videojuegos, Música", "Buscando bugs en corazones 💻❤️"),
                new Usuario(2, "Juan", "pass123", 24, "M", "Diseño Gráfico", 
                          "Arte, Cine", "Un match y te diseño el futuro 🎨"),
                new Usuario(3, "Laura", "pass123", 21, "F", "Psicología", 
                          "Lectura, Café", "Te escucho con el corazón ☕📚"),
                new Usuario(4, "Carlos", "pass123", 23, "M", "Medicina", 
                          "Deportes, Series", "El mejor remedio: una buena cita 🩺🍿"),
                new Usuario(5, "Andrea", "pass123", 22, "F", "Derecho", 
                          "Debates, Viajes", "Argumenta tu amor 💼✈️"),
                new Usuario(6, "Luis", "pass123", 25, "M", "Administración", 
                          "Finanzas, Ajedrez", "Invertir en amor, la mejor decisión 💰♟️")
            });
            
            // Actualizo el contador para que los nuevos usuarios tengan IDs únicos
            nextId = usuarios.Max(u => u.Id) + 1;
        }

        // Agregar un usuario nuevo al sistema
        public void AddUsuario(Usuario usuario)
        {
            usuario.Id = nextId++; // Le asigno un ID único
            usuarios.Add(usuario); // Lo agrego a mi lista
        }

        // Devuelvo todos los usuarios (hago una copia para no modificar la original)
        public List<Usuario> GetAllUsuarios()
        {
            return usuarios.ToList();
        }

        // Busco un usuario específico por su ID
        public Usuario? GetUsuarioById(int id)
        {
            return usuarios.FirstOrDefault(u => u.Id == id);
        }

        // Busco un usuario por su nombre (útil para el login)
        public Usuario? GetUsuarioByNombre(string nombre)
        {
            return usuarios.FirstOrDefault(u => u.Nombre == nombre);
        }

        // Actualizo los datos de un usuario existente
        public void UpdateUsuario(Usuario usuario)
        {
            var existente = GetUsuarioById(usuario.Id);
            if (existente != null)
            {
                int index = usuarios.IndexOf(existente);
                usuarios[index] = usuario; // Reemplazo el usuario en la lista
            }
        }
    }
}
