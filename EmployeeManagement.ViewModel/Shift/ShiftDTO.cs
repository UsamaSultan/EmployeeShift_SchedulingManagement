using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.ViewModel.Shift
{
	public static class ShiftDTO
	{
		public static EmployeeManagement.Data.Shift ConvertToEntity(EmployeeManagement.ViewModel.Shift.ShiftViewModel viewModel)
		{
			if (viewModel == null) return null;

			return new EmployeeManagement.Data.Shift
			{
				Id = viewModel.Id,
				DateCreated = viewModel.DateCreated,
				DateUpdate = viewModel.DateUpdate,
				Date = viewModel.Date,
				Name = viewModel.Name,
				From = viewModel.From,
				To = viewModel.To
			};
		}

		public static EmployeeManagement.ViewModel.Shift.ShiftViewModel ConvertToViewModel(EmployeeManagement.Data.Shift dataEntity)
		{
			if (dataEntity == null) return null;

			return new EmployeeManagement.ViewModel.Shift.ShiftViewModel
			{
				Id = dataEntity.Id,
				DateCreated = dataEntity.DateCreated,
				DateUpdate = dataEntity.DateUpdate,
				Date = dataEntity.Date,
				Name = dataEntity.Name,
				From = dataEntity.From,
				To = dataEntity.To
			};
		}


		public static IEnumerable<EmployeeManagement.ViewModel.Shift.ShiftViewModel> ConvertToViewModelList(IEnumerable<EmployeeManagement.Data.Shift> dataList)
		{
			if (dataList == null) yield break;

			foreach (var item in dataList)
			{
				yield return ConvertToViewModel(item);
			}
		}
	}
}
