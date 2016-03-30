using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Entities;

namespace TodoList.DataAccess.Repositories
{
    public class DummyUserRepository : IUserRepository
    {
        private List<User> users = new List<User>();

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public IEnumerable<User> GetUsers()
        {
            return users;
        }

        public User GetUser(int id)
        {
            var index = id - 1;
            return users[index];
        }

        public void Save()
        {
            
        }
    }
}
