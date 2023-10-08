using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Models;
using TaskSystem.Repository.Interface;

namespace TaskSystem.Repository
{
    public class UserRepository : IUserRespository
    {
        private readonly TaskSystemDBContext _dbContext;
        public UserRepository(TaskSystemDBContext taskSystemDbContext)
        {
            _dbContext = taskSystemDbContext;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetUserById(int id)
        {
            UserModel? userGetById = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (userGetById == null)
            {
                throw new Exception($"User with ID: {id} could be found on Database");
            }

            return userGetById;

        }

        public async Task<UserModel> SetUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> Update(UserModel user, int id)
        {
            UserModel userGetById = await GetUserById(id);

            userGetById.Name = user.Name;
            userGetById.Email = user.Email;
            _dbContext.Users.Update(userGetById);
            await _dbContext.SaveChangesAsync();

            return userGetById;

        }

        public  async Task<bool> Delete(int id)
        {
            UserModel userGetById = await GetUserById(id);

            _dbContext.Users.Remove(userGetById);
            await _dbContext.SaveChangesAsync();

            return true;

        }


    }
}
