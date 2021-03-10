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
    public class SharedBakingRecordsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SharedBakingRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SharedBakingRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SharedBakingRecord>>> GetSharedBakingRecords()
        {
            return await _context.SharedBakingRecords.ToListAsync();
        }

        // GET: api/SharedBakingRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SharedBakingRecord>> GetSharedBakingRecord(int id)
        {
            var sharedBakingRecord = await _context.SharedBakingRecords.FindAsync(id);

            if (sharedBakingRecord == null)
            {
                return NotFound();
            }

            return sharedBakingRecord;
        }

        // PUT: api/SharedBakingRecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSharedBakingRecord(int id, SharedBakingRecord sharedBakingRecord)
        {
            if (id != sharedBakingRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(sharedBakingRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SharedBakingRecordExists(id))
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

        // POST: api/SharedBakingRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SharedBakingRecord>> PostSharedBakingRecord(SharedBakingRecord sharedBakingRecord)
        {
            _context.SharedBakingRecords.Add(sharedBakingRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSharedBakingRecord", new { id = sharedBakingRecord.Id }, sharedBakingRecord);
        }

        // DELETE: api/SharedBakingRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSharedBakingRecord(int id)
        {
            var sharedBakingRecord = await _context.SharedBakingRecords.FindAsync(id);
            if (sharedBakingRecord == null)
            {
                return NotFound();
            }

            _context.SharedBakingRecords.Remove(sharedBakingRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SharedBakingRecordExists(int id)
        {
            return _context.SharedBakingRecords.Any(e => e.Id == id);
        }
    }
}
