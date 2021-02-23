using gotodo_api.Models;

namespace gotodo_api.Repositories
{
    public interface IUserRepository
    {
         User GetUser(string userId);
         User CreateUser(string userId, string username);
    }
}