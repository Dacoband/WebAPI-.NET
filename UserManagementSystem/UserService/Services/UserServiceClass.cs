using Common.Models;
using UserService.Repository;

namespace UserService.Services
{
    public class UserServiceClass
    {
        private readonly UserRepository _userRepository;
        public UserServiceClass(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        public async Task<User> GetUserAsync(string id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task CreateUserAsync(User user)
        {
            await _userRepository.CreateUserAsync(user);
        }

        public async Task UpdateUserAsync(string id, User user)
        {
            await _userRepository.UpdateUserAsync(id, user);
        }

        public async Task DeleteUserAsync(string id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
    }
}
