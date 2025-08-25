namespace Modules.Profiles.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public int Edad { get; set; }
        public string Genero { get; set; } = "";
        public string Carrera { get; set; } = "";
        public string Intereses { get; set; } = "";
        public string FrasePerfil { get; set; } = "";

        // Créditos diarios (ejemplo: 5 likes por día)
        public int LikesDisponibles { get; set; } = 5;

        // Para estadísticas
        public int LikesRecibidos { get; set; } = 0;
    }
}
