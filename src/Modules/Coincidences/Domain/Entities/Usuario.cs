namespace Modules.Profiles.Domain.Entities
{
    public class UsuarioPerfil
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public int Edad { get; set; }

        // Likes que este usuario dio
        public List<int> LikesDados { get; set; } = new();

        // Likes que este usuario recibió
        public List<int> LikesRecibidos { get; set; } = new();
    }
}