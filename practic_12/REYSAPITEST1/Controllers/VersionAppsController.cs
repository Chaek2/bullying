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
    public class VersionAppsController : ControllerBase
    {
        private readonly ReysContext _context;

        public VersionAppsController(ReysContext context)
        {
            _context = context;
        }

        // GET: api/VersionApps
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<VersionApp>>> GetVersionApps()
        {
            return await _context.VersionApps.ToListAsync();
        }

        // GET: api/VersionApps/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<VersionApp>> GetVersionApp(int? id)
        {
            var versionApp = await _context.VersionApps.FindAsync(id);

            if (versionApp == null)
            {
                return NotFound();
            }

            return versionApp;
        }

        // PUT: api/VersionApps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutVersionApp(int? id, VersionApp versionApp)
        {
            if (id != versionApp.IdVersionApp)
            {
                return BadRequest();
            }

            _context.Entry(versionApp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VersionAppExists(id))
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

        // POST: api/VersionApps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<VersionApp>> PostVersionApp(VersionApp versionApp)
        {
            _context.VersionApps.Add(versionApp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVersionApp", new { id = versionApp.IdVersionApp }, versionApp);
        }

        // DELETE: api/VersionApps/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteVersionApp(int? id)
        {
            var versionApp = await _context.VersionApps.FindAsync(id);
            if (versionApp == null)
            {
                return NotFound();
            }

            _context.VersionApps.Remove(versionApp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VersionAppExists(int? id)
        {
            return _context.VersionApps.Any(e => e.IdVersionApp == id);
        }
    }
}
