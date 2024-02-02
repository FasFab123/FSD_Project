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
    public class DatingAppUsersController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public DatingAppUsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/DatingAppUsers
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<DatingAppUser>>> GetDatingAppUsers()
        public async Task<IActionResult> GetDatingAppUsers()
        {
            //if (_context.DatingAppUsers == null)
            //{
            //    return NotFound();
            //}
            //return await _context.DatingAppUsers.ToListAsync();
            var datingappusers = await _unitOfWork.DatingAppUsers.GetAll(includes: q => q.Include(x => x.UserProfiles).Include(x => x.Matches));
            return Ok(datingappusers);
        }

        // GET: api/DatingAppUsers/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<DatingAppUser>> GetDatingAppUser(int id)
        public async Task<IActionResult> GetDatingAppUser(int id)
        {
            var datingappuser = await _unitOfWork.DatingAppUsers.Get(q => q.Id == id);
            if(datingappuser == null)
            {
                return NotFound();
            }
            return Ok(datingappuser);
        }
        //{
        //  if (_context.DatingAppUsers == null)
        //  {
        //      return NotFound();
        //  }
        //    var datingAppUser = await _context.DatingAppUsers.FindAsync(id);

        //    if (datingAppUser == null)
        //    {
        //        return NotFound();
        //    }

        //    return datingAppUser;
        //}

        // PUT: api/DatingAppUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDatingAppUser(int id, DatingAppUser datingappuser)
        {
            if (id != datingappuser.Id)
            {
                return BadRequest();
            }

            //_context.Entry(datingAppUser).State = EntityState.Modified;
            _unitOfWork.DatingAppUsers.Update(datingappuser);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!DatingAppUserExists(id))
                if(!await DatingAppUserExists(id))
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

        // POST: api/DatingAppUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DatingAppUser>> PostDatingAppUser(DatingAppUser datingappuser)
        {
          //if (_context.DatingAppUsers == null)
          //{
          //    return Problem("Entity set 'ApplicationDbContext.DatingAppUsers'  is null.");
          //}
          //  _context.DatingAppUsers.Add(datingAppUser);
          //  await _context.SaveChangesAsync();

          //  return CreatedAtAction("GetDatingAppUser", new { id = datingAppUser.Id }, datingAppUser);
          await _unitOfWork.DatingAppUsers.Insert(datingappuser);
          await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetDatingAppUser", new { id = datingappuser.Id }, datingappuser);
       
        }

        // DELETE: api/DatingAppUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDatingAppUser(int id)
        {
            //if (_context.DatingAppUsers == null)
            //{
            //    return NotFound();
            //}
            //var datingAppUser = await _context.DatingAppUsers.FindAsync(id);
            var datingappuser = _unitOfWork.DatingAppUsers.Get(q => q.Id == id);
            if (datingappuser == null)
            {
                return NotFound();
            }

            //_context.DatingAppUsers.Remove(datingAppUser);
            //await _context.SaveChangesAsync();
            await _unitOfWork.DatingAppUsers.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> DatingAppUserExists(int id)
        {
            //return (_context.DatingAppUsers?.Any(e => e.Id == id)).GetValueOrDefault();
            var datingappuser = await _unitOfWork.DatingAppUsers.Get(q =>q.Id == id);
            return datingappuser != null;
        }
    }
}
