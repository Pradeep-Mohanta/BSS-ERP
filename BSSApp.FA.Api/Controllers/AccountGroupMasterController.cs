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
    public class AccountGroupMasterController:ControllerBase
    {
        private readonly IAccountGroupMasterRepository accountGroupMasterRepository;

        public AccountGroupMasterController(IAccountGroupMasterRepository accountGroupMasterRepository)
        {
            this.accountGroupMasterRepository = accountGroupMasterRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetAccountGroupMasters()
        {
            try
            {
                return Ok(await accountGroupMasterRepository.GetAccountGroupMasters());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }
        [HttpGet("{id:Int}")]
        public async Task<ActionResult<AccountGroupMaster>> GetAccountGroupMasterWithID(int id)
        {
            try
            {
                return await accountGroupMasterRepository.GetAccountGroupMaster(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Data not found of ID={id}");
            }
        }
        [HttpGet("{AGSearch}")]
        public async Task<List<AccountGroupMaster>> GetAccountGroupMastersWithCode(string GCode)
        {
                return await accountGroupMasterRepository.GetAccountGroupMastersWithCode(GCode);
            
        }
    }
}
