using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Paluto_Kay_Juan.Data;
using Paluto_Kay_Juan.Models;
using System.Diagnostics;

namespace Paluto_Kay_Juan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Menu()
        {
            List<AdminModel> adminModels;
            adminModels = _context.Menus.ToList();
            return View(adminModels);
        }
        public IActionResult BookNow()
        {
            List<AdminModel> adminModels;
            adminModels = _context.Menus.ToList();
            return View(adminModels);
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