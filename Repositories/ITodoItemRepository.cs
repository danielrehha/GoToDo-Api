using System.Collections.Generic;
using System.Threading.Tasks;
using gotodo_api.Models;

namespace gotodo_api.Repositories
{
    public interface ITodoItemRepository
    {
        TodoItem CreateTodoItem(string userId, TodoItem todoItem);
        List<TodoItem> GetAllTodoItems(string userId);
    }
}