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

        public TodoItem Create(string userId, TodoItem todoItem)
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
            }
            else
            {
                throw new ItemNotCreatedException();
            }
        }

        public List<TodoItem> All(string userId)
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
        public TodoItem Delete(int Id)
        {
            var item = _context.todoItems.Find(Id);
            if (item != null)
            {
                _context.todoItems.Remove(item);
                _context.SaveChanges();
                item.Done = true;
                return item;
            }
            else
            {
                throw new ItemNotFoundException();
            }
        }

        public TodoItem Edit(TodoItem todoItem, int Id)
        {
            var item = _context.todoItems.Find(Id);
            if (item != null)
            {
                item.Title = todoItem.Title;
                item.Due = todoItem.Due;
                _context.todoItems.Update(item);
                _context.SaveChanges();
                return item;
            }
            else
            {
                throw new ItemNotFoundException();
            }
        }
    }
}