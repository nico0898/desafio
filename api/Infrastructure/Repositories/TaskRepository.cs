using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using api.Domain.Interfaces;
using entitieTask = api.Domain.Entities.Task;

namespace api.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly string _filePath = "tasks.json";
        private List<entitieTask> _tasks;
        
        public TaskRepository()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                _tasks = JsonSerializer.Deserialize<List<entitieTask>>(json) ?? new List<entitieTask>();
            }
            else
            {
                _tasks = new List<entitieTask>();
            }
        }
        
        public Task<entitieTask> CreateAsync(entitieTask task)
        {
            _tasks.Add(task);
            SaveToFile();
            return Task.FromResult(task);
        }

        public Task<entitieTask?> GetByIdAsync(Guid id)
        {
            return Task.FromResult(_tasks.FirstOrDefault(t => t.Id == id));
        }

        public Task<List<entitieTask>> ListAsync()
        {
            return Task.FromResult(_tasks.ToList());
        }

        public Task DeleteAsync(entitieTask task)
        {
            _tasks.Remove(task);
            SaveToFile();
            return Task.CompletedTask;
        }

        public Task UpdateAsync(entitieTask task)
        {
            SaveToFile();
            return Task.CompletedTask;
        }
        
        private void SaveToFile()
        {
            var json = JsonSerializer.Serialize(_tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}