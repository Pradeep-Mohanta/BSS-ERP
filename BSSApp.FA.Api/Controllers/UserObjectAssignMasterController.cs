using BSSApp.FA.Api.Models;
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
    public class UserObjectAssignMasterController:ControllerBase
    {
        private readonly IUserObjectAssignMasterRepository userObjectAssignMasterRepository;

        public UserObjectAssignMasterController(IUserObjectAssignMasterRepository userObjectAssignMasterRepository)
        {
            this.userObjectAssignMasterRepository = userObjectAssignMasterRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetUserAssignMasters()
        {
            //try
            //{
                return Ok(await userObjectAssignMasterRepository.GetUserObjectAssignMasters());
            //}
            //catch (Exception)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError,"Error retriveing data from database.");
            //}
        }
    }
}
