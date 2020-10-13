using BSSApp.FA.Api.Models;
using BSSApp.FA.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Newtonsoft.Json;
using Microsoft.AspNetCore.JsonPatch.Adapters;





namespace BSSApp.FA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcMastersController: ControllerBase
    {
        private readonly IAcMasterRepository acMasterRepository;

        public AppDbContext AppDb { get; }

        public AcMastersController(IAcMasterRepository acMasterRepository,AppDbContext appDb)
        {
            this.acMasterRepository = acMasterRepository;
            AppDb = appDb;
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

        [HttpGet("updateAuth")]
        public async Task<AcMaster[]> Update_AcMaster_Auth(int id,string AuthBy,Boolean AuthAc,DateTime AuthDate)
        {
            return await acMasterRepository.UpdateAcMasterAuthorization_sp(id, AuthBy, AuthAc, AuthDate);
           
        }
        [HttpPatch("updatePatch/{id:int}")]
        public async Task<ActionResult> Patch_AcMaster(int id,[FromBody] JsonPatchDocument<AcMaster> patchDocument)
        {
            if (patchDocument == null)

            {
                return BadRequest();
            }
            var AcMasterFromDB = await acMasterRepository.GetAcMaster(id);
            if (AcMasterFromDB == null)
            {
                return NotFound();
            }
            
            patchDocument.ApplyTo(AcMasterFromDB);

            var isValid = TryValidateModel(AcMasterFromDB);

            if (!isValid)
            {
                return BadRequest(ModelState);
            }
            await AppDb.SaveChangesAsync();

            return NoContent();

            //[{ "op":"replace", "path":"/authorisedBy", "value": "Admin"},
            //{ "op":"replace","path":"/authorisedAc","value": true},
            //{ "op":"replace","path":"/authorisedDate","value": "2020-10-12"}]
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
