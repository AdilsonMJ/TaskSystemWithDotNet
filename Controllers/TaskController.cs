using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystem.Data.Map;
using TaskSystem.Models;
using TaskSystem.Repository.Interface;

namespace TaskSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
          
        }


        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> GetAllTasks()
        {
            List<TaskModel> taskList = await _taskRepository.GetAllTasks();
            return Ok(taskList);
        }


        [HttpGet ("{id}")]
        public async Task<ActionResult< TaskModel>> GetTaskByID(int id)
        {
            TaskModel task = await _taskRepository.GetTaskById(id);

            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> AddNewTask([FromBody] TaskModel task)
        {

            await _taskRepository.AddNewTask(task);

            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskModel>> UpdateTask([FromBody] TaskModel task, int id)
        {
            task.Id = id;
            TaskModel taskmodel = await _taskRepository.UpdateTask(task, id);

            return Ok(taskmodel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskModel>> DeleteTask(int id)
        {
            return Ok(await _taskRepository.DeleteTask(id));
        }

    }
}
