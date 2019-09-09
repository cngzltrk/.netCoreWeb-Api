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
    public class interestsController : ControllerBase
    {
        private readonly appContext _context;
        public interestsController(appContext context)
        {
            _context = context;
        }
        // GET: api/interests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<interest>>> Getinterests()
        {
            return await _context.interests.ToListAsync();
        }
        // GET: api/interests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<interest>> Getinterest(int id,int aId,int cId)
        {
            List<interest> interests = await _context.interests.ToListAsync();
            interest interest = (interest)interests.Find(p => p.creditId == cId && p.accountId==aId);
            if (interest == null)
            {
                return NotFound();
            }
            return interest;
            /*var interest = await _context.interests.FindAsync(id);

            if (interest == null)
            {
                return NotFound();
            }*/
        }
        // PUT: api/interests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putinterest(int id, interest interest)
        {
            if (id != interest.ID)
            {
                return BadRequest();
            }

            _context.Entry(interest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!interestExists(id))
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

        // POST: api/interests
        [HttpPost]
        public async Task<ActionResult<interest>> Postinterest(interest interest)
        {
            _context.interests.Add(interest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getinterest", new { id = interest.ID }, interest);
        }

        // DELETE: api/interests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<interest>> Deleteinterest(int id)
        {
            var interest = await _context.interests.FindAsync(id);
            if (interest == null)
            {
                return NotFound();
            }

            _context.interests.Remove(interest);
            await _context.SaveChangesAsync();

            return interest;
        }

        private bool interestExists(int id)
        {
            return _context.interests.Any(e => e.ID == id);
        }
    }
}
