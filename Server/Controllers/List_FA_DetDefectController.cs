using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorWASM_SignalR.Server.Data;
using BlazorWASM_SignalR.Shared;

namespace BlazorWASM_SignalR.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class List_FA_DetDefectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public List_FA_DetDefectController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/List_FA_DetDefect
        [HttpGet]
        public async Task<ActionResult<IEnumerable<List_FA_DetDefect>>> GetList_FA_DetDefects()
        {
            return await _context.List_FA_DetDefects.ToListAsync();
        }

        // GET: api/List_FA_DetDefect/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List_FA_DetDefect>> GetList_FA_DetDefect(int id)
        {
            var list_FA_DetDefect = await _context.List_FA_DetDefects.FindAsync(id);

            if (list_FA_DetDefect == null)
            {
                return NotFound();
            }

            return list_FA_DetDefect;
        }

        // PUT: api/List_FA_DetDefect/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutList_FA_DetDefect(int id, List_FA_DetDefect list_FA_DetDefect)
        {
            if (id != list_FA_DetDefect.Id_FA_DetDefect)
            {
                return BadRequest();
            }

            _context.Entry(list_FA_DetDefect).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!List_FA_DetDefectExists(id))
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

        // POST: api/List_FA_DetDefect
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<List_FA_DetDefect>> PostList_FA_DetDefect(List_FA_DetDefect list_FA_DetDefect)
        {
            _context.List_FA_DetDefects.Add(list_FA_DetDefect);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetList_FA_DetDefect", new { id = list_FA_DetDefect.Id_FA_DetDefect }, list_FA_DetDefect);
        }

        // DELETE: api/List_FA_DetDefect/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteList_FA_DetDefect(int id)
        {
            var list_FA_DetDefect = await _context.List_FA_DetDefects.FindAsync(id);
            if (list_FA_DetDefect == null)
            {
                return NotFound();
            }

            _context.List_FA_DetDefects.Remove(list_FA_DetDefect);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool List_FA_DetDefectExists(int id)
        {
            return _context.List_FA_DetDefects.Any(e => e.Id_FA_DetDefect == id);
        }
    }
}
