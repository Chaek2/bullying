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
    public class TagAppsController : ControllerBase
    {
        private readonly ReysContext _context;

        public TagAppsController(ReysContext context)
        {
            _context = context;
        }

        // GET: api/TagApps
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<TagApp>>> GetTagApps()
        {
            return await _context.TagApps.ToListAsync();
        }

        // GET: api/TagApps/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<TagApp>> GetTagApp(int? id)
        {
            var tagApp = await _context.TagApps.FindAsync(id);

            if (tagApp == null)
            {
                return NotFound();
            }

            return tagApp;
        }

        // PUT: api/TagApps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutTagApp(int? id, TagApp tagApp)
        {
            if (id != tagApp.IdTagApp)
            {
                return BadRequest();
            }

            _context.Entry(tagApp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagAppExists(id))
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

        // POST: api/TagApps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<TagApp>> PostTagApp(TagApp tagApp)
        {
            _context.TagApps.Add(tagApp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTagApp", new { id = tagApp.IdTagApp }, tagApp);
        }

        // DELETE: api/TagApps/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteTagApp(int? id)
        {
            var tagApp = await _context.TagApps.FindAsync(id);
            if (tagApp == null)
            {
                return NotFound();
            }

            _context.TagApps.Remove(tagApp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TagAppExists(int? id)
        {
            return _context.TagApps.Any(e => e.IdTagApp == id);
        }
    }
}
