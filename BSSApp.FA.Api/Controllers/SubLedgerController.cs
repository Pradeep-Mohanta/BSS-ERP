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
    public class SubLedgersController:ControllerBase
    {
        private readonly ISubLedgerRepository subLedgerRepository;

        public SubLedgersController(ISubLedgerRepository subLedgerRepository)
        {
            this.subLedgerRepository = subLedgerRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetSubLedgers()
        {
            try
            {
                return Ok(await subLedgerRepository.GetSubLedgers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error retrieving data from database");
            }
        }
        [HttpGet("{lcode}")]
        //public async Task<ActionResult<SubLedger>> GetSubLedgers(string lcode)
        public async Task<List<SubLedger>> GetSubLedgers(string lcode)
        {
                var myval= await subLedgerRepository.GetSubLedger_lcode(lcode);
                return myval.ToList();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<SubLedger>> GetSubledgerWithID(int id)
        {
            try
            {
                return await subLedgerRepository.GetSubLedger(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                                    "Error retrieving data from database");
            }
            
        }
    }
}
