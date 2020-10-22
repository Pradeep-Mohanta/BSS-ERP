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
    public class ModuleMasterController:ControllerBase
    {
        private readonly IModuleMasterRepository moduleMasterRepository;

        public ModuleMasterController(IModuleMasterRepository moduleMasterRepository)
        {
            this.moduleMasterRepository = moduleMasterRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetModuleMasters()
        {
            try
            {
                return Ok(await moduleMasterRepository.GetModuleMasters());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ModuleMaster>> GetModuleMaster(int id)
        {
            try
            {
                var result= await moduleMasterRepository.GetModuleMaster(id);
                if (result == null)
                {
                    NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }
    }
}
