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
    public class BookMasterController:ControllerBase
    {
        private readonly IBookMasterRepository bookMasterRepository;

        public BookMasterController(IBookMasterRepository bookMasterRepository)
        {
            this.bookMasterRepository = bookMasterRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetBookMasters()
        {
            try
            {
                return Ok(await bookMasterRepository.GetBookMasters());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to find Books");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<BookMaster>> GetBookMaster(int id)
        {
            try
            {
                var BookResult= await bookMasterRepository.GetBookMaster(id);
                if (BookResult == null)
                {
                    return NotFound();
                }
                return BookResult;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Book not Found.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<BookMaster>> AddBookMaster(BookMaster newBook)
        {
            try
            {
                if (newBook == null)
                {
                    return BadRequest();
                }
                var CreatedBook = await bookMasterRepository.AddBookMaster(newBook);
                return CreatedAtAction(nameof(GetBookMaster), new { id = CreatedBook.BookMasterID }, CreatedBook);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to add Book Details.");
            }
        }
    }
}
