using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using entitieTask = api.Domain.Entities.Task;


namespace api.Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task<entitieTask> CreateAsync(entitieTask task);
        Task<entitieTask?> GetByIdAsync(Guid id);
        Task<List<entitieTask>> ListAsync();
        Task DeleteAsync(entitieTask task);
        Task UpdateAsync(entitieTask task);
    }
}