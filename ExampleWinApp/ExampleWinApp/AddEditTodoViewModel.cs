using ExampleWinApp.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Entities;

namespace ExampleWinApp
{
    public class AddEditTodoViewModel : BaseViewModel
    {
        private TodoViewModel _todo = null;
        private UserViewModel _uvm = null;
        
        
        public AddEditTodoViewModel(UserViewModel uvm)
        {
            _uvm = uvm;
        }

        public AddEditTodoViewModel(UserViewModel uvm, TodoViewModel todo)
        {
            _uvm = uvm;
            _todo = todo;

            TodoText = _todo.Message;
        }
        
        private string _todoText;
        public string TodoText
        {
            get
            {
                return _todoText;
            }
            set
            {
                if (value != _todoText)
                {
                    _todoText = value;
                    NotifyPropertyChanged("TodoText");
                }
            }
        }

        public string ButtonTitle
        {
            get
            {
                return (_todo == null)
                    ? "Add Todo"
                    : "Edit Todo";
            }
        }

        private RelayCommand _addEditTodo;
        public RelayCommand AddEditTodo
        {
            get
            {
                if (_addEditTodo == null)
                {
                    _addEditTodo = new RelayCommand(q =>
                    {
                        // ZADATAK 2
                    },
                    q =>
                    {
                        return !string.IsNullOrEmpty(TodoText);
                    });
                }

                return _addEditTodo;
            }
        }
    }
}
