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
    public class InfoFASAsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InfoFASAsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/InfoFASAs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfoFASA>>> GetInfoFASAs()
        {
            return await _context.InfoFASAs.ToListAsync();
        }

        // GET: api/InfoFASAs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InfoFASA>> GetInfoFASA(int id)
        {
            var infoFASA = await _context.InfoFASAs.FindAsync(id);

            if (infoFASA == null)
            {
                return NotFound();
            }

            return infoFASA;
        }

        // PUT: api/InfoFASAs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfoFASA(int id, InfoFASA infoFASA)
        {
            if (id != infoFASA.IfFASA_id)
            {
                return BadRequest();
            }

            _context.Entry(infoFASA).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfoFASAExists(id))
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

        // POST: api/InfoFASAs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InfoFASA>> PostInfoFASA(InfoFASA infoFASA)
        {
            _context.InfoFASAs.Add(infoFASA);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInfoFASA", new { id = infoFASA.IfFASA_id }, infoFASA);
        }

        // DELETE: api/InfoFASAs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInfoFASA(int id)
        {
            var infoFASA = await _context.InfoFASAs.FindAsync(id);
            if (infoFASA == null)
            {
                return NotFound();
            }

            _context.InfoFASAs.Remove(infoFASA);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InfoFASAExists(int id)
        {
            return _context.InfoFASAs.Any(e => e.IfFASA_id == id);
        }
    }
}
