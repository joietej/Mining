using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mining.Application.Services;
using Mining.Presentation.Models;

namespace Mining.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class MiningController : Controller
    {
        private readonly IMiningService miningService;

        public MiningController(IMiningService miningService)
        {
            this.miningService = miningService;
        }

        // POST api/Mining/Calculate
        [Route("Calculate")]
        [HttpPost]
        public IActionResult Calculate([FromBody] TransationsRequestModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = miningService.CalculateMaxFee(model.Transactions, model.MaxBlockSize, model.BockFee);
                    return Ok(result);
                }
                return BadRequest(ModelState);

            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

    }
}
