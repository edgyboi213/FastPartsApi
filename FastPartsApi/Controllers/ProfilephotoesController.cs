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
    public class ProfilephotoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProfilephotoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Profilephotoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profilephoto>>> GetProfilephotos()
        {
            return await _context.Profilephotos.ToListAsync();
        }

        // GET: api/Profilephotoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profilephoto>> GetProfilephoto(int id)
        {
            var profilephoto = await _context.Profilephotos.FindAsync(id);

            if (profilephoto == null)
            {
                return NotFound();
            }

            return profilephoto;
        }

        // PUT: api/Profilephotoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfilephoto(int id, Profilephoto profilephoto)
        {
            if (id != profilephoto.IdProfilePhoto)
            {
                return BadRequest();
            }

            _context.Entry(profilephoto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfilephotoExists(id))
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

        // POST: api/Profilephotoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Profilephoto>> PostProfilephoto(Profilephoto profilephoto)
        {
            _context.Profilephotos.Add(profilephoto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfilephoto", new { id = profilephoto.IdProfilePhoto }, profilephoto);
        }

        // DELETE: api/Profilephotoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfilephoto(int id)
        {
            var profilephoto = await _context.Profilephotos.FindAsync(id);
            if (profilephoto == null)
            {
                return NotFound();
            }

            _context.Profilephotos.Remove(profilephoto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfilephotoExists(int id)
        {
            return _context.Profilephotos.Any(e => e.IdProfilePhoto == id);
        }
    }
}
