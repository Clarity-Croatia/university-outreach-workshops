using System.Collections.Generic;
using TodoList.Entities;
using TodoList.Entities.Repositories;

namespace TodoList
{ 
    public class InMemoryUserRepository : IUserRepository
    {
        private List<User> users = new List<User>();

        public void AddUser(User user)
        {
            // ugly reflection to create a fake id which is private
            user.GetType()
                .GetProperty("Id")
                .SetValue(user, users.Count);

            users.Add(user);
        }

        public IEnumerable<User> GetUsers()
        {
            return users;
        }

        public User GetUser(int id)
        {
            return users[id];
        }

        public void Save()
        {
            
        }
    }
}
