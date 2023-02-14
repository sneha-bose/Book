using BooksAPI.Repository.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepositry;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepositry = bookRepository;
        }

        [HttpGet("GetBooks")]
        public async Task<IActionResult> GetAllKalpanTestPrepBooks()
        {
            try
            {
                var books = await _bookRepositry.GetAllKalpanTestPrepBooks();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
