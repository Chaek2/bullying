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
    public class VersionsController : ControllerBase
    {
        private readonly ReysContext _context;

        public VersionsController(ReysContext context)
        {
            _context = context;
        }

        // GET: api/Versions
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Models.Version>>> GetVersions()
        {
            return await _context.Versions.ToListAsync();
        }

        // GET: api/Versions/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Models.Version>> GetVersion(int? id)
        {
            var version = await _context.Versions.FindAsync(id);

            if (version == null)
            {
                return NotFound();
            }

            return version;
        }

        // PUT: api/Versions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutVersion(int? id, Models.Version version)
        {
            if (id != version.IdVersion)
            {
                return BadRequest();
            }

            _context.Entry(version).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VersionExists(id))
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

        // POST: api/Versions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Models.Version>> PostVersion(Models.Version version)
        {
            _context.Versions.Add(version);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVersion", new { id = version.IdVersion }, version);
        }

        // DELETE: api/Versions/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteVersion(int? id)
        {
            var version = await _context.Versions.FindAsync(id);
            if (version == null)
            {
                return NotFound();
            }

            _context.Versions.Remove(version);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VersionExists(int? id)
        {
            return _context.Versions.Any(e => e.IdVersion == id);
        }
    }
}
