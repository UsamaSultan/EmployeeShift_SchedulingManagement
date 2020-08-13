using EmployeeManagement.Service.IService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Controllers.Api
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SwapController : ControllerBase
    {
        private readonly IWorkService _workService;

        public SwapController(IWorkService workService)
        {
            this._workService = workService;
        }

        [HttpPost]
        public async Task<ActionResult> PostWork(Guid FromId, Guid ToId, Guid FromEmployeeId, Guid ToEmployeeId)
        {
			var fromWorkLookup = await this._workService.GetById(FromId);

			if (fromWorkLookup == null)
			{
				return BadRequest();
			}

			var toWorkLookup = await this._workService.GetById(ToId);
			if (toWorkLookup == null)
			{
				return BadRequest();
			}

			if (fromWorkLookup.ShiftId == toWorkLookup.ShiftId)
			{
				return Ok("You can not swap within same shift");
			}

			fromWorkLookup.EmployeeId = ToEmployeeId;
			toWorkLookup.EmployeeId = FromEmployeeId;


			await this._workService.Update(fromWorkLookup);
			await this._workService.Update(toWorkLookup);



			return Ok("Success");
		}
    }
}
