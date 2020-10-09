using BSSApp.FA.Api.Models;
using BSSApp.FA.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostCentersController: ControllerBase
    {
        private readonly ICostCenterRepository costCenterRepository;

        public CostCentersController(ICostCenterRepository costCenterRepository)
        {
            this.costCenterRepository = costCenterRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetCostCenters()
        {
            try
            {
                return Ok(await costCenterRepository.GetCostCenters());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error retrieving data from database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CostCenter>> GetCostCenter(int id)
        {
            try
            {
                var result=await costCenterRepository.GetCostCenter(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                                    "Data not found database");
            }
        }
    }
}
