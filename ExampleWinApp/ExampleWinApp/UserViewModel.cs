using ExampleWinApp.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Entities;

namespace ExampleWinApp
{
    public class UserViewModel : BaseViewModel
    {
        public User User { get; private set; }

        public UserViewModel(User u)
        {
            Todos = new ObservableCollection<TodoViewModel>(u.Todos.Select(x => new TodoViewModel(x)));
            User = u;
        }

        public ObservableCollection<TodoViewModel> Todos
        {
            get;
            private set;
        }

        public void AddTodo(TodoViewModel todoVm)
        {
            Todos.Add(todoVm);
            User.Todos.Add(todoVm.Todo);
        }
    }
}
