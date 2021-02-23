using System.Linq;
using gotodo_api.Database;
using gotodo_api.Exceptions;
using gotodo_api.Models;

namespace gotodo_api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User CreateUser(string userId, string username)
        {
            var user = new User(
                userId: userId,
                username: username
            );
            _context.users.Add(user);
            _context.SaveChanges();
            var result = _context.users.Find(userId);
            if(result != null) {
                return result;
            } else {
                throw new UserNotCreatedException();
            }
        }

        public User GetUser(string userId)
        {
            var result = _context.users.Find(userId);
            if(result != null) {
                return result;
            } else {
                throw new UserNotFoundException();
            }
        }
    }
}