using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FastPartsApi.Data;
using FastPartsApi.Models;

namespace FastPartsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OemnumbersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OemnumbersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Oemnumbers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Oemnumber>>> GetOemnumbers()
        {
            return await _context.Oemnumbers.ToListAsync();
        }

        // GET: api/Oemnumbers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Oemnumber>> GetOemnumber(int id)
        {
            var oemnumber = await _context.Oemnumbers.FindAsync(id);

            if (oemnumber == null)
            {
                return NotFound();
            }

            return oemnumber;
        }

        // PUT: api/Oemnumbers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOemnumber(int id, Oemnumber oemnumber)
        {
            if (id != oemnumber.IdOemNumber)
            {
                return BadRequest();
            }

            _context.Entry(oemnumber).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OemnumberExists(id))
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

        // POST: api/Oemnumbers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Oemnumber>> PostOemnumber(Oemnumber oemnumber)
        {
            _context.Oemnumbers.Add(oemnumber);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOemnumber", new { id = oemnumber.IdOemNumber }, oemnumber);
        }

        // DELETE: api/Oemnumbers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOemnumber(int id)
        {
            var oemnumber = await _context.Oemnumbers.FindAsync(id);
            if (oemnumber == null)
            {
                return NotFound();
            }

            _context.Oemnumbers.Remove(oemnumber);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OemnumberExists(int id)
        {
            return _context.Oemnumbers.Any(e => e.IdOemNumber == id);
        }
    }
}
