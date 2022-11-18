using Deneme.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Deneme.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }
        public class Numbers
        {
            public int sayia { get; set; }
            public int sayib { get; set; }
        }
        [HttpPost]
        public IActionResult Add(int a, int b)
        {
            Numbers numbers = new Numbers();
            numbers.sayia = a;
            numbers.sayib = b;

            var result = numbers.sayia + numbers.sayib;

            return Json(result);
            //return PartialView("Index",result);  //Sonuç olarak yine View dönderiyor
        }

        [HttpPost]
        public JsonResult GetOgrenciListesiGetir()
        {
            List<Ogreciler> ogrencilerlist = new List<Ogreciler>();

            Ogreciler ogrenci1 = new Ogreciler();

            ogrenci1.Id = 1;
            ogrenci1.Name = "Esra";

            ogrencilerlist.Add(ogrenci1);

            Ogreciler ogrenci2 = new Ogreciler();

            ogrenci2.Id = 2;
            ogrenci2.Name = "Kübra";

            ogrencilerlist.Add(ogrenci2);

            return Json(ogrencilerlist);
        }
        public class Ogreciler
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
