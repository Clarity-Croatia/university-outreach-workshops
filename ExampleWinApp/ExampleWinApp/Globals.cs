using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.DataAccess.Context;
using TodoList.DataAccess.Repositories;

namespace ExampleWinApp
{
    public static class Globals
    {
        private static UserRepository _userRepo;

        public static UserRepository UserRepo
        {
            get
            {
                if (_userRepo == null)
                {
                    _userRepo = new UserRepository(new TodoContext());
                }

                return _userRepo;
            }
        }
    }
}
