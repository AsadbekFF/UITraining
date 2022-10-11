using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using UITraining.Models;
using System.Web.WebPages.Html;

namespace UITraining.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string CustomerName, string CustomerId)
        {
            ViewBag.Message = "CustomerName: " + CustomerName + " CustomerId: " + CustomerId;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //[HttpPost]
        //public JsonResult AutoComplete(string term)
        //{
        //    var result = new List<KeyValuePair<string, string>>();
        //    IList<SelectListItem> List = new List<SelectListItem>();
        //    List.Add(new SelectListItem { Text = "test1", Value = "0" });
        //    List.Add(new SelectListItem { Text = "test2", Value = "1" });
        //    List.Add(new SelectListItem { Text = "test3", Value = "2" });
        //    List.Add(new SelectListItem { Text = "test4", Value = "3" });
        //    foreach (var item in List)
        //    {
        //        result.Add(new KeyValuePair<string, string>(item.Value.ToString(), item.Text));
        //    }
        //    var result3 = result.Where(s => s.Value.ToLower().Contains(term.ToLower())).Select(w => w).ToList();
        //    return Json(result3);
        //}

        [HttpPost]
        public JsonResult GetDetail(int id)
        {
            DemoModel model = new DemoModel();
            // select data by id here display static data;  
            if (id == 0)
            {
                model.id = 1;
                model.name = "Yogesh Tyagi";
                model.mobile = "9460516787";
            }
            else
            {
                model.id = 2;
                model.name = "Pratham Tyagi";
                model.mobile = "9460516787";
            }
            return Json(model);
        }

        public ActionResult Search(string id)//I think that the id that you are passing here needs to be the search term. You may not have to change anything here, but you do in the $.ajax() call
        {
            
            return Json(new { name = "Asadbek", id = 1234 });
        }

        [HttpPost]
        public JsonResult AutoComplete(string prefix)
        {
            List<City> ObjList = new List<City>()
            {

                new City {Id=1,Name="Latur" },
                new City {Id=2,Name="Mumbai" },
                new City {Id=3,Name="Pune" },
                new City {Id=4,Name="Delhi" },
                new City {Id=5,Name="Dehradun" },
                new City {Id=6,Name="Noida" },
                new City {Id=7,Name="New Delhi" }

            };

            var Name = (from N in ObjList
                        where N.Name.StartsWith(prefix)
                        select new { label = N.Name, val = N.Id }).ToList();
            return Json(Name);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormFile image)
        {
            using (var ms = new MemoryStream())
            {
                image.CopyTo(ms);
                var fileBytes = ms.ToArray();
                string s = Convert.ToBase64String(fileBytes);
                // act on the Base64 data
            }
            return View(image);
        }
    }
}
