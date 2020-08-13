using AutoFixture;
using AutoFixture.AutoMoq;
using EmployeeManagement.Data;
using EmployeeManagement.Repository.IRepository;
using EmployeeManagement.Service.Service;
using Moq;
using System;
using System.Threading.Tasks;
using Test = Xunit.FactAttribute;

namespace EmployeeManagementTests
{
    public class EmployeeServiceUnitTests
    {
        private readonly IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

        [Test]
        public async Task Add_AddEmployee()
        {
            var employeeRepositorymock = _fixture.Freeze<Mock<IEmployeeRepository>>();
            var employeeService = _fixture.Create<EmployeeService>();
            var employee = new Employee { Firstname = "First name", Id = new Guid() };

            await employeeService.Add(new EmployeeManagement.ViewModel.Employee.EmployeeViewModel { Firstname = employee.Firstname, Id = employee.Id });

            employeeRepositorymock.Verify(x => x.InsertAsync(It.Is<Employee>(x => x.Firstname == employee.Firstname && x.Id == employee.Id)));
        }

        [Test]
        public async Task Update_UpdateEmployee()
        {
            var employeeRepositorymock = _fixture.Freeze<Mock<IEmployeeRepository>>();
            var employeeService = _fixture.Create<EmployeeService>();
            var employee = new Employee { Firstname = "First Name", Id = new Guid() };

            await employeeService.Update(new EmployeeManagement.ViewModel.Employee.EmployeeViewModel { Firstname = employee.Firstname, Id = employee.Id });

            employeeRepositorymock.Verify(x => x.UpdateAsync(It.Is<Employee>(x => x.Firstname == employee.Firstname && x.Id == employee.Id)));
        }

        [Test]
        public async Task GetById_GetemployeeById()
        {
            var employeeRepositorymock = _fixture.Freeze<Mock<IEmployeeRepository>>();
            var employeeService = _fixture.Create<EmployeeService>();
            var employee = new Employee { Firstname = "First Name", Id = new Guid() };

            await employeeService.GetById(employee.Id);

            employeeRepositorymock.Verify(x => x.GetByIdAsync(It.IsAny<Guid>()));
        }

        [Test]
        public async Task Delete_DeleteByEntity()
        {
            var employeeRepositorymock = _fixture.Freeze<Mock<IEmployeeRepository>>();
            var employeeService = _fixture.Create<EmployeeService>();
            var employee = new Employee { Firstname = "First Name", Id = new Guid() };

            await employeeService.Delete(new EmployeeManagement.ViewModel.Employee.EmployeeViewModel { Id = employee.Id, Firstname = employee.Firstname });

            employeeRepositorymock.Verify(x => x.Delete(It.Is<Employee>(x => x.Id == employee.Id && x.Firstname == employee.Firstname)));
        }
    }
}
