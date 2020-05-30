using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPI.Db;
using WEBAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        DataContext _db;
        public QuoteController(DataContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quote>>> Get()
        {
            await QuoteTimeChecker();
            return await _db.Quotes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Quote>> Get(int id)
        {
            await QuoteTimeChecker(); 
            var quote = await _db.Quotes.FirstOrDefaultAsync(q => q.Id == id);
            if (quote == null)
            {
                return NotFound("Quote with such id not found");
            }
            return quote;
        }

        [HttpPost]
        public async Task<ActionResult<Quote>> Post(Quote quote)
        {
            await QuoteTimeChecker(); 
            quote.InsertDate = DateTime.Now; 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Quotes.Add(quote);
            if (await _db.SaveChangesAsync() > 0)
            {
                return Ok("Inserted");
            }
            return BadRequest("Error while saving to database");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Quote>> Put(int id, Quote quote)
        {
            await QuoteTimeChecker(); 
            var tempQuote = await _db.Quotes.FindAsync(id);
            if ( tempQuote == null)
            {
                return NotFound("Quote with such id not found");
            }
            tempQuote.Author = quote.Author ?? tempQuote.Author;
            tempQuote.Text = quote.Text ?? tempQuote.Text;
            tempQuote.InsertDate = DateTime.Now; 

            if (await _db.SaveChangesAsync() > 0)
            {
                return Ok("Updated");
            }
            return BadRequest("Error while saving to database");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var quote = await _db.Quotes.FindAsync(id);
            if (quote == null)
            {
                return NotFound("Quote with such id not found");
            }
            _db.Remove(quote);
            if (await _db.SaveChangesAsync() > 0)
            {
                return Ok($"Quote with id = {id} deleted");
            }
            return BadRequest("Error while saving to database");
        }

        [NonAction]
        internal async Task QuoteTimeChecker()
        {
            var quotes = _db.Quotes.ToList();

            foreach (var quote in quotes)
            {
                if ((Math.Abs(quote.InsertDate.Month - DateTime.Now.Month) > 0
                    && quote.InsertDate.Year == DateTime.Now.Year) || Math.Abs(quote.InsertDate.Year - DateTime.Now.Year) > 0)
                {
                    _db.Quotes.Remove(quote);
                }
            }
        }
    }
}
