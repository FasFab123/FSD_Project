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
    public class UserProfilesController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public UserProfilesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/UserProfiles
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<UserProfile>>> GetUserProfiles()
        public async Task<IActionResult> GetUserProfiles()
        {
            //if (_context.UserProfiles == null)
            //{
            //    return NotFound();
            //}
            //return await _context.UserProfiles.ToListAsync();
            var userprofiles = await _unitOfWork.UserProfiles.GetAll(includes: q => q.Include(x => x.DatingAppUser));
            return Ok(userprofiles);
        }

        // GET: api/UserProfiles/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<UserProfile>> GetUserProfile(int id)
        public async Task<IActionResult> GetUserProfile(int id)
        {
            var userprofile = await _unitOfWork.UserProfiles.Get(q => q.Id == id);
            if (userprofile == null)
            {
                return NotFound();
            }
            return Ok(userprofile);
        }
        //{
        //  if (_context.UserProfiles == null)
        //  {
        //      return NotFound();
        //  }
        //    var UserProfile = await _context.UserProfiles.FindAsync(id);

        //    if (UserProfile == null)
        //    {
        //        return NotFound();
        //    }

        //    return UserProfile;
        //}

        // PUT: api/UserProfiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserProfile(int id, UserProfile userprofile)
        {
            if (id != userprofile.Id)
            {
                return BadRequest();
            }

            //_context.Entry(UserProfile).State = EntityState.Modified;
            _unitOfWork.UserProfiles.Update(userprofile);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!UserProfileExists(id))
                if (!await UserProfileExists(id))
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

        // POST: api/UserProfiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserProfile>> PostUserProfile(UserProfile userprofile)
        {
            //if (_context.UserProfiles == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.UserProfiles'  is null.");
            //}
            //  _context.UserProfiles.Add(UserProfile);
            //  await _context.SaveChangesAsync();

            //  return CreatedAtAction("GetUserProfile", new { id = UserProfile.Id }, UserProfile);
            await _unitOfWork.UserProfiles.Insert(userprofile);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetUserProfile", new { id = userprofile.Id, }, userprofile);

        }

        // DELETE: api/UserProfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserProfile(int id)
        {
            //if (_context.UserProfiles == null)
            //{
            //    return NotFound();
            //}
            //var UserProfile = await _context.UserProfiles.FindAsync(id);
            var userprofile = _unitOfWork.UserProfiles.Get(q => q.Id == id);
            if (userprofile == null)
            {
                return NotFound();
            }

            //_context.UserProfiles.Remove(UserProfile);
            //await _context.SaveChangesAsync();
            await _unitOfWork.UserProfiles.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> UserProfileExists(int id)
        {
            //return (_context.UserProfiles?.Any(e => e.Id == id)).GetValueOrDefault();
            var userprofile = await _unitOfWork.UserProfiles.Get(q => q.Id == id);
            return userprofile != null;
        }
    }
}
