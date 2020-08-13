using EmployeeManagement.Service.IService;
using EmployeeManagement.ViewModel.Work;
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
    public class WorksController : ControllerBase
    {
        private readonly IWorkService _workService;

        public WorksController(IWorkService workService)
        {
            this._workService = workService;
        }

        // GET: api/Works
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkViewModel>>> GetWorks()
        {
            var works = await this._workService.GetAll();
            return works.ToList();
        }

        // GET: api/Works/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkViewModel>> GetWork(Guid id)
        {
            var work = await this._workService.GetById(id);

            if (work == null)
            {
                return NotFound();
            }

            return work;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutWork(Guid id, WorkViewModel work)
        {
            if (id != work.Id)
            {
                return BadRequest();
            }

            try
            {
                work.DateUpdate = DateTime.Now;
                await this._workService.Update(work);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkExists(id))
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
        public async Task<ActionResult<WorkViewModel>> PostWork(WorkViewModel viewModel)
        {
            viewModel.DateCreated = DateTime.Now;
            viewModel.DateUpdate = DateTime.Now;
            viewModel.Id = Guid.NewGuid();
            var workLookup = await this._workService.GetByEmployeeIdAndShiftIdAndDate(viewModel.EmployeeId, viewModel.ShiftId, viewModel.DateCreated);

            if(workLookup != null)
			{
                return Ok("Employee already is engaged!");
            }

            var IsExist = await this._workService.GetByEmployeeIdAndDate(viewModel.EmployeeId, viewModel.DateCreated);

            if (IsExist != null)
            {
                return Ok("Employee can not work 2 shifts in a day!");
            }

            await this._workService.Add(viewModel);

            return CreatedAtAction("GetWork", new { id = viewModel.Id }, viewModel);
        }

        // DELETE: api/Works/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WorkViewModel>> DeleteWork(Guid id)
        {
            var work = await this._workService.GetById(id);
            if (work == null)
            {
                return NotFound();
            }

            await this._workService.Delete(work.Id);
            return work;
        }

        private bool WorkExists(Guid id)
        {
            return this._workService.GetAll().Result.Any(e => e.Id == id);
        }
    }
}
