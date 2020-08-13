using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.IRepository
{
	public interface IRepository<TEntity> : IDisposable
		where TEntity : class 
	{
		void Delete(TEntity entityToDelete);
		void Delete(Guid id);
		IEnumerable<TEntity> GetAll();
		TEntity GetById(Guid id);
		void Insert(TEntity entity);
		void Update(TEntity entity);

		Task<IEnumerable<TEntity>> GetAllAsync();
		Task<TEntity> GetByIdAsync(Guid id);
		Task InsertAsync(TEntity entity);
		Task UpdateAsync(TEntity entity);
	}
}
