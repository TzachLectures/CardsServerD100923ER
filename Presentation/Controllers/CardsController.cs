using CardsServerD100923ER.Core.Models;
using CardsServerD100923ER.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CardsServerD100923ER.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private CardsProjectDbContext _context;
        public CardsController(CardsProjectDbContext cardsProjectDbContext) { 
        _context= cardsProjectDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post (Card card)
        {
            _context.Cards.Add(card);
           await _context.SaveChangesAsync();
            return Ok(card);
        }
    }
}
