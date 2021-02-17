using Agent.Core.Interfaces;
using Agent.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Agent.Web.Api
{
    public class BookApiController : BaseApiController
    {
        private readonly IBookService _bookService;

        public BookApiController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/ToDoItems
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("GET Books");
        }

        // POST: api/ToDoItems
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookBuyingViewModel model)
        {
            var serviceResponse = await _bookService.BuyBookAsync(model.BookId, model.Email);
            return Ok(serviceResponse);
        }
    }
}
