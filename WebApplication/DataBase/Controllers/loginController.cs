using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class loginController : ControllerBase
    {
        private readonly appContext _context;
        public loginController(appContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<user>> Postuser(userLogin u)
        {
            List<user> users = await _context.Users.ToListAsync();
            user user = (user)users.Find(p => p.email == u.email);
            if (user == null)
            {
                return NotFound();
            }
            else if (user.email == u.email && user.pass == u.pass)
            {
                accountType a = await _context.Accounts.FindAsync(user.accountId);
                user.account = a;
                return user;
            }
            else
                return NotFound();
        }
    }
}