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

        [HttpPost]
        public async Task<ActionResult<TaskModel>> AddNewTask([FromBody] TaskModel task)
        {
            await _taskRepository.AddNewTask(task);

            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskModel>> DeleteTask(int id)
        {
            return Ok(await _taskRepository.DeleteTask(id));
        }

    }
}
