using System.Collections.Generic;
using System.Threading.Tasks;
using TaskHandler.DataAccess.Models;

namespace TaskHandler.DataAccess.Repositories
{
    public interface ITaskRepo
    {
        Task AddAsync(TaskData taskData);

        Task<IEnumerable<TaskData>> GetAllAsync();

        Task<int> SaveAsync();
    }
}
