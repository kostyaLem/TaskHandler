using AutoMapper;
using NLog;
using System;
using System.Collections.Generic;
using System.Messaging;
using System.Threading.Tasks;
using System.Web.Http;
using TaskHandler.Api.Models.Dtos;
using TaskHandler.Data.Models;
using TaskHandler.Data.Repositories;
using TaskHandler.QueueService;

namespace TaskHandler.Api.Controllers
{
    [Route("api/tasks")]
    public class TasksController : ApiController
    {
        private static Logger Logger = LogManager.GetCurrentClassLogger();

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
        public IHttpActionResult CreateTask([FromBody] TaskDataDto taskDataDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var taskData = _mapper.Map<TaskData>(taskDataDto);

                _messageHandler.SendMessage(taskData, new BinaryMessageFormatter());

                Logger.Info("Сообщение успешно добавлено в очередь");

                return Ok();
            }
            catch (Exception exc)
            {
                Logger.Error(exc, "Ошибка при добавлении задачи в очередь");
                return BadRequest();
            }
        }

        //GET /api/tasks
        [HttpGet]
        public async Task<IHttpActionResult> GetTasks()
        {
            try
            {
                var items = await _taskRepo.GetAllAsync();

                Logger.Info("Получен список задач", items);

                return Ok(_mapper.Map<IEnumerable<TaskDataDto>>(items));
            }
            catch (Exception exc)
            {
                Logger.Error(exc, "Ошибка при получении списка задач");
                return BadRequest();
            }
        }
    }
}