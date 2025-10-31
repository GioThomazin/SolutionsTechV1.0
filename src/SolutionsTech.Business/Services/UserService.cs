using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.Business.Interfaces.Repository;

namespace SolutionsTech.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task CreateUser(User user)
        {
            user.CreateUser(user);
            await _userRepository.AddAsync(user);
        }
        public async Task UpdateUser(User user)
        {
            await _userRepository.UpdateAsync(user);
        }
        public async Task DeleteUser(long id)
        {
            await _userRepository.DeleteAsync(id);
        }
        public async Task<User> GetById(long id)
        {
            return await _userRepository.GetById(id);
        }
        public async Task<List<User>> GetListIndex()
        {
            return await _userRepository.GetListRepository("UserType");
        }
        public async Task<bool> ExistsByNameAsync(string name)
        {
            var existingName = await _userRepository.ExistsByNameAsync(name);

            if(existingName)
            {
                throw new Exception("Já existe um usuário com este nome.");
            }

            return await _userRepository.ExistsByNameAsync(name);
        }
        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _userRepository.ExistsByEmailAsync(email);
        }
        public async Task<bool> ExistsByPhoneAsync(string phone)
        {
            return await _userRepository.ExistsByPhoneAsync(phone);
        }
    }
}
