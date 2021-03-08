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
    public class SharedDetailDefectListsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SharedDetailDefectListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SharedDetailDefectLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SharedDetailDefectList>>> GetSharedDetailDefectLists()
        {
            return await _context.SharedDetailDefectLists.ToListAsync();
        }

        // GET: api/SharedDetailDefectLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SharedDetailDefectList>> GetSharedDetailDefectList(string id)
        {
            var sharedDetailDefectList = await _context.SharedDetailDefectLists.FindAsync(id);

            if (sharedDetailDefectList == null)
            {
                return NotFound();
            }

            return sharedDetailDefectList;
        }

        // PUT: api/SharedDetailDefectLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSharedDetailDefectList(string id, SharedDetailDefectList sharedDetailDefectList)
        {
            if (id != sharedDetailDefectList.DetailDefect)
            {
                return BadRequest();
            }

            _context.Entry(sharedDetailDefectList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SharedDetailDefectListExists(id))
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

        // POST: api/SharedDetailDefectLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SharedDetailDefectList>> PostSharedDetailDefectList(SharedDetailDefectList sharedDetailDefectList)
        {
            _context.SharedDetailDefectLists.Add(sharedDetailDefectList);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SharedDetailDefectListExists(sharedDetailDefectList.DetailDefect))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSharedDetailDefectList", new { id = sharedDetailDefectList.DetailDefect }, sharedDetailDefectList);
        }

        // DELETE: api/SharedDetailDefectLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSharedDetailDefectList(string id)
        {
            var sharedDetailDefectList = await _context.SharedDetailDefectLists.FindAsync(id);
            if (sharedDetailDefectList == null)
            {
                return NotFound();
            }

            _context.SharedDetailDefectLists.Remove(sharedDetailDefectList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SharedDetailDefectListExists(string id)
        {
            return _context.SharedDetailDefectLists.Any(e => e.DetailDefect == id);
        }
    }
}
