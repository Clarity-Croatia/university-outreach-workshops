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
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<UserViewModel> _users;
        public ObservableCollection<UserViewModel> Users
        {
            get
            {
                return _users;
            }
            set
            {
                if (value != _users)
                {
                    _users = value;
                    NotifyPropertyChanged("Users");
                }
            }
        }
        
        // ZADATAK 1
        // SelectedUser is the user selected on the Users list (left list)

        public UserViewModel SelectedUser; // Zamijeniti ovaj red novim property-em
        

        public MainViewModel()
        {
            LoadAllUsers();
        }

        private RelayCommand _openAddUser;
        public RelayCommand OpenAddUser
        {
            get
            {
                if (_openAddUser == null)
                {
                    _openAddUser = new RelayCommand(q =>
                    {
                        var v = new AddUser();
                        var vm = new AddUserViewModel();

                        v.DataContext = vm;
                        v.ShowDialog();

                        LoadLastUser();
                    });
                }

                return _openAddUser;
            }
        }

        private RelayCommand _openAddTodo;
        public RelayCommand OpenAddTodo
        {
            get
            {
                if (_openAddTodo == null)
                {
                    _openAddTodo = new RelayCommand(q =>
                    {
                        var v = new AddEditTodo();
                        var vm = new AddEditTodoViewModel(SelectedUser);

                        v.DataContext = vm;
                        v.ShowDialog();
                    },
                    q =>
                    {
                        return SelectedUser != null;
                    });
                }

                return _openAddTodo;
            }
        }

        private RelayCommand _openEditTodo;
        public RelayCommand OpenEditTodo
        {
            get
            {
                if (_openEditTodo == null)
                {
                    // ZADATAK 3
                    // Use addEditTodo as example
                    // q is selected Todo item on the todo list (right list)
                    _openEditTodo = new RelayCommand(q =>
                    {
                        
                    });
                }

                return _openEditTodo;
            }
        }

        private void LoadLastUser()
        {
            var userVm = new UserViewModel(Globals.UserRepo.GetUsers().Last());
            Users.Add(userVm);
        }

        private void LoadAllUsers()
        {
            Users = new ObservableCollection<UserViewModel>(
                Globals.UserRepo
                .GetUsers()
                .Select(q => new UserViewModel(q)));
        }
    }
}
