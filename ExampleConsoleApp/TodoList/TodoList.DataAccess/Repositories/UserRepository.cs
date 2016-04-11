using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TodoList.Entities;
using TodoList.Entities.Repositories;

namespace TodoList.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DbContext _ctx;
        private DbSet<User> _users;

        public UserRepository(DbContext ctx)
        {
            _ctx = ctx;
            _users = _ctx.Set<User>();
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public User GetUser(int id)
        {
            return _users.Include(x => x.Todos).SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _users.Include(x => x.Todos);
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }
    }
}
