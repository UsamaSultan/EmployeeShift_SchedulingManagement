using EmployeeManagement.Data.Base;
using EmployeeManagement.Service.IService;
using EmployeeManagement.ViewModel.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Controllers.Api
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeViewModel>>> GetEmployees()
        {
            var Employees = await this._employeeService.GetAll();
            return Employees.ToList();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeViewModel>> GetEmployee(Guid id)
        {
            var employeeLookup = await this._employeeService.GetById(id);

            if (employeeLookup == null)
            {
                return NotFound();
            }

            return employeeLookup;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(Guid id, EmployeeViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return BadRequest();
            }

            try
            {
                viewModel.DateUpdate = DateTime.Now;
                await this._employeeService.Update(viewModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeViewModel>> PostEmployee(EmployeeViewModel viewModel)
        {
            var employeeLookup = await this._employeeService.GetByEmail(viewModel.Email);
            if(employeeLookup != null)
			{
                throw new EmailAlreadyExistsException();
			}

            viewModel.DateCreated = DateTime.Now;
            viewModel.DateUpdate = DateTime.Now;
            viewModel.Id = Guid.NewGuid();
            await this._employeeService.Add(viewModel);

            return CreatedAtAction("GetEmployee", new { id = viewModel.Id }, viewModel);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeViewModel>> DeleteEmployee(Guid id)
        {
            var employeeLookup = await this._employeeService.GetById(id);
            if (employeeLookup == null)
            {
                return NotFound();
            }

            await this._employeeService.Delete(employeeLookup.Id);
            return employeeLookup;
        }

        private bool EmployeeExists(Guid id)
        {
            return this._employeeService.GetAll().Result.Any(e => e.Id == id);
        }
    }
}
