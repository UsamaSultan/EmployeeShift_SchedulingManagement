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
    public class ShifServiceUnitTests
    {
        private readonly IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

        [Test]
        public async Task Add_AddShift()
        {
            var shiftRepositorymock = _fixture.Freeze<Mock<IShiftRepository>>();
            var shiftService = _fixture.Create<ShiftService>();
            var shift = new Shift { Name = "Shift Name", Id = new Guid(), To = "12:00 03.03.2020" };

            await shiftService.Add(new EmployeeManagement.ViewModel.Shift.ShiftViewModel { Id = shift.Id, Name = shift.Name, From = shift.From, To = shift.To });

            shiftRepositorymock.Verify(x => x.InsertAsync(It.Is<Shift>(x => x.Name == shift.Name && x.Id == shift.Id && x.To == shift.To)));
        }

        [Test]
        public async Task Update_UpdateShift()
        {
            var shiftRepositorymock = _fixture.Freeze<Mock<IShiftRepository>>();
            var shiftService = _fixture.Create<ShiftService>();
            var shift = new Shift { Id = new Guid(), From = "10:00 03.03.2020" };

            await shiftService.Update(new EmployeeManagement.ViewModel.Shift.ShiftViewModel { Id = shift.Id, Name = shift.Name, From = shift.From, To = shift.To });

            shiftRepositorymock.Verify(x => x.UpdateAsync(It.Is<Shift>(x => x.Id == shift.Id && x.From == shift.From)));
        }

        [Test]
        public async Task GetById_GetShiftById()
        {
            var shiftRepositorymock = _fixture.Freeze<Mock<IShiftRepository>>();
            var shiftService = _fixture.Create<ShiftService>();
            var shift = new Shift { Id = new Guid() };

            await shiftService.GetById(shift.Id);

            shiftRepositorymock.Verify(x => x.GetByIdAsync(It.IsAny<Guid>()));
        }

        [Test]
        public async Task Delete_DeleteByEntity()
        {
            var shiftRepositorymock = _fixture.Freeze<Mock<IShiftRepository>>();
            var shiftService = _fixture.Create<ShiftService>();
            var shift = new Shift { Id = new Guid() };

            await shiftService.Delete(new EmployeeManagement.ViewModel.Shift.ShiftViewModel { Id = shift.Id, Name = "Delete Me" });

            shiftRepositorymock.Verify(x => x.Delete(It.Is<Shift>(x => x.Id == shift.Id && x.Name == "Delete Me")));
        }
    }
}
