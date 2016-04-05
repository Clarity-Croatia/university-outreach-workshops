using System.Collections.Generic;

namespace TodoList.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public virtual IList<Todo> Todos { get; set; }

        // EntityFramework requires a parameterless ctor
        private User()
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
