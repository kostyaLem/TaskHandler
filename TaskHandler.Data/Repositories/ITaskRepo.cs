using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskHandler.Data.Models;

namespace TaskHandler.Data.Repositories
{

    public interface ITaskRepo
    {
        Task AddAsync(TaskData taskInfo);

        Task<IEnumerable<TaskData>> GetAllAsync();

        Task<int> SaveAsync();
    }
}
