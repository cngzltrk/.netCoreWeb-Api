using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataBase.Models;

namespace DataBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : ControllerBase
    {
        private readonly appContext _context;

        public usersController(appContext context)
        {
            _context = context;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<user>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<user>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
            /*//var user = await _context.Users.FindAsync();
            List<user> users= await _context.Users.ToListAsync();
            user user = (user)users.Find(p => p.email == u.email);
            if (user == null)
            {
                return NotFound();
            }
            else if(user.email==u.email&&user.pass==u.pass)
            {
                accountType a = await _context.Accounts.FindAsync(user.accountId);
                user.account = a;
                return user;
            }
            else
                return NotFound();*/
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putuser(int id, user user)
        {
            if (id != user.ID)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userExists(id))
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

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<user>> Postuser(user user)
        {
            user.accountId = 1;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getuser", new { id = user.ID }, user);
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<user>> Deleteuser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool userExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }
    }
}
