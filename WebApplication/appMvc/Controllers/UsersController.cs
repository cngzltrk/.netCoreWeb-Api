using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using appMvc.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace appMvc.Controllers
{
    public class UsersController : Controller
    {
        //public IActionResult Index()
        //{
        //    user users;
        //    HttpResponseMessage response = GlobalVeriables.wepApiClient.GetAsync("users").Result;

        //    users = response.Content.ReadAsAsync<user>().Result;
        //    return View(users);
        //}
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(user u)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            HttpResponseMessage response = GlobalVeriables.wepApiClient.PostAsJsonAsync("users", u).Result;
            user user = response.Content.ReadAsAsync<user>().Result;
            HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user));
            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(userLogin u)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            HttpResponseMessage response = GlobalVeriables.wepApiClient.PostAsJsonAsync("login", u).Result;
            if((int)response.StatusCode==404)
            {
                return View();
            }
            user user = response.Content.ReadAsAsync<user>().Result;
            HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user));
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public string Tasit(int id)
        {
            HttpResponseMessage response;
            if (HttpContext.Session.GetString("User") != null)
            {

                user user = JsonConvert.DeserializeObject<user>(HttpContext.Session.GetString("User"));//PaHttpContext.Session.GetString("User");
                string url = "interests/1?aId=" + user.accountId + "&cId=" + id;
                response = GlobalVeriables.wepApiClient.GetAsync(url).Result;
            }
            else
            {
                string url = "interests/1?aId=1&cId=" + id;
                response = GlobalVeriables.wepApiClient.GetAsync(url).Result;
            }
            interest faiz = response.Content.ReadAsAsync<interest>().Result;
            Faiz.faiz = faiz.value;
            return JsonConvert.SerializeObject(faiz);
        }
        [HttpGet]
        public string Konut(int id)
        {
            HttpResponseMessage response;
            if (HttpContext.Session.GetString("User") != null)
            {

                user user = JsonConvert.DeserializeObject<user>(HttpContext.Session.GetString("User"));//PaHttpContext.Session.GetString("User");
                string url = "interests/1?aId=" + user.accountId + "&cId=" + id;
                response = GlobalVeriables.wepApiClient.GetAsync(url).Result;
            }
            else
            {
                string url = "interests/1?aId=1&cId=" + id;
                response = GlobalVeriables.wepApiClient.GetAsync(url).Result;
            }
            interest faiz = response.Content.ReadAsAsync<interest>().Result;
            Faiz.faiz = faiz.value;
            return JsonConvert.SerializeObject(faiz);
        }
        [HttpGet]
        public string Ihtiyac(int id)
        {
            HttpResponseMessage response;
            if (HttpContext.Session.GetString("User") != null)
            {
                
                user user = JsonConvert.DeserializeObject<user>(HttpContext.Session.GetString("User"));//PaHttpContext.Session.GetString("User");
                string url = "interests/1?aId="+user.accountId+"&cId="+id;
                response = GlobalVeriables.wepApiClient.GetAsync(url).Result;
            }
            else
            {
                string url = "interests/1?aId=1&cId=" + id;
                response = GlobalVeriables.wepApiClient.GetAsync(url).Result;
            }
            interest faiz = response.Content.ReadAsAsync<interest>().Result;
            Faiz.faiz = faiz.value;
            return JsonConvert.SerializeObject(faiz);

        }
    }
}