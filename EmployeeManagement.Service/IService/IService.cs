using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Service.IService
{
	public interface IService<TEntity> where TEntity : class
	{
		Task Add(TEntity entity);
		Task Update(TEntity entity);
		Task Delete(TEntity entity);
		Task Delete(Guid id);
		Task<TEntity> GetById(Guid id);
		Task<IEnumerable<TEntity>> GetAll();
	}
}
