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
    public class TrnMemoController:ControllerBase
    {
        private readonly ITrnMemoRepository trnMemoRepository;
        public TrnMemoController(ITrnMemoRepository trnMemoRepository)
        {
            this.trnMemoRepository = trnMemoRepository;
        }

        [HttpPost]
        public async Task<ActionResult<TrnMemo>> AddTrnMemo(TrnMemo trnMemo)
        {
            try
            {
                if (trnMemo == null)
                {
                    return BadRequest();
                }
                var addedTrn =await trnMemoRepository.Add(trnMemo);
                return addedTrn;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error to adding data.");
            }
        }
    }
}
