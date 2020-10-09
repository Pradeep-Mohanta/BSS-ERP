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
    public class StatesController:ControllerBase
    {
        private readonly IStateRepository stateRepository;

        public StatesController(IStateRepository stateRepository)
        {
            this.stateRepository = stateRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetStates()
        {
            try
            {
                return Ok(await stateRepository.GetStates());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error retrieving data from database");
            }
        }
        [HttpGet("{Id:int}")]
        public async Task<ActionResult<State>> GetState(int Id)
        {
            try
            {
                var result= await stateRepository.GetState(Id);
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
        [HttpGet("statesfind")]
        public async Task<ActionResult<IEnumerable<State>>> GetStateForCountry(int CID)
        {
            var result = await stateRepository.GetStatesForCountry(CID);
            if (result.Any())
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}
