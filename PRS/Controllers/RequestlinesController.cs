using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRS.Data;
using PRS.Models;

namespace PRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestlinesController : ControllerBase
    {
        private readonly PRSDbContext _context;

        public RequestlinesController(PRSDbContext context)
        {
            _context = context;
        }

        // GET: api/Requestlines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Requestline>>> GetRequestline()
        {
            return await _context.Requestline.ToListAsync();
        }

        // GET: api/Requestlines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Requestline>> GetRequestline(int id)
        {
            var requestline = await _context.Requestline.FindAsync(id);

            if (requestline == null)
            {
                return NotFound();
            }

            return requestline;
        }



        [HttpPut("TOTAL")]

        private async Task RecalculateTotal(int requestId) {
            var request = await _context.Request.FindAsync(requestId);
            if (request == null) throw new Exception("Request not found.");
            request.Total = (from rl in request.Requestlines
                             select new {
                                 Subtotal = rl.Quantity * rl.Product.Price
                             }).Sum(x => x.Subtotal);
            await _context.SaveChangesAsync();

        }

        private async Task RefreshRequestline(Requestline requestline) {
            _context.Entry(requestline).State = EntityState.Detached;
            await _context.Requestline.FindAsync(requestline.Id);
        }

            // PUT: api/Requestlines/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

            [HttpPut("{id}")]
        public async Task<IActionResult> PutRequestline(int id, Requestline requestline)
        {
            if (id != requestline.Id)
            {
                return BadRequest();
            }

            _context.Entry(requestline).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestlineExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            await RefreshRequestline(requestline);
            await RecalculateTotal(requestline.RequestId);
            return NoContent();
        }

        // POST: api/Requestlines
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Requestline>> PostRequestline(Requestline requestline)
        {
            _context.Requestline.Add(requestline);
            await _context.SaveChangesAsync();

            await RefreshRequestline(requestline);
            await RecalculateTotal(requestline.RequestId);

            return CreatedAtAction("GetRequestline", new { id = requestline.Id }, requestline);
        }

        // DELETE: api/Requestlines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Requestline>> DeleteRequestline(int id)
        {
            var requestline = await _context.Requestline.FindAsync(id);
            if (requestline == null)
            {
                return NotFound();
            }

            _context.Requestline.Remove(requestline);
            await _context.SaveChangesAsync();

            return requestline;
        }

        private bool RequestlineExists(int id)
        {
            return _context.Requestline.Any(e => e.Id == id);
        }
    }
}
