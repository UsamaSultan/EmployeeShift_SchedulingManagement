using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.ViewModel.Employee
{
	public static class EmployeeDTO
	{
		public static EmployeeManagement.Data.Employee ConvertToEntity(EmployeeManagement.ViewModel.Employee.EmployeeViewModel viewModel)
		{
			if (viewModel == null) return null;

			return new EmployeeManagement.Data.Employee
			{
				Id = viewModel.Id,
				DateCreated = viewModel.DateCreated,
				DateUpdate = viewModel.DateUpdate,
				Firstname = viewModel.Firstname,
				Lastname = viewModel.Lastname,
				Email = viewModel.Email
			};
		}

		public static EmployeeManagement.ViewModel.Employee.EmployeeViewModel ConvertToViewModel(EmployeeManagement.Data.Employee dataEntity)
		{
			if (dataEntity == null) return null;

			return new EmployeeManagement.ViewModel.Employee.EmployeeViewModel
			{
				Id = dataEntity.Id,
				DateCreated = dataEntity.DateCreated,
				DateUpdate = dataEntity.DateUpdate,
				Firstname = dataEntity.Firstname,
				Lastname = dataEntity.Lastname,
				Email = dataEntity.Email
			};
		}


		public static IEnumerable<EmployeeManagement.ViewModel.Employee.EmployeeViewModel> ConvertToViewModelList(IEnumerable<EmployeeManagement.Data.Employee> dataList)
		{
			if (dataList == null) yield break;

			foreach (var item in dataList)
			{
				yield return ConvertToViewModel(item);
			}
		}
	}
}
