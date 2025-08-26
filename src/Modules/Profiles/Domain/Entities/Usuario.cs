namespace Modules.Profiles.Domain.Entities
{
    // Mi clase Usuario que maneja todo - tanto el login como el perfil completo
    // Decidí unificar todo en una sola clase para que sea más fácil de manejar
    public class Usuario
    {
        // Propiedades básicas del usuario
        public int Id { get; set; } // ID único generado automáticamente
        public string Nombre { get; set; } = ""; // Nombre de usuario para login
        public string Contrasena { get; set; } = ""; // Contraseña para autenticarse
        
        // Información del perfil (se llena al registrarse o actualizar)
        public int Edad { get; set; }
        public string Genero { get; set; } = "";
        public string Carrera { get; set; } = "";
        public string Intereses { get; set; } = "";
        public string FrasePerfil { get; set; } = "";
        
        // Sistema de likes - cada usuario tiene 5 likes por día (podría ser configurable)
        public int LikesDisponibles { get; set; } = 5;
        
        // Listas para manejar los likes dados y recibidos
        public List<int> LikesDados { get; set; } = new(); // IDs de usuarios a los que dió like
        public List<int> LikesRecibidos { get; set; } = new(); // IDs de usuarios que le dieron like
        
        // Para llevar estadísticas más fácil
        public int ContadorLikesRecibidos { get; set; } = 0;

        // Constructor básico para cuando alguien solo se registra con usuario y contraseña
        public Usuario(string nombre, string contrasena)
        {
            Nombre = nombre;
            Contrasena = contrasena;
        }

        // Constructor completo para cuando tengo todos los datos del perfil
        public Usuario(int id, string nombre, string contrasena, int edad, string genero, 
                      string carrera, string intereses, string frasePerfil)
        {
            Id = id;
            Nombre = nombre;
            Contrasena = contrasena;
            Edad = edad;
            Genero = genero;
            Carrera = carrera;
            Intereses = intereses;
            FrasePerfil = frasePerfil;
        }

        // Constructor vacío por si lo necesito en algún momento
        public Usuario() { }
    }
}