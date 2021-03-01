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
    public class RecordDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RecordDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RecordDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecordDetails>>> GetRecordDetails()
        {
            return await _context.RecordDetails.ToListAsync();
        }

        // GET: api/RecordDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecordDetails>> GetRecordDetails(int id)
        {
            var recordDetails = await _context.RecordDetails.FindAsync(id);

            if (recordDetails == null)
            {
                return NotFound();
            }

            return recordDetails;
        }

        // PUT: api/RecordDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecordDetails(int id, RecordDetails recordDetails)
        {
            if (id != recordDetails.No)
            {
                return BadRequest();
            }

            _context.Entry(recordDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecordDetailsExists(id))
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

        // POST: api/RecordDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RecordDetails>> PostRecordDetails(RecordDetails recordDetails)
        {
            _context.RecordDetails.Add(recordDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecordDetails", new { id = recordDetails.No }, recordDetails);
        }

        // DELETE: api/RecordDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecordDetails(int id)
        {
            var recordDetails = await _context.RecordDetails.FindAsync(id);
            if (recordDetails == null)
            {
                return NotFound();
            }

            _context.RecordDetails.Remove(recordDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecordDetailsExists(int id)
        {
            return _context.RecordDetails.Any(e => e.No == id);
        }
    }
}
