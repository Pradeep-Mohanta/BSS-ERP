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
    public class TrnTmpController: ControllerBase
    {
        private readonly ITrnTmpRepository trnTmpRepository;

        public TrnTmpController(ITrnTmpRepository trnTmpRepository)
        {
            this.trnTmpRepository = trnTmpRepository;
        }
        [HttpPost]
        public Task<ActionResult<TrnTmp>> AddTrnTmp(TrnTmp trnTmp)
        {
            try
            {
                if (trnTmp == null)
                {
                    BadRequest();
                }
                var CreatedTrn= trnTmpRepository.AddTrnTmp(trnTmp);
                //CreatedAtAction(nameof)
                return null;
            }
            catch (Exception)
            {
                //return StatusCode(StatusCodes.Status500InternalServerError, "Error to add data");
                throw;
            }
        }
    }
}
