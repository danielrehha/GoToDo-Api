using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    public class TodoController : ControllerBase
    {
        private ITodoItemRepository _repository;

        public TodoController(ITodoItemRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{userId}/all")]
        public ActionResult<List<TodoItem>> All(string userId)
        {
            try
            {
                var result = _repository.All(userId: userId);
                return result;
            }
            catch (UserNotFoundException)
            {
                System.Console.WriteLine("User was not found!");
                return NotFound();
            }
        }

        [HttpPost("{userId}/create")]
        public ActionResult<TodoItem> Create(string userId, [FromBody] TodoItem todoItem)
        {
            try
            {
                var result = _repository.Create(userId: userId, todoItem: todoItem);
                return result;
            }
            catch (ItemNotCreatedException)
            {
                System.Console.WriteLine("Item could not be created");
                return NotFound();
            }
        }


        [HttpGet("{Id}/delete")]
        public ActionResult<TodoItem> Delete(int Id)
        {
            try
            {
                var item = _repository.Delete(Id: Id);
                return Ok(item);
            }
            catch (ItemNotFoundException)
            {
                System.Console.WriteLine("Item could not be found!");
                return NotFound();
            }
        }

        [HttpPost("{Id}/edit")]
        public ActionResult<TodoItem> Edit([FromBody] TodoItem todoItem, int Id)
        {
            try
            {
                var item = _repository.Edit(todoItem: todoItem, Id: Id);
                return Ok(item);
            }
            catch (ItemNotFoundException)
            {
                System.Console.WriteLine("Item could not be found!");
                return NotFound();
            }
        }
    }
}