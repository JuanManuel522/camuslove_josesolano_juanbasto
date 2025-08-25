using Modules.Profiles.Domain.Entities;

namespace Modules.Profiles.Application.Factories
{
    public static class UsuarioFactory
    {
        private static int _idCounter = 1;

        public static Usuario CrearUsuario(string nombre, int edad, string genero, string carrera, string intereses, string frasePerfil)
        {
            return new Usuario
            {
                Id = _idCounter++,
                Nombre = nombre,
                Edad = edad,
                Genero = genero,
                Carrera = carrera,
                Intereses = intereses,
                FrasePerfil = frasePerfil
            };
        }
    }
}
