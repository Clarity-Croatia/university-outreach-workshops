using System;
using System.Collections.Generic;
using TodoList.Entities;
using TodoList.Entities.Repositories;

namespace TodoList
{
    public class UserInterface
    {
        private IUserRepository _userRepository;
        private User _selectedUser = null;
        private IEnumerable<User> users;

        public UserInterface(IUserRepository ur)
        {
            _userRepository = ur;
            users = _userRepository.GetUsers();
        }

        public void Draw()
        {
            Console.Clear();

            ListUsers();

            if (_selectedUser != null)
            {
                AddOrUpdateTodo();
            }
            else
            {
                AddOrSelectUser();
            }

            _userRepository.Save();
        }

        private void ListUsers()
        {
            WriteRow("Id","First Name","Last Name");
            foreach (var u in users)
            {
                WriteRow(u.Id, u.FirstName, u.LastName);
                if (_selectedUser != null && _selectedUser.Id == u.Id)
                {
                    ShowTodos();
                }
            }
        }

        private void AddOrUpdateTodo()
        {
            Console.WriteLine();
            Console.Write("Add (a) todo or update state (index): ");
            var key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    HideTodos();
                    break;
                case ConsoleKey.A:
                    AddTodo();
                    break;
                default:
                    try
                    {
                        var todoIndex = int.Parse(key.KeyChar.ToString());
                        _selectedUser.Todos[todoIndex].UpdateStatus();
                    }
                    catch
                    {
                        throw new Exception("Entered todo index was not a valid number");
                    }
                    
                    break;
            }
        }
           
        private void AddTodo()
        {
            Console.WriteLine();
            Console.Write("Add Todo message: ");
            var message = Console.ReadLine();

            _selectedUser.Todos.Add(new Todo(message));
        }

        private void AddUser()
        {
            Console.WriteLine();
            Console.Write("First name: ");
            var fname = Console.ReadLine();
            Console.Write("Last name: ");
            var lname = Console.ReadLine();

            var user = new User(fname, lname);
            _userRepository.AddUser(user);
        }

        private void AddOrSelectUser()
        {
            Console.WriteLine();
            Console.Write("Add user (a) or select user (id): ");
            var key = Console.ReadKey();


            switch (key.Key)
            {
                case ConsoleKey.A:
                    AddUser();
                    break;
                default:
                    try
                    {
                        var selectedId = int.Parse(key.KeyChar.ToString());
                        _selectedUser = _userRepository.GetUser(selectedId);

                        if(_selectedUser == null)
                        {
                            throw new Exception();
                        }
                    }
                    catch
                    {
                        throw new Exception("Entered user id was not a valid number");
                    }

                    break;
            }
        }

        private void ShowTodos()
        {
            var todoIndex = 0;

            Console.WriteLine("TODOS: ------------------");
            Console.Write("\t");
            WriteRow("Index", "Message", "Status", "Created", "Started", "Finished");
            foreach (var t in _selectedUser.Todos)
            {
                Console.Write("\t");
                WriteRow(todoIndex, t.Message, t.DisplayStatus, t.DateCreated.ToLongTimeString(), t.DateStarted?.ToLongTimeString(), t.DateFinished?.ToLongTimeString());
                todoIndex++;
            }
            Console.WriteLine("------------------------");
            Console.WriteLine();
        }        

        private void HideTodos()
        {
            _selectedUser = null;
        }

        private void WriteRow(params object[] columns)
        {
            var colLength = 10;
            var returnStr = "";
            foreach (var obj in columns)
            {
                var str = (obj ?? "").ToString();
                if (str.Length > colLength)
                {
                    str = str.Substring(0, colLength - 3) + "...";
                }

                returnStr += str.PadRight(colLength + 2, ' ');
            }
            Console.WriteLine(returnStr);
        }
    }
}
