using SolutionsTech.Business.Entity;

namespace SolutionsTech.Business.Interfaces.Repository
{
    public interface IUserRepository : IRepositoryBase<User>
	{
        Task<List<User>> GetListRepository(string properties);
		Task<User?> GetById(long id);
	}
}
