using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REYSAPITEST1.Models;

namespace REYSAPITEST1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaitingsController : ControllerBase
    {
        private readonly ReysContext _context;

        public RaitingsController(ReysContext context)
        {
            _context = context;
        }

        // GET: api/Raitings
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Raiting>>> GetRaitings()
        {
            return await _context.Raitings.ToListAsync();
        }

        // GET: api/Raitings/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Raiting>> GetRaiting(int? id)
        {
            var raiting = await _context.Raitings.FindAsync(id);

            if (raiting == null)
            {
                return NotFound();
            }

            return raiting;
        }

        // PUT: api/Raitings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutRaiting(int? id, Raiting raiting)
        {
            if (id != raiting.IdRaiting)
            {
                return BadRequest();
            }

            _context.Entry(raiting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaitingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Raitings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Raiting>> PostRaiting(Raiting raiting)
        {
            _context.Raitings.Add(raiting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRaiting", new { id = raiting.IdRaiting }, raiting);
        }

        // DELETE: api/Raitings/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteRaiting(int? id)
        {
            var raiting = await _context.Raitings.FindAsync(id);
            if (raiting == null)
            {
                return NotFound();
            }

            _context.Raitings.Remove(raiting);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RaitingExists(int? id)
        {
            return _context.Raitings.Any(e => e.IdRaiting == id);
        }
    }
}
