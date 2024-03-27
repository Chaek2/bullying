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
    public class CategoryAppsController : ControllerBase
    {
        private readonly ReysContext _context;

        public CategoryAppsController(ReysContext context)
        {
            _context = context;
        }

        // GET: api/CategoryApps
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<CategoryApp>>> GetCategoryApps()
        {
            return await _context.CategoryApps.ToListAsync();
        }

        // GET: api/CategoryApps/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<CategoryApp>> GetCategoryApp(int? id)
        {
            var categoryApp = await _context.CategoryApps.FindAsync(id);

            if (categoryApp == null)
            {
                return NotFound();
            }

            return categoryApp;
        }

        // PUT: api/CategoryApps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutCategoryApp(int? id, CategoryApp categoryApp)
        {
            if (id != categoryApp.IdCategoryApp)
            {
                return BadRequest();
            }

            _context.Entry(categoryApp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryAppExists(id))
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

        // POST: api/CategoryApps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CategoryApp>> PostCategoryApp(CategoryApp categoryApp)
        {
            _context.CategoryApps.Add(categoryApp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoryApp", new { id = categoryApp.IdCategoryApp }, categoryApp);
        }

        // DELETE: api/CategoryApps/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteCategoryApp(int? id)
        {
            var categoryApp = await _context.CategoryApps.FindAsync(id);
            if (categoryApp == null)
            {
                return NotFound();
            }

            _context.CategoryApps.Remove(categoryApp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryAppExists(int? id)
        {
            return _context.CategoryApps.Any(e => e.IdCategoryApp == id);
        }
    }
}
