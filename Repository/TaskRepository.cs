using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Models;
using TaskSystem.Repository.Interface;

namespace TaskSystem.Repository
{
    public class TaskRepository : ITaskRepository
    {

        private readonly TaskSystemDBContext _dbContext;
        public TaskRepository(TaskSystemDBContext taskSystemDbContext )
        {
            _dbContext = taskSystemDbContext;
        }

        public async Task<List<TaskModel>> GetAllTasks()
        {
            return await _dbContext.Tasks
                .Include(x => x.User)
                .ToListAsync();
        }


        public async Task<TaskModel> GetTaskById(int id)
        {
            TaskModel? taskGetById = await _dbContext.Tasks
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);


            if(taskGetById == null)
            {
                throw new Exception($"User with ID: {id} could not be found in the dataBase");
            }

            return taskGetById;
        }

        public async Task<TaskModel> UpdateTask(TaskModel task, int id)
        {
            TaskModel taskModelGetById = await GetTaskById(id);

            taskModelGetById.Name = task.Name;
            taskModelGetById.Status = task.Status;
            taskModelGetById.Description = task.Description;
            taskModelGetById.UserId = task.UserId;

            _dbContext.Tasks.Update(taskModelGetById);
            await _dbContext.SaveChangesAsync();

            return taskModelGetById;

        }

        public async Task<TaskModel> AddNewTask(TaskModel task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }

        public async Task<bool> DeleteTask(int id)
        {
            TaskModel taskModel = await GetTaskById(id);

            _dbContext.Tasks.Remove(taskModel);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
