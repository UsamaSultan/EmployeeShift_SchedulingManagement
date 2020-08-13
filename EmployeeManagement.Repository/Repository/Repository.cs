using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.Repository
{
    public abstract class Repository<TEntity>
		where TEntity : class
	{
		internal AppDbContext _context;
		public Repository(AppDbContext context)
		{
			this._context = context;
		}

		public void Delete(TEntity entityToDelete)
		{
			try
			{
				if (this._context.Entry(entityToDelete).State == EntityState.Detached)
				{
					this._context.Attach(entityToDelete);
				}
				this._context.Remove(entityToDelete);
				this._context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void Delete(Guid id)
		{
			try
			{
				TEntity entityToDelete = this._context.Set<TEntity>().Find(id);
				_context.Remove(entityToDelete);
				this._context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			
		}

		public IEnumerable<TEntity> GetAll()
		{
			IQueryable<TEntity> query = this._context.Set<TEntity>();

			return query.ToList();
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			IQueryable<TEntity> query = this._context.Set<TEntity>();

			return await query.ToListAsync();
		}

		public TEntity GetById(Guid id)
		{
			return this._context.Set<TEntity>().Find(id);
		}

		public async Task<TEntity> GetByIdAsync(Guid id)
		{
			return await this._context.Set<TEntity>().FindAsync(id);
		}

		public void Insert(TEntity entity)
		{
			try
			{
				var result = this._context.Set<TEntity>().Add(entity);
				this._context.SaveChanges();			
			}
			catch (DbUpdateException ex)
			{
				throw new Exception(ex.InnerException.InnerException.Message);
			}
			catch (Exception ex)
			{
				if (ex.InnerException.InnerException.Message.ToUpper().Contains("VIOLATION OF UNIQUE KEY"))
				{
					throw new Exception("Duplicate unique key");
				}
				else
				{
					throw new Exception("OTHER ERROR " + ex.Message);
				}
			}
		}

		public async Task InsertAsync(TEntity entity)
		{			
			try
			{
				this._context.Set<TEntity>().Add(entity);
				await this._context.SaveChangesAsync();				
			}
			catch (DbUpdateException ex)
			{
				throw new Exception(ex.InnerException.InnerException.Message);
			}
			catch (Exception ex)
			{
				if (ex.InnerException.InnerException.Message.ToUpper().Contains("VIOLATION OF UNIQUE KEY"))
				{
					throw new Exception("Duplicate unique key");
				}
				else
				{
					throw new Exception("OTHER ERROR " + ex.Message);
				}
			}
		}

		public void Update(TEntity entity)
		{
			try
			{
				this._context.Set<TEntity>().Attach(entity);
				this._context.Entry(entity).State = EntityState.Modified;
				this._context.SaveChanges();
			}
			catch (DbUpdateException ex)
			{
				throw new Exception(ex.InnerException.InnerException.Message);
			}
			catch (Exception ex)
			{
				if (ex.InnerException.InnerException.Message.ToUpper().Contains("VIOLATION OF UNIQUE KEY"))
				{
					throw new Exception("Duplicate unique key");
				}
				else
				{
					throw new Exception("OTHER ERROR " + ex.Message);
				}
			}
		}

		public async virtual Task UpdateAsync(TEntity entity)
		{
			try
			{
				
				this._context.Set<TEntity>().Attach(entity);
				this._context.Entry(entity).State = EntityState.Modified;
				await this._context.SaveChangesAsync();
			}
			catch (DbUpdateException ex)
			{
				throw new Exception(ex.InnerException.InnerException.Message);
			}
			catch (Exception ex)
			{
				if (ex.InnerException.InnerException.Message.ToUpper().Contains("VIOLATION OF UNIQUE KEY"))
				{
					throw new Exception("Duplicate unique key");
				}
				else
				{
					throw new Exception("OTHER ERROR " + ex.Message);
				}
			}
		}

		private bool disposed = false;
		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					this._context.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
