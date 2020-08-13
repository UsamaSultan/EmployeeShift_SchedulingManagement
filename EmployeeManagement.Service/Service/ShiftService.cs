using EmployeeManagement.Repository.IRepository;
using EmployeeManagement.Service.IService;
using EmployeeManagement.ViewModel;
using EmployeeManagement.ViewModel.Shift;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Service.Service
{
	public class ShiftService : IShiftService
	{
		private readonly IShiftRepository _tradeRepository;
		public ShiftService(IShiftRepository tradeRepository)
		{
			this._tradeRepository = tradeRepository;
		}

		public async Task Add(ShiftViewModel entity)
		{
			try
			{
				await this._tradeRepository.InsertAsync(ShiftDTO.ConvertToEntity(entity));
			
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task Delete(ShiftViewModel entity)
		{
			this._tradeRepository.Delete(ShiftDTO.ConvertToEntity(entity));
			await Task.FromResult(0);
		}

		public async Task Delete(Guid id)
		{
			this._tradeRepository.Delete(id);
			await Task.FromResult(0);
		}

		public async Task<IEnumerable<ShiftViewModel>> GetAll()
		{
			return ShiftDTO.ConvertToViewModelList(await this._tradeRepository.GetAllAsync());			
		}

		public async Task<ShiftViewModel> GetById(Guid id)
		{
			return ShiftDTO.ConvertToViewModel(await this._tradeRepository.GetByIdAsync(id));
		}

		public async Task Update(ShiftViewModel entity)
		{
			try
			{
				await this._tradeRepository.UpdateAsync(ShiftDTO.ConvertToEntity(entity));
			}
			catch (Exception ex)
			{
				throw ex;
			}
			
		}
	}
}
