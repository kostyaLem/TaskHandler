using TaskHandler.Api.Models.Dtos;
using TaskHandler.Data.Models;

namespace TaskHandler.Api.Infrastructure
{
    public class TaskDataProfile : AutoMapper.Profile
    {
        public TaskDataProfile()
        {
            CreateMap<TaskDataDto, TaskData>();
            CreateMap<TaskData, TaskDataDto>().ForMember(t => t.CreateTime, m => m.MapFrom(t => t.CreateTime.ToString("hh\\:mm\\:ss\\.f")));
        }
    }
}