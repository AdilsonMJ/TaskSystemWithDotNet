using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystem.Models;
using TaskSystem.Repository.Interface;

namespace TaskSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRespository _userRepository;

        public UserController(IUserRespository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAllUsers()
        {
            List<UserModel> users = await _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetById(int id)
        {
            UserModel userModel = await _userRepository.GetUserById(id);
            return Ok(userModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> UpdateUser([FromBody] UserModel userModel, int id)
        {
            userModel.Id = id;
            UserModel user = await _userRepository.Update(userModel, id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> SetNewUser([FromBody] UserModel user)
        {
            UserModel userModel = await _userRepository.SetUser(user);

            return Ok(userModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> DeleteUser(int id)
        {
            return Ok(await _userRepository.Delete(id));
        }

    }
}
