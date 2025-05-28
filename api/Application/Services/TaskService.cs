using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Domain.Entities;
using api.Domain.Interfaces;
using api.Models;
using entitieTask = api.Domain.Entities.Task;

namespace api.Application.Services
{
    public class TaskService
    {
        private readonly ITaskRepository _repo;

        public TaskService(ITaskRepository repo)
        {
            _repo = repo;
        }

        public async Task<entitieTask> CreateAsync(TaskModel model)
        {
            var newTask = new entitieTask
            {
                Title = model.Title,
                Description = model.Description,
                ExpiryDate = model.ExpiryDate,
                Priority = Enum.TryParse(model.Priority, true, out Priority prio) ? prio : Priority.Media
            };

            if (string.IsNullOrWhiteSpace(newTask.Title))
                throw new Exception("El título es obligatorio");

            var tareas = await _repo.ListAsync();

            if (tareas.Count(t => t.State == State.Pendiente && t.Priority == Priority.Alta) >= 10)
                Console.WriteLine("⚠️ Advertencia: más de 10 tareas de alta prioridad pendientes");

            newTask.Id = Guid.NewGuid();
            return await _repo.CreateAsync(newTask);
        }

        public async Task<entitieTask> CompleteTaskAsync(Guid id)
        {
            var task = await _repo.GetByIdAsync(id);
            if (task == null) throw new Exception("Tarea no encontrada");
            if (task.ExpiryDate < DateTime.Now) throw new Exception("No se puede completar una tarea vencida");

            task.State = State.Completada;
            await _repo.UpdateAsync(task);
            return task;
        }

        public async Task<List<entitieTask>> ListAsync(string state)
        {
            _ = Enum.TryParse<State>(state, out var filter);

            var tasks = await _repo.ListAsync();

            return tasks.Where(x =>  x.State == filter).OrderByDescending(y => y.Priority).OrderBy(z => z.ExpiryDate).ToList();
        }

        public async System.Threading.Tasks.Task DeleteAsync(Guid id)
        {
            var tasks = await _repo.ListAsync();
            var task = tasks.FirstOrDefault(x =>  x.Id == id);

            await _repo.DeleteAsync(task);
        }
    }
}