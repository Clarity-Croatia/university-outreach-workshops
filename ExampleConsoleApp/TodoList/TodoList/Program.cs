using System;
using TodoList.DataAccess.Context;
using TodoList.DataAccess.Repositories;
using TodoList.Entities.Repositories;

namespace TodoList
{
    class Program
    {

        static void Main(string[] args)
        {
            IUserRepository repo = new InMemoryUserRepository();

            // uncomment this line to replace the in-mem repo with db repo
            //repo = new UserRepository(new TodoContext());

            var ui = new UserInterface(repo);

            while (true)
            {
                try
                {
                    ui.Draw();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\n\nError: {e.Message}");
                    Console.WriteLine($"Press any key to continue");
                    Console.ReadKey();
                }

            };

        }
    }
}
