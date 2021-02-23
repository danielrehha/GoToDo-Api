using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using gotodo_api.Exceptions;
using gotodo_api.Models;
using gotodo_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace gotodo_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController
    {
        private ITodoItemRepository _repository;

        public TodoController(ITodoItemRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{userId}/all")]
        public ActionResult<List<TodoItem>> GetAllTodoItems(string userId)
        {
            try
            {
                var result = _repository.GetAllTodoItems(userId: userId);
                return result;
            }
            catch (UserNotFoundException)
            {
                System.Console.WriteLine("User was not found!");
                return null;
            }
        }

        [HttpPost("{userId}/create")]
        public ActionResult<TodoItem> CreateTodoItem(string userId, [FromBody] TodoItem todoItem)
        {
            try
            {
                var result = _repository.CreateTodoItem(userId: userId, todoItem: todoItem);
                return result;
            }
            catch (ItemNotCreatedException)
            {
                System.Console.WriteLine("Item could not be created");
                return null;
            }
        }
    }
}