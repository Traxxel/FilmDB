using Microsoft.AspNetCore.Mvc;
using FilmDB.DAL;
using FilmDB.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmDB.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GesehenController : ControllerBase
    {
        private readonly FilmDBContext _context;

        public GesehenController(FilmDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gesehen>>> GetGesehen()
        {
            return await _context.Gesehen.Include(g => g.GesehenBei).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Gesehen>> GetGesehen(int id)
        {
            var gesehen = await _context.Gesehen
                .Include(g => g.GesehenBei)
                .FirstOrDefaultAsync(g => g.ID == id);

            if (gesehen == null)
            {
                return NotFound();
            }

            return gesehen;
        }

        [HttpPost]
        public async Task<ActionResult<Gesehen>> PostGesehen(Gesehen gesehen)
        {
            _context.Gesehen.Add(gesehen);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGesehen), new { id = gesehen.ID }, gesehen);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGesehen(int id, Gesehen gesehen)
        {
            if (id != gesehen.ID)
            {
                return BadRequest();
            }

            _context.Entry(gesehen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GesehenExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGesehen(int id)
        {
            var gesehen = await _context.Gesehen.FindAsync(id);
            if (gesehen == null)
            {
                return NotFound();
            }

            _context.Gesehen.Remove(gesehen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GesehenExists(int id)
        {
            return _context.Gesehen.Any(e => e.ID == id);
        }
    }
} 