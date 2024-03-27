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
    public class FolderAppsController : ControllerBase
    {
        private readonly ReysContext _context;

        public FolderAppsController(ReysContext context)
        {
            _context = context;
        }

        // GET: api/FolderApps
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<FolderApp>>> GetFolderApps()
        {
            return await _context.FolderApps.ToListAsync();
        }

        // GET: api/FolderApps/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<FolderApp>> GetFolderApp(int? id)
        {
            var folderApp = await _context.FolderApps.FindAsync(id);

            if (folderApp == null)
            {
                return NotFound();
            }

            return folderApp;
        }

        // PUT: api/FolderApps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutFolderApp(int? id, FolderApp folderApp)
        {
            if (id != folderApp.IdFolderApp)
            {
                return BadRequest();
            }

            _context.Entry(folderApp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FolderAppExists(id))
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

        // POST: api/FolderApps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<FolderApp>> PostFolderApp(FolderApp folderApp)
        {
            _context.FolderApps.Add(folderApp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFolderApp", new { id = folderApp.IdFolderApp }, folderApp);
        }

        // DELETE: api/FolderApps/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteFolderApp(int? id)
        {
            var folderApp = await _context.FolderApps.FindAsync(id);
            if (folderApp == null)
            {
                return NotFound();
            }

            _context.FolderApps.Remove(folderApp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FolderAppExists(int? id)
        {
            return _context.FolderApps.Any(e => e.IdFolderApp == id);
        }
    }
}
