using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using LabState.ViewModels;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNet.Http;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LabState.Controllers
{
    public class HomeController : Controller
    {
        IMemoryCache cache;

        public HomeController(IMemoryCache cache)
        {
            this.cache = cache;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Form(SaveFormViewModel model)
        {
            cache.Set("value1", model.Value1);
            HttpContext.Session.SetString("value2", model.Value2);
            Response.Cookies.Append("value3", model.Value3,
                new CookieOptions { Expires = DateTime.Now.AddDays(7) });
            return View();
            //return RedirectToAction("SecoundPage");
            //return View();
        }

        public string SecoundPage()
        {
            List<string> list = new List<string>();
            list.Add(cache.Get<string>("value1"));
            list.Add(HttpContext.Session.GetString("value2"));
            list.Add(Request.Cookies["value3"]);

            string joined = String.Join(" , ", list.ToArray());

            return joined;
            //return Request.Cookies["value3"];

            //return HttpContext.Session.GetString("value2");
            //return cache.Get<string>("value1");
            //return "Hello";

            //Linq version
            //string joinedLinq = list.Aggregate((i, j) => i + " , " + j);

        }
    }
}
