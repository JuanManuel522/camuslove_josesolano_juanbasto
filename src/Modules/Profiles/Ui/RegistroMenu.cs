using Modules.Profiles.Application.Factories;
using Modules.Profiles.Domain.Entities;
using Modules.Profiles.Domain.Interfaces;

namespace Modules.Profiles.Ui
{
    public class RegistroMenu
    {
        private readonly IUsuarioRepository _repo;

        public RegistroMenu(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        public void Registrar()
        {
            Console.Clear();
            Console.WriteLine("=== Registro de Usuario ===");

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine() ?? "";

            Console.Write("Edad: ");
            int edad = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Género: ");
            string genero = Console.ReadLine() ?? "";

            Console.Write("Carrera: ");
            string carrera = Console.ReadLine() ?? "";

            Console.Write("Intereses: ");
            string intereses = Console.ReadLine() ?? "";

            Console.Write("Frase de perfil: ");
            string frase = Console.ReadLine() ?? "";

            Usuario nuevo = UsuarioFactory.CrearUsuario(nombre, edad, genero, carrera, intereses, frase);
            _repo.AddUsuario(nuevo);

            Console.WriteLine("✅ Usuario registrado con éxito!");
            Console.ReadKey();
        }
    }
}