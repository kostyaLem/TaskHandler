using System.Collections.Generic;
using System.Threading.Tasks;
using TaskHandler.Data.Models;

namespace TaskHandler.Data.Repositories
{
    public interface ITaskRepo
    {
        Task AddAsync(TaskData taskData);

        Task<IEnumerable<TaskData>> GetAllAsync();
    }
}
