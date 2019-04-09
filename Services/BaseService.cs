using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Microsoft.EntityFrameworkCore;

namespace Services
{
	public interface IBaseService
	{
		Task<IEnumerable<TEntity>> GetAll<TEntity>() where TEntity : class;

		Task<IEnumerable<TEntity>> GetByEpression<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class;

		void Create<TEntity>(TEntity entity) where TEntity : class;

		void Update<TEntity>(TEntity entity) where TEntity : class;

		Task SaveChangesAsync();
	}

	public class BaseService : IBaseService
	{
		protected CognizantDataContext _dbContext;

		public BaseService(CognizantDataContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IEnumerable<T>> GetAll<T>() where T : class
		{
			return await _dbContext.Set<T>().ToListAsync();
		}

		public async Task<IEnumerable<T>> GetByEpression<T>(Expression<Func<T, bool>> expression) where T : class
		{
			return await _dbContext.Set<T>().Where(expression).ToListAsync();
		}

		public void Create<TEntity>(TEntity entity) where TEntity : class
		{
			_dbContext.Set<TEntity>().Add(entity);
		}

		public void Update<TEntity>(TEntity entity) where TEntity : class
		{
			_dbContext.Set<TEntity>().Update(entity);
		}

		public async Task SaveChangesAsync()
		{
			await _dbContext.SaveChangesAsync();
		}
	}
}
