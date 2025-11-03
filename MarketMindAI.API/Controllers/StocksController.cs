using MarketMind.API.Data;
using MarketMind.ML.Contracts.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketMindAI.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class StocksController : Controller
    {
        private readonly AppDbContext _context;
        public StocksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _context.Stocks.ToListAsync();
            return Ok(stocks);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Stock stock)
        {
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = stock.Id }, stock);
        }

    }
}
