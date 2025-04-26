
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace SolutionsTech.Business.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity toAdd);
        Task DeleteAsync(long id);
        Task DeleteAsync(TEntity entity);
        Task<TEntity> FindByAsync(long id);
        Task<List<TEntity>> FindByAsyncList(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "");
        Task<TEntity> FindByAsyncSingle(Expression<Func<TEntity, bool>> filter, string includeProperties = "");
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAllAsyncWithProperties(string includeProperties);
        Task UpdateAsync(TEntity toUpdate);
    }
}
