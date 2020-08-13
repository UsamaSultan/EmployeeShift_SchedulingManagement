using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.ViewModel.Work
{
	public static class WorkDTO
	{
		public static EmployeeManagement.Data.Work ConvertToEntity(EmployeeManagement.ViewModel.Work.WorkViewModel viewModel)
		{
			if (viewModel == null) return null;

			return new EmployeeManagement.Data.Work
			{
				Id = viewModel.Id,
				DateCreated = viewModel.DateCreated,
				DateUpdate = viewModel.DateUpdate,
				EmployeeId = viewModel.EmployeeId,
				ShiftId = viewModel.ShiftId
			};
		}

		public static EmployeeManagement.ViewModel.Work.WorkViewModel ConvertToViewModel(EmployeeManagement.Data.Work dataEntity)
		{
			if (dataEntity == null) return null;

			return new EmployeeManagement.ViewModel.Work.WorkViewModel
			{
				Id = dataEntity.Id,
				DateCreated = dataEntity.DateCreated,
				DateUpdate = dataEntity.DateUpdate,
				EmployeeId = dataEntity.EmployeeId,
				ShiftId = dataEntity.ShiftId
			};
		}


		public static IEnumerable<EmployeeManagement.ViewModel.Work.WorkViewModel> ConvertToViewModelList(IEnumerable<EmployeeManagement.Data.Work> dataList)
		{
			if (dataList == null) yield break;

			foreach (var item in dataList)
			{
				yield return ConvertToViewModel(item);
			}
		}
	}
}
