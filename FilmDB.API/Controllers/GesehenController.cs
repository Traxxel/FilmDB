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

        [HttpPost]
        public async Task<ActionResult<Gesehen>> PostGesehen(Gesehen gesehen)
        {
            _context.Gesehen.Add(gesehen);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGesehen), new { id = gesehen.ID }, gesehen);
        }
    }
} 