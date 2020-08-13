using EmployeeManagement.Service.IService;
using EmployeeManagement.ViewModel.Shift;
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
    public class ShiftsController : ControllerBase
    {
        private readonly IShiftService _shiftService;

        public ShiftsController(IShiftService shiftService)
        {
            this._shiftService = shiftService;
        }

        // GET: api/Shifts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShiftViewModel>>> GetShifts()
        {
            var Shifts = await this._shiftService.GetAll();
            return Shifts.ToList();
        }

        // GET: api/Shifts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShiftViewModel>> GetShift(Guid id)
        {
            var shiftLookup = await this._shiftService.GetById(id);

            if (shiftLookup == null)
            {
                return NotFound();
            }

            return shiftLookup;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutShift(Guid id, ShiftViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return BadRequest();
            }

            try
            {
                viewModel.DateUpdate = DateTime.Now;
                await this._shiftService.Update(viewModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShiftExists(id))
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
        public async Task<ActionResult<ShiftViewModel>> PostShift(ShiftViewModel viewModel)
        {
            viewModel.DateCreated = DateTime.Now;
            viewModel.DateUpdate = DateTime.Now;
            viewModel.Id = Guid.NewGuid();
            await this._shiftService.Add(viewModel);

            return CreatedAtAction("GetShift", new { id = viewModel.Id }, viewModel);
        }

        // DELETE: api/Shifts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShiftViewModel>> DeleteShift(Guid id)
        {
            var shiftLookup = await this._shiftService.GetById(id);
            if (shiftLookup == null)
            {
                return NotFound();
            }

            await this._shiftService.Delete(shiftLookup.Id);
            return shiftLookup;
        }

        private bool ShiftExists(Guid id)
        {
            return this._shiftService.GetAll().Result.Any(e => e.Id == id);
        }
    }
}
