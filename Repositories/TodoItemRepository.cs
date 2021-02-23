using System.Collections.Generic;
using gotodo_api.Database;
using gotodo_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using gotodo_api.Exceptions;

namespace gotodo_api.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private AppDbContext _context;

        public TodoItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public TodoItem CreateTodoItem(string userId, TodoItem todoItem)
        {
            var newItem = new TodoItem(
                id: 0,
                userId: userId,
                title: todoItem.Title,
                due: todoItem.Due,
                done: false
            );

            _context.todoItems.Add(todoItem);
            _context.SaveChanges();

            var result = _context.todoItems.Find(todoItem.Id);
            
            if (result != null)
            {
                return result;
            } else {
                throw new ItemNotCreatedException();
            }
        }

        public List<TodoItem> GetAllTodoItems(string userId)
        {
            var user = _context.users.Find(userId);
            if (user != null)
            {
                var items = _context.todoItems.Where(i => i.UserId == userId).ToList();
                return items;
            }
            else
            {
                throw new UserNotFoundException();
            }
        }
    }
}