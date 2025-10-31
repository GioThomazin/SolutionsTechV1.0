using SolutionsTech.Business.Entity;

namespace SolutionsTech.Business.Interfaces
{
   public interface IUserService
    {
		Task CreateUser(User user);
		Task UpdateUser(User user);
		Task DeleteUser(long id);
		Task<User> GetById(long id);
		Task<List<User>> GetListIndex();
		Task<bool> ExistsByNameAsync(string name);
        Task<bool> ExistsByEmailAsync(string email);
		Task<bool> ExistsByPhoneAsync(string phone);
    }
}
