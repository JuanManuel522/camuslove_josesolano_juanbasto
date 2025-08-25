using System;

namespace YourNamespace
{
    class MenuLogin
    {
        public void Display()
        {
            Console.WriteLine("Welcome to the Login Menu");
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            // Here you can add logic to validate the username and password
            Console.WriteLine($"Welcome, {username}!");
        }
    }
}
