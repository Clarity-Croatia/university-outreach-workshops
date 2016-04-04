using System;
using TodoList.DataAccess.Repositories;
using TodoList.Entities;

namespace TodoList
{
    class Program
    {
static UserInterface ui = new UserInterface(new DummyUserRepository());

        static void Main(string[] args)
        {
            while(true)
            {
                try {

                    ui.Draw();
                    Console.WriteLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\n\nError: {e.Message}");
                }

            };
        }       
    }
}
