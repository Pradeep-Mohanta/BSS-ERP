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
    public class AcMastersController: ControllerBase
    {
        private readonly IAcMasterRepository acMasterRepository;

        public AcMastersController(IAcMasterRepository acMasterRepository)
        {
            this.acMasterRepository = acMasterRepository;
        }
        [HttpGet("{accountsearch}")]
        public async Task<ActionResult<IEnumerable<AcMaster>>> AccountSearch(string ledgerCode)
        {
            try
            {
                var searchResult=await acMasterRepository.AccountSearch(ledgerCode);
                if (searchResult.Any())
                {
                    return Ok(searchResult);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error for searching data from database");
            }
        }
        
        [HttpGet]
        public async Task<ActionResult> GetAcMasters()
        {
            try
            {
                return Ok(await acMasterRepository.GetAcMasters());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database for AcMaster");
            }
        }

        [HttpGet("maxacno")]
        public async Task<ActionResult> GetAcMasterMaxAcno(string gcode)
        {
            return Ok(await acMasterRepository.GetMaxAccountNo(gcode));
        }

        [HttpGet("maxacnosp")]
        public async Task<AcMaster[]> GetMaxAcno(string gcode)
        {
            return await acMasterRepository.GetMaxAcNo_sp(gcode);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AcMaster>> GetAcMaster(int id)
        {
            try
            {
                var result=await acMasterRepository.GetAcMaster(id);
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

        [HttpPost]
        public async Task<ActionResult<AcMaster>> AddAcMaster (AcMaster acMaster)
        {
            try
            {
                if (acMaster == null)
                {
                    return BadRequest();
                }
                var CreatedAccount=await acMasterRepository.AddAcMaster(acMaster);

                return CreatedAtAction(nameof(GetAcMaster), new { id = CreatedAccount.AcMasterID }, CreatedAccount);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }

        }

        [HttpPut()]
        public async Task<ActionResult<AcMaster>> UpdateAcMaster(AcMaster acMaster)
        {
            try
            {
                //if (id != acMaster.AcMasterID)
                //{
                //    return BadRequest("Account ID mismatch");
                //}
                var accountToUpdate=await acMasterRepository.GetAcMaster(acMaster.AcMasterID);
                if (accountToUpdate == null)
                {
                    return NotFound($"Account Id={acMaster.AcMasterID} not found");
                }
                return await acMasterRepository.UpdateAcMaster(acMaster);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<AcMaster>> DeleteAccount(int id)
        {
            try
            {
                var accountToDelete=await acMasterRepository.GetAcMaster(id);
                if (accountToDelete == null)
                {
                    return NotFound($"Account with id={id} not found");
                }
                return await acMasterRepository.DeleteAcMaster(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleteing data");
            }
        }
    }
}
