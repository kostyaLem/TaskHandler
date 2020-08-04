using TaskHandler.Api.Models.Dtos;
using TaskHandler.DataAccess.Models;

namespace TaskHandler.Api.Infrastructure
{
    public class TaskDaraProfile : AutoMapper.Profile
    {
        public TaskDaraProfile()
        {
            CreateMap<TaskDataDto, TaskData>();
            CreateMap<TaskData, TaskDataDto>().ForMember(t => t.CreateTime, m => m.MapFrom(t => t.CreateTime.ToString("hh\\:mm\\:ss\\.f")));
        }
    }
}