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
    public class ModuleObjectMasterController:ControllerBase
    {
        private readonly IModuleObjectMasterRepository moduleObjectMasterRepository;

        public ModuleObjectMasterController(IModuleObjectMasterRepository moduleObjectMasterRepository)
        {
            this.moduleObjectMasterRepository = moduleObjectMasterRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetModuleObjectMasters()
        {
            try
            {
                return Ok(await moduleObjectMasterRepository.GetModuleObjectMasters());

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ModuleObjectMaster>> GetModuleObjectMaster(int id)
        {
            try
            {
                var result = await moduleObjectMasterRepository.GetModuleObjectMaster(id);
                
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }
        [HttpGet("userWise")]
        public async Task<ActionResult<IEnumerable<ModuleObjectMaster>>> GetModuleObjectMaster_userWise(string userName, string moduleCode)
        {
            try
            {
                var result = await moduleObjectMasterRepository.GetModuleObjects_user_ModuleWise(userName, moduleCode);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }
    }
}
