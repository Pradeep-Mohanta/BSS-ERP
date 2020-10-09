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
    public class LedgersController:ControllerBase
    {
        private readonly ILedgerRepository ledgerRepository;

        public LedgersController(ILedgerRepository ledgerRepository)
        {
            this.ledgerRepository = ledgerRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetLedgers()
        {
            try
            {
                return Ok(await ledgerRepository.GetLedgers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }

        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Ledger>> GetLedger(int id)
        {
            try
            {
                var result= await ledgerRepository.GetLedger(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error retrieving data from database");
            }
        }
    }
}
