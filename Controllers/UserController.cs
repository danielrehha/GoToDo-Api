using gotodo_api.Attributes;
using gotodo_api.Exceptions;
using gotodo_api.Models;
using gotodo_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace gotodo_api.Controllers
{
    [ApiKeyAttribute]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{userId}")]
        public ActionResult<User> Get(string userId)
        {
            try
            {
                var result = _repository.GetUser(userId: userId);
                return result;
            }
            catch (UserNotFoundException)
            {
                System.Console.WriteLine("User was not found!");
                return NotFound();
            }

        }

        [HttpPost("create/{userId}/{username}")]
        public ActionResult<User> Create(string userId, string username)
        {
            try
            {
                var result = _repository.CreateUser(userId: userId, username: username);
                return result;
            }
            catch (UserNotCreatedException)
            {
                System.Console.WriteLine("User could not be created!");
                return NotFound();
            }
        }
    }
}