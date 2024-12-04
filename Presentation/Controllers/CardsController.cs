using CardsServerD100923ER.Core.Models;
using CardsServerD100923ER.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
        [Authorize(Policy ="MustBeBusiness")]
        public async Task<IActionResult> Post (Card card)
        {
            Claim? userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "_id");
            card.UserId = userIdClaim.Value;

            _context.Cards.Add(card);
           await _context.SaveChangesAsync();
            return Ok(card);
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Card> result = await _context.Cards.ToListAsync();
                if (result == null)
                {
                    return Ok(new List<Card>());
                }
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest();

            }
        }
    }
}
