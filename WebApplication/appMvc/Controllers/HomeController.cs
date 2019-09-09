using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using appMvc.Models;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using appMvc.exe;
namespace appMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("User")!= null)
            {
                user user = JsonConvert.DeserializeObject<user>(HttpContext.Session.GetString("User"));//PaHttpContext.Session.GetString("User");
                ViewBag.User = user.userName;
            }
            
            return View();
        }
        
        public ActionResult LogOut()
        {
            HttpContext.Session.Remove("User");
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public string Hesap(Veri v)
        {
            Calculation cal = new Calculation(v);
            string s = cal.Hesap()+" "+cal.toplamGeriodeme +" "+ cal.taksitTutar();
            return s;
        }
        
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        

    }
}
