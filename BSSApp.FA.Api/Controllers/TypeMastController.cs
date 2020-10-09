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

    public class TypeMastController:ControllerBase
    {
        private readonly ITypeMastRepository typeMastRepository;

        public TypeMastController(ITypeMastRepository typeMastRepository)
        {
            this.typeMastRepository = typeMastRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetTypeMasts()
        {
            try
            {
                return Ok(await typeMastRepository.GetTypeMasts());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error retrieving data from database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TypeMast>> GetTypeMast(int id)
        {
            try
            {
                var result= await typeMastRepository.GetTypeMast(id);
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
    }
}
