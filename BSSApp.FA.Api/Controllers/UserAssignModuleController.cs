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
    public class UserAssignModuleController:ControllerBase
    {
        private readonly IUserAssignModuleRepository userAssignModuleRepository;

        public UserAssignModuleController(IUserAssignModuleRepository userAssignModuleRepository)
        {
            this.userAssignModuleRepository = userAssignModuleRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetUserAssignModules()
        {
            try
            {
                return Ok(await userAssignModuleRepository.GetUserAssignModules());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserAssignModule>> GetUserAssignModule(int id)
        {
            try
            {
                var result = await userAssignModuleRepository.GetUserAssignModule(id);
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
        [HttpGet("{userwise}")]
        public async Task<ActionResult<IEnumerable<UserAssignModule>>> GetUserAssignModule_userWise(string userName)
        {
            try
            {
                var result = await userAssignModuleRepository.GetUserAssignModules_userName(userName);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                                   "Error for find data from database");
            }
        }
    }
}
