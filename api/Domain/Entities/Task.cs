using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Domain.Entities
{
    public enum Priority { Baja, Media, Alta }

    public enum State { Pendiente, Completado }

    public class Task
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public Priority Priority { get; set; }
        public State State { get; set; }
    }
}