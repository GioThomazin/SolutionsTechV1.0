using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SolutionsTech.Business.Interfaces.Repository;
using SolutionsTech.Data.Context;
using System.Linq.Expressions;

namespace SolutionsTech.Data.Repository
{
	public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
	{
		private readonly ApplicationDbContext _context;
		private readonly DbSet<TEntity> _dbSet;

		public RepositoryBase(ApplicationDbContext context)
		{
			_context = context;
			_dbSet = _context.Set<TEntity>();
		}
		public DbContext Context => _context;

		public async Task<TEntity> GetByIdAsync(long id)
		{
			return await _dbSet.FindAsync(id);
		}
		public async Task<List<TEntity>> GetAllAsync()
		{
			return await _dbSet.AsNoTracking().ToListAsync();
		}

		public async Task<List<TEntity>> GetAllAsyncWithProperties(string includeProperties)
		{
			IQueryable<TEntity> query = _dbSet;

			foreach (string includeProperty in includeProperties.Trim().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				query = query.Include(includeProperty).AsSplitQuery();

			return await query.AsNoTracking().ToListAsync();
		}

		public async Task<List<TEntity>> FindByAsyncList(Expression<Func<TEntity, bool>> filter = null!, string includeProperties = "")
		{
			IQueryable<TEntity> query = _dbSet;

			if (filter != null)
				query = query.Where(filter);

			foreach (string includeProperty in includeProperties.Trim().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				query = query.Include(includeProperty).AsSplitQuery();


			return await query.AsNoTracking().ToListAsync();
		}

		public async Task<TEntity> FindByAsyncSingle(Expression<Func<TEntity, bool>> filter, string includeProperties = "")
		{
			IQueryable<TEntity> query = _dbSet;

			if (filter != null)
				query = query.Where(filter);

			foreach (string includeProperty in includeProperties.Trim().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				query = query.Include(includeProperty).AsSplitQuery();


			return await query.FirstOrDefaultAsync();
		}

		public async Task<TEntity> FindByAsync(long id)
		{
			return await _context.Set<TEntity>().FindAsync(id);
		}

		public async Task<TEntity> AddAsync(TEntity toAdd)
		{
			await _dbSet.AddAsync(toAdd);
			await _context.SaveChangesAsync();

			return toAdd;
		}

		public async Task UpdateAsync(TEntity toUpdate)
		{
			_dbSet.Attach(toUpdate);
			var entry = _context.Entry(toUpdate);
			entry.State = EntityState.Modified;

			foreach (var property in entry.Properties)
			{
				if (property.Metadata.IsPrimaryKey() || property.Metadata.IsForeignKey())
					property.IsModified = false;
			}
			await _context.SaveChangesAsync();
		}


		public async Task DeleteAsync(long id)
		{
			TEntity entity = _dbSet.Find(id)!;
			_dbSet.Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(TEntity entity)
		{
			_dbSet.Remove(entity);
			await _context.SaveChangesAsync();
		}
	}
}
