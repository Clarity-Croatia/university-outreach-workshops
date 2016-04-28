using System;

namespace TodoList.Entities
{
    public class Todo
    {
        public int Id { get; private set; }
        public string Message { get; set; }

        private Status Status { get; set; }
        public string DisplayStatus { get { return Status.ToString(); } }

        public DateTime DateCreated { get; private set; }
        public DateTime? DateStarted { get; private set; }
        public DateTime? DateFinished { get; private set; }

        // EntityFramework requires a parameterless ctor
        private Todo()
        {

        }

        public Todo(string message)
        {
            Message = message;
            DateCreated = DateTime.UtcNow;
            Status = Status.Created;
        }

        public void UpdateStatus()
        {
            switch (Status)
            {
                case Status.Created:
                    Status = Status.Started;
                    DateStarted = DateTime.UtcNow;
                    break;
                case Status.Started:
                    Status = Status.Done;
                    DateFinished = DateTime.UtcNow;
                    break;
                default:
                    break;
            }
        }
    }
}