using TaskSystem.Models;

namespace TaskSystem.Repository.Interface
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> GetAllTasks();
        Task<TaskModel> GetTaskById(int id);
        Task<TaskModel> AddNewTask(TaskModel task);
        Task<TaskModel> UpdateTask(TaskModel task, int id);
        Task<bool> DeleteTask(int id);
    }
}
