using Microsoft.AspNetCore.Mvc;
using FilmDB.DAL;
using FilmDB.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmDB.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SenderController : ControllerBase
    {
        private readonly FilmDBContext _context;

        public SenderController(FilmDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sender>>> GetSender()
        {
            return await _context.Sender.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Sender>> PostSender(Sender sender)
        {
            _context.Sender.Add(sender);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSender), new { id = sender.ID }, sender);
        }
    }
} 