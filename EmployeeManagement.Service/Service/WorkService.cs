using EmployeeManagement.Repository.IRepository;
using EmployeeManagement.Service.IService;
using EmployeeManagement.ViewModel.Shift;
using EmployeeManagement.ViewModel.Work;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Service.Service
{
	public class WorkService : IWorkService
	{
		private readonly IWorkRepository _workRepository;
		public WorkService(IWorkRepository workRepository)
		{
			this._workRepository = workRepository;
		}

		public async Task Add(WorkViewModel entity)
		{
			try
			{
				await this._workRepository.InsertAsync(WorkDTO.ConvertToEntity(entity));
				
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task Delete(WorkViewModel entity)
		{
			this._workRepository.Delete(WorkDTO.ConvertToEntity(entity));
			await Task.FromResult(0);
		}

		public async Task Delete(Guid id)
		{
			this._workRepository.Delete(id);
			await Task.FromResult(0);
		}

		public async Task<IEnumerable<WorkViewModel>> GetAll()
		{
			return WorkDTO.ConvertToViewModelList(await this._workRepository.GetAllAsync());			
		}

		public async Task<WorkViewModel> GetByEmployeeIdAndDate(Guid employeeId, DateTime Date)
		{
			return WorkDTO.ConvertToViewModel(await this._workRepository.GetByEmployeeIdAndDate(employeeId, Date));
		}

		public async Task<WorkViewModel> GetByEmployeeIdAndShiftIdAndDate(Guid employeeId, Guid shiftId, DateTime Date)
		{
			return WorkDTO.ConvertToViewModel(await this._workRepository.GetByEmployeeIdAndShiftIdAndDate(employeeId, shiftId, Date));
		}

		public async Task<WorkViewModel> GetById(Guid id)
		{
			return WorkDTO.ConvertToViewModel(await this._workRepository.GetByIdAsync(id));
		}

		public async Task Update(WorkViewModel entity)
		{
			try
			{
				await this._workRepository.UpdateAsync(WorkDTO.ConvertToEntity(entity));
			}
			catch (Exception ex)
			{
				throw ex;
			}
			
		}
	}
}
