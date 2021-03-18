using System.Collections.Generic;
using System.Threading.Tasks;
using gotodo_api.Models;

namespace gotodo_api.Repositories
{
    public interface ITodoItemRepository
    {
        TodoItem Create(string userId, TodoItem todoItem);
        List<TodoItem> All(string userId);

        TodoItem Delete(int Id);
        TodoItem Edit(TodoItem todoItem, int Id);
    }
}