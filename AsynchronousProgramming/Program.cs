using System;

namespace AsynchronousProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            var login = new Login();

            login.StartLogin();

            Console.ReadLine();
        }
    }
}
