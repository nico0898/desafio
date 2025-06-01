using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApp.Blazor.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public int Priority { get; set; }      // 0 = Baja, 1 = Media, 2 = Alta
        public int State { get; set; }         // 0 = Pendiente, 1 = Completada
    }
}