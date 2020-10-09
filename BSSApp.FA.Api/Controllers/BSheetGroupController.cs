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
    public class BSheetGroupController:ControllerBase
    {
        private readonly IBSheetGroupRepository bSheetGroupRepository;

        public BSheetGroupController(IBSheetGroupRepository bSheetGroupRepository)
        {
            this.bSheetGroupRepository = bSheetGroupRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetBSheetGroups()
        {
            try
            {
                return Ok(await bSheetGroupRepository.GetBSheetGroups());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error retrieving data from database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<BSheetGroup>> GetBSheetGroup(int id)
        {
            try
            {
                var result = await bSheetGroupRepository.GetBSheetGroup(id);
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
