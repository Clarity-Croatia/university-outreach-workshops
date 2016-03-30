using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Entities
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(int id);
        void AddUser(User user);
        void Save();
    }
}
