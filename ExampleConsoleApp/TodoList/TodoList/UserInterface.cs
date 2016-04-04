using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Entities;

namespace TodoList
{
    public class UserInterface
    {
        private IUserRepository _userRepository;
        private int? _selectedUserIndex = null;

        public UserInterface(IUserRepository ur)
        {
            _userRepository = ur;
        }

        public void Draw()
        {
            Console.Clear();

            Console.WriteLine("Users:");
            Console.WriteLine();

            var i = 0;
            foreach(var u in _userRepository.GetUsers())
            {
                Console.WriteLine($"{i}\t{u.FirstName} {u.LastName}");
                if(_selectedUserIndex.HasValue && i == _selectedUserIndex.Value)
                {
                    ShowTodos(u);
                }

                i++; 
            }

            if (_selectedUserIndex.HasValue)
            {
                AddOrUpdateTodo();
            }
            else
            {
                AddOrSelectUser();
            }
        }

        private void AddOrUpdateTodo()
        {
            var user = _userRepository.GetUser(_selectedUserIndex.Value);            

            Console.WriteLine();
            Console.WriteLine("Add (a) todo or update state (id):");
            var viewOrAdd = Console.ReadKey();

            if (viewOrAdd.Key == ConsoleKey.Escape)
            {
                _selectedUserIndex = null;
                return;
            }
            else if (viewOrAdd.KeyChar == 'a')
            {
                AddTodo(user);
            }
            else
            {
                var todoIndex = int.Parse(viewOrAdd.KeyChar.ToString());
                user.Todos[todoIndex].UpdateStatus();
            }
        }
           
        private static void AddTodo(User user)
        {
            Console.WriteLine();
            Console.WriteLine("Add Todo message:");
            var message = Console.ReadLine();

            user.Todos.Add(new Todo(message));
        }

        private void AddUser()
        {
            Console.WriteLine();
            Console.WriteLine("Enter firsname and lastname:");
            var fnameLname = Console.ReadLine();

            var name = fnameLname.Split(' ');
            var user = new User(name[0], name[1]);

            _userRepository.AddUser(user);
        }

        private void AddOrSelectUser()
        {
            Console.WriteLine();
            Console.WriteLine("Add user (a) or select user (id):");
            var viewOrAdd = Console.ReadKey();

            if (viewOrAdd.Key == ConsoleKey.Escape)
            {
                _selectedUserIndex = null;
            }
            else if (viewOrAdd.KeyChar == 'a')
            {
                AddUser();
            }
            else
            {
                var userIndex = int.Parse(viewOrAdd.KeyChar.ToString());
                _selectedUserIndex = userIndex;
            }
        }

        private void ShowTodos(User user)
        {
            var i = 0;

            Console.WriteLine("\tIndex\tMessage\t\tStatus\t\tCreated\t\t\tStarted\t\t\tFinished");
            foreach (var t in user.Todos)
            {
                Console.WriteLine($"\t{i}\t{t.Message}\t{t.DisplayStatus}\t\t{t.DateCreated}\t{t.DateStarted}\t{t.DateFinished}");
                i++;
            }
            Console.WriteLine();
        }
    }
}
