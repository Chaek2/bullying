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
    public class TagsController : ControllerBase
    {
        private readonly ReysContext _context;

        public TagsController(ReysContext context)
        {
            _context = context;
        }

        // GET: api/Tags
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Tag>>> GetTags()
        {
            return await _context.Tags.ToListAsync();
        }

        // GET: api/Tags/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Tag>> GetTag(string id)
        {
            List<Tag> tags = await _context.Tags.ToListAsync();
            Tag tag = tags.Find(p=> p.Title == id);
            //var tag = await _context.Tags.Where(p=>p.Title.Equals(id)).FirstOrDefaultAsync();
            //var tag = await _context.Tags.FindAsync(id);

            if (tag == null)
            {
                return NotFound();
            }

            return tag;
        }

        // PUT: api/Tags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutTag(string id, Tag tag)
        {
            if (id != tag.Title)
            {
                return BadRequest();
            }

            _context.Entry(tag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagExists(id))
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

        // POST: api/Tags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Tag>> PostTag(Tag tag)
        {
            _context.Tags.Add(tag);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TagExists(tag.Title))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTag", new { id = tag.Title }, tag);
        }

        // DELETE: api/Tags/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteTag(string id)
        {
            List<Tag> tags = await _context.Tags.ToListAsync();
            Tag tag = tags.Find(p => p.Title == id);
            //var tag = await _context.Tags.FindAsync(id);
            if (tag == null)
            {
                return NotFound();
            }

            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TagExists(string id)
        {
            return _context.Tags.Any(e => e.Title == id);
        }
    }
}
