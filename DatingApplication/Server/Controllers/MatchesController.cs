using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatingApplication.Server.Data;
using DatingApplication.Shared.Domain;
using DatingApplication.Server.IRepository;
using DatingApplication.Server.Repository;

namespace DatingApplication.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public MatchesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Matches
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Match>>> GetMatches()
        public async Task<IActionResult> GetMatches()
        {
            //if (_context.Matches == null)
            //{
            //    return NotFound();
            //}
            //return await _context.Matches.ToListAsync();
            var matches = await _unitOfWork.Matches.GetAll(includes: q => q.Include(x => x.DatingAppUserInitiator).Include(x => x.DatingAppUserReciever));
            return Ok(matches);
        }

        // GET: api/Matches/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Match>> GetMatch(int id)
        public async Task<IActionResult> GetMatch(int id)
        {
            var match = await _unitOfWork.Matches.Get(q => q.Id == id);
            if (match == null)
            {
                return NotFound();
            }
            return Ok(match);
        }
        //{
        //  if (_context.Matches == null)
        //  {
        //      return NotFound();
        //  }
        //    var Match = await _context.Matches.FindAsync(id);

        //    if (Match == null)
        //    {
        //        return NotFound();
        //    }

        //    return Match;
        //}

        // PUT: api/Matches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatch(int id, Match match)
        {
            if (id != match.Id)
            {
                return BadRequest();
            }

            //_context.Entry(Match).State = EntityState.Modified;
            _unitOfWork.Matches.Update(match);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!MatchExists(id))
                if (!await MatchExists(id))
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

        // POST: api/Matches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Match>> PostMatch(Match match)
        {
            //if (_context.Matches == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.Matches'  is null.");
            //}
            //  _context.Matches.Add(Match);
            //  await _context.SaveChangesAsync();

            //  return CreatedAtAction("GetMatch", new { id = Match.Id }, Match);
            await _unitOfWork.Matches.Insert(match);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetMatch", new { id = match.Id }, match);

        }

        // DELETE: api/Matches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatch(int id)
        {
            //if (_context.Matches == null)
            //{
            //    return NotFound();
            //}
            //var Match = await _context.Matches.FindAsync(id);
            var match = _unitOfWork.Matches.Get(q => q.Id == id);
            if (match == null)
            {
                return NotFound();
            }

            //_context.Matches.Remove(Match);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Matches.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> MatchExists(int id)
        {
            //return (_context.Matches?.Any(e => e.Id == id)).GetValueOrDefault();
            var match = await _unitOfWork.Matches.Get(q => q.Id == id);
            return match != null;
        }
    }
}

