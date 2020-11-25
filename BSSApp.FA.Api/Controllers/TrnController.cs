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
    public class TrnController : ControllerBase
    {
        private readonly ITrnRepository trnRepository;

        public TrnController(ITrnRepository trnRepository)
        {
            this.trnRepository = trnRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Trn>> GetTrns()
        {
            try
            {
                return Ok(await trnRepository.GetTrns());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from TRN.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Trn>> GetTrn(int id)
        {
            return await trnRepository.GetTrn(id);
        }
        [HttpGet("vouchervno")]
        public async Task<ActionResult> GetTrnsVno(string Vno, DateTime Vdt,int BookNo)
        {
            return Ok(await trnRepository.GetTrnsVno(Vno, Vdt, BookNo));
        }

        [HttpGet("vouchervdt")]
        public async Task<ActionResult> GetTrnVdtBook(DateTime Vdt, int BookNo)
        {
            return Ok(await trnRepository.GetTrnVdtBook(Vdt, BookNo));
        }

        [HttpPost]
        public async Task<ActionResult<Trn>> AddTrn(Trn trn)
        {
            try
            {
                if (trn == null)
                {
                    BadRequest();
                }
                var addResult=await trnRepository.AddTrn(trn);
                return CreatedAtAction(nameof(GetTrn), new { id = addResult.TrnID }, addResult);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error for saving data.");
            }
        }
    }
}
