using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Entities;

namespace ExampleWinApp.Storage
{
    public class ToDoListDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Todo> Todos { get; set; }

        public ToDoListDBContext()
            : base("TodoContext")
        {

        }
    }
}
