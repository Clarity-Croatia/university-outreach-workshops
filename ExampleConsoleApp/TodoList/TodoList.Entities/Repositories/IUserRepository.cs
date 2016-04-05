using System.Collections.Generic;

namespace TodoList.Entities.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(int id);
        void AddUser(User user);
        void Save();
    }
}
