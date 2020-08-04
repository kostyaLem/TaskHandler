using System.Collections.Generic;
using System.Threading.Tasks;
using TaskHandler.Data.Models;

namespace TaskHandler.Data.Repositories
{
    public interface ITaskRepo
    {
        void BeginTransaction();
        void EndTransaction();

        Task AddAsync(TaskData taskData);

        Task<IEnumerable<TaskData>> GetAllAsync();
    }
}
