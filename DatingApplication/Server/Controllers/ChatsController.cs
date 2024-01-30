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
    public class ChatsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public ChatsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Chats
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Chat>>> GetChats()
        public async Task<IActionResult> GetChats()
        {
            //if (_context.Chats == null)
            //{
            //    return NotFound();
            //}
            //return await _context.Chats.ToListAsync();
            var chats = await _unitOfWork.Chats.GetAll();
            return Ok(chats);
        }

        // GET: api/Chats/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Chat>> GetChat(int id)
        public async Task<IActionResult> GetChats(int id)
        {
            var chat = await _unitOfWork.Chats.Get(q => q.Id == id);
            if (chat == null)
            {
                return NotFound();
            }
            return Ok(chat);
        }
        //{
        //  if (_context.Chats == null)
        //  {
        //      return NotFound();
        //  }
        //    var Chat = await _context.Chats.FindAsync(id);

        //    if (Chat == null)
        //    {
        //        return NotFound();
        //    }

        //    return Chat;
        //}

        // PUT: api/Chats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChat(int id, Chat chat)
        {
            if (id != chat.Id)
            {
                return BadRequest();
            }

            //_context.Entry(Chat).State = EntityState.Modified;
            _unitOfWork.Chats.Update(chat);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!ChatExists(id))
                if (!await ChatExists(id))
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

        // POST: api/Chats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Chat>> PostChat(Chat chat)
        {
            //if (_context.Chats == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.Chats'  is null.");
            //}
            //  _context.Chats.Add(Chat);
            //  await _context.SaveChangesAsync();

            //  return CreatedAtAction("GetChat", new { id = Chat.Id }, Chat);
            await _unitOfWork.Chats.Insert(chat);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetChat", new { id = chat.Id, }, chat);

        }

        // DELETE: api/Chats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChat(int id)
        {
            //if (_context.Chats == null)
            //{
            //    return NotFound();
            //}
            //var Chat = await _context.Chats.FindAsync(id);
            var chat = _unitOfWork.Chats.Get(q => q.Id == id);
            if (chat == null)
            {
                return NotFound();
            }

            //_context.Chats.Remove(Chat);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Chats.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> ChatExists(int id)
        {
            //return (_context.Chats?.Any(e => e.Id == id)).GetValueOrDefault();
            var chat = await _unitOfWork.Chats.Get(q => q.Id == id);
            return chat != null;
        }
    }
}
