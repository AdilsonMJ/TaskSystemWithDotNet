using TaskSystem.Models;

namespace TaskSystem.Repository.Interface
{
    public interface IUserRespository
    {
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetUserById(int id);
        Task<UserModel> SetUser(UserModel user);
        Task<UserModel> Update(UserModel user, int id);
        Task<bool> Delete(int id);
    }
}
