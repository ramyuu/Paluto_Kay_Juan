using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Paluto_Kay_Juan.Data;
using Paluto_Kay_Juan.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Paluto_Kay_Juan.Controllers
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

        public IActionResult Menu()
        {
            return View();
        }
        public IActionResult BookNow()
        {
            List<MenuItemsClass> ItemsMenu = new List<MenuItemsClass>();
            FoodItems foodItems = new FoodItems();
            ItemsMenu = foodItems.FetchAll();
            return View("BookNow",ItemsMenu);
        }

        public ActionResult Details(int id)
        {
            FoodItems foodItems = new FoodItems();
            MenuItemsClass ItemMenu = foodItems.FetchOne(id);
            return View("Details", ItemMenu);
        }
        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult LoginPage()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
