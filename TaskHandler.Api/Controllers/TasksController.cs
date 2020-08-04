using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using TaskHandler.Api.Models.Dtos;
using TaskHandler.DataAccess.Models;
using TaskHandler.DataAccess.Repositories;
using TaskHandler.QueueService;
using System.Messaging;

namespace TaskHandler.Api.Controllers
{
    [Authorize]
    [Route("api/tasks")]
    public class TasksController : ApiController
    {
        private readonly ITaskRepo _taskRepo;
        private readonly IMessageHandler _messageHandler;
        private readonly IMapper _mapper;

        public TasksController(ITaskRepo taskRepo, IMessageHandler messageHandler, IMapper mapper)
        {
            _taskRepo = taskRepo;
            _messageHandler = messageHandler;
            _mapper = mapper;
        }

        //POST /api/tasks
        [HttpPost]
        public void CreateTask([FromBody] TaskDataDto taskDataDto)
        {
            _mapper.Map<TaskData>(taskDataDto);

            _messageHandler.SendMessage(taskDataDto, new BinaryMessageFormatter());
        }

        //GET /api/tasks
        [HttpGet]
        public async Task<IEnumerable<TaskDataDto>> GetTasks()
        {
            var items = await _taskRepo.GetAllAsync();

            return _mapper.Map<IEnumerable<TaskDataDto>>(items);
        }
    }
}
