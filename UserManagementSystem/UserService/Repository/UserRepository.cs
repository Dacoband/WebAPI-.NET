using Common.Models;
using MongoDB.Driver;
using UserService.DBContext;

namespace UserService.Repository
{
    public class UserRepository
    {
        private readonly MongoDbContext _context;

        public UserRepository(MongoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.Find(_ => true).ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _context.Users.Find(user => user.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateUserAsync(User user)
        {
            await _context.Users.InsertOneAsync(user);
        }

        public async Task UpdateUserAsync(string id, User user)
        {
            await _context.Users.ReplaceOneAsync(u => u.Id == id, user);
        }

        public async Task DeleteUserAsync(string id)
        {
            await _context.Users.DeleteOneAsync(user => user.Id == id);
        }
    }
}
