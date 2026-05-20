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
    public class OrderpartsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderpartsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Orderparts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orderpart>>> GetOrderparts()
        {
            return await _context.Orderparts.ToListAsync();
        }

        // GET: api/Orderparts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Orderpart>> GetOrderpart(int id)
        {
            var orderpart = await _context.Orderparts.FindAsync(id);

            if (orderpart == null)
            {
                return NotFound();
            }

            return orderpart;
        }

        // PUT: api/Orderparts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderpart(int id, Orderpart orderpart)
        {
            if (id != orderpart.IdOrder)
            {
                return BadRequest();
            }

            _context.Entry(orderpart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderpartExists(id))
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

        // POST: api/Orderparts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Orderpart>> PostOrderpart(Orderpart orderpart)
        {
            _context.Orderparts.Add(orderpart);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrderpartExists(orderpart.IdOrder))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrderpart", new { id = orderpart.IdOrder }, orderpart);
        }

        // DELETE: api/Orderparts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderpart(int id)
        {
            var orderpart = await _context.Orderparts.FindAsync(id);
            if (orderpart == null)
            {
                return NotFound();
            }

            _context.Orderparts.Remove(orderpart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderpartExists(int id)
        {
            return _context.Orderparts.Any(e => e.IdOrder == id);
        }
    }
}
