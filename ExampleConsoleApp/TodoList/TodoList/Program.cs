using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.DataAccess.Repositories;
using TodoList.Entities;

namespace TodoList
{
    class Program
    {
        static IUserRepository _ur;
        static bool _stop = false;

        static void Main(string[] args)
        {
            _ur = new DummyUserRepository();
            do
            {
                try {
                    Console.WriteLine("\n\nView users or add users (v/a):");
                    var viewOrAdd = Console.ReadKey().KeyChar;

                    if (viewOrAdd == 'v')
                    {
                        ViewUsers();
                    }
                    else if (viewOrAdd == 'a')
                    {
                        AddUser();
                        ViewUsers();
                    }

                    Console.WriteLine("\n\nContinue (y/n):");
                    if (Console.ReadKey().KeyChar == 'n')
                    {
                        _stop = true;
                    }
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\n\nError: {e.Message}");
                }

            } while (!_stop);
        }

        private static void AddUser()
        {
            Console.WriteLine("\n\nEnter firsname and lastname:");
            var fnameLname = Console.ReadLine();

            var name = fnameLname.Split(' ');
            var user = new User(name[0], name[1]);

            _ur.AddUser(user);
        }

        private static void ViewUsers()
        {
            ShowUsers();

            Console.WriteLine("\n\nSelect User:");
            var userId = Console.ReadKey().KeyChar;

            var user = _ur.GetUser(int.Parse(userId.ToString()));
            ShowUser(user);
        }

        private static void ShowUser(User user)
        {
            ShowTodos(user);

            Console.WriteLine("\n\nAdd or update todo (a/u):");
            var addOrUpdate = Console.ReadKey().KeyChar;

            if (addOrUpdate == 'u')
            {
                UpdateTodo(user);
                ShowUser(user);
            }
            else if (addOrUpdate == 'a')
            {
                AddTodo(user);
                ShowUser(user);
            }
            else
            {
                return;
            }
        }

        private static void AddTodo(User user)
        {
            Console.WriteLine("\n\nAdd Todo message:");
            var message = Console.ReadLine();

            user.Todos.Add(new Todo(message));
        }

        private static void UpdateTodo(User user)
        {
            Console.WriteLine("\n\nUpdate Todo id:");
            var todoIdChar = Console.ReadKey().KeyChar;
            var todoId = int.Parse(todoIdChar.ToString()) - 1;

            var todo = user.Todos[todoId];
            todo.UpdateStatus();
        }

        private static void ShowTodos(User user)
        {
            var i = 1;

            Console.WriteLine($"\n{user.FirstName} {user.LastName}'s todo list:");
            foreach (var t in user.Todos)
            {
                Console.WriteLine($"{i} {t.Message} {t.DisplayStatus} Created: {t.DateCreated} Started: {t.DateStarted} Finished: {t.DateFinished}");
                i++;
            }
        }

        private static void ShowUsers()
        {
            var users = _ur.GetUsers();
            var i = 1;
            Console.WriteLine();
            foreach(var u in users)
            {
                Console.WriteLine($"{i} {u.FirstName} {u.LastName}");
                i++;
            }
        }
    }
}
