using ExampleWinApp.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TodoList.Entities;

namespace ExampleWinApp
{
    public class TodoViewModel : BaseViewModel
    {
        public Todo Todo { get; private set; }
        public TodoViewModel(Todo todo)
        {
            Todo = todo;
        }

        public TodoViewModel(string message)
        {
            Todo = new Todo(message);
        }

        public string Status
        {
            get { return Todo.DisplayStatus; }
        }

        // ZADATAK 4: Dodati DateFinished property, Status property je primjer
        
        public string Message
        {
            get { return Todo.Message; }
            set
            {
                if (Todo.Message != value)
                {
                    Todo.Message = value;
                    NotifyPropertyChanged("Message");
                }
            }
        }

        private RelayCommand _updateTodo;
        public RelayCommand UpdateTodo
        {
            get
            {
                if (_updateTodo == null)
                {
                    // ZADATAK 4
                    _updateTodo = new RelayCommand(q => {
                        Todo.UpdateStatus();
                        NotifyPropertyChanged("Status");
                        // TODO: on update notifypropchg "DateFinished"
                        Globals.UserRepo.Save();
                    });
                }

                return _updateTodo;
            }
        }
        
    }
}
