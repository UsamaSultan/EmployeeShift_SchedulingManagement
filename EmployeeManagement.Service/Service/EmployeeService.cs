using EmployeeManagement.Repository.IRepository;
using EmployeeManagement.Service.IService;
using EmployeeManagement.ViewModel.Employee;
using EmployeeManagement.ViewModel.Work;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Service.Service
{
	public class EmployeeService : IEmployeeService
	{
		private readonly IEmployeeRepository _employeeRepository;
		public EmployeeService(IEmployeeRepository employeeRepository)
		{
			this._employeeRepository = employeeRepository;
		}

		public async Task Add(EmployeeViewModel entity)
		{
			try
			{
				await this._employeeRepository.InsertAsync(EmployeeDTO.ConvertToEntity(entity));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task Delete(EmployeeViewModel entity)
		{
			this._employeeRepository.Delete(EmployeeDTO.ConvertToEntity(entity));
			await Task.FromResult(0);
		}

		public async Task Delete(Guid id)
		{
		 this._employeeRepository.Delete(id);
			await Task.FromResult(0);
		}

		public async Task<IEnumerable<EmployeeViewModel>> GetAll()
		{
			return EmployeeDTO.ConvertToViewModelList(await this._employeeRepository.GetAllAsync());			
		}

		public async Task<EmployeeViewModel> GetByEmail(string email)
		{
			return EmployeeDTO.ConvertToViewModel(await this._employeeRepository.GetByEmail(email));
		}

		public async Task<EmployeeViewModel> GetById(Guid id)
		{
			return EmployeeDTO.ConvertToViewModel(await this._employeeRepository.GetByIdAsync(id));
		}

		public async Task Update(EmployeeViewModel entity)
		{
			try
			{
				await this._employeeRepository.UpdateAsync(EmployeeDTO.ConvertToEntity(entity));
			}
			catch (Exception ex)
			{
				throw ex;
			}			
		}
	}
}
