using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Entities
{
    public class User
    {
        public int Id { get; set; }
        [MinLength(2)]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual IList<Todo> Todos { get; set; }

        // EntityFramework requires a parameterless ctor
        public User()
        {

        }

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Todos = new List<Todo>();
        }
    }
}
