using ExampleWinApp.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Entities;

namespace ExampleWinApp
{
    public class AddUserViewModel : BaseViewModel
    {
        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (value != _firstName)
                {
                    _firstName = value;
                    NotifyPropertyChanged("FirstName");
                }
            }
        }

        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (value != _lastName)
                {
                    _lastName = value;
                    NotifyPropertyChanged("LastName");
                }
            }
        }

        private RelayCommand _addUser;
        public RelayCommand AddUser
        {
            get
            {
                if (_addUser == null)
                {
                    _addUser = new RelayCommand(q =>
                    {
                        Globals.UserRepo.AddUser(new User(FirstName, LastName));
                        Globals.UserRepo.Save();
                    },
                    q =>
                    {
                        return !string.IsNullOrEmpty(FirstName) && 
                            !string.IsNullOrEmpty(LastName);
                    });
                }

                return _addUser;
            }
        }
    }
}
