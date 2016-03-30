using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TodoList.Entities;

namespace TodoList.DataAccess.Context
{
    public class TodoContext : DbContext
    {
        public DbSet<User> Users {get;set;}
        public DbSet<Todo> Todos { get; set; }

        public TodoContext() : base("TodoContext")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder
                .Types()
                .Configure(c =>
                {
                    c.ClrType
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Instance)
                    .ToList()
                    .ForEach(p => c.Property(p).HasColumnName(p.Name));
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
