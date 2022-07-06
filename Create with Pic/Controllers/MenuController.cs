using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Paluto_Kay_Juan.Data;
using Paluto_Kay_Juan.Models;

namespace Paluto_Kay_Juan.Controllers
{
    public class MenuController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        private readonly AppDbContext _context;

        public MenuController(AppDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            webHostEnvironment = webHost;
        }

        [HttpGet]
        public IActionResult Create()
        {
            AdminModel adminModel = new AdminModel();
            return View(adminModel);
        }

        [HttpPost]
        public IActionResult Create(AdminModel adminModel)
        {
            string uniqueFileName = UploadFile(adminModel);
            adminModel.FoodImgUrl = uniqueFileName;

            _context.Attach(adminModel);
            _context.Entry(adminModel).State = EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public string UploadFile(AdminModel adminModel)
        {
            string uniqueFileName = null;
            if (adminModel.UploadedImage != null)
            {
                string path = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "-" + adminModel.UploadedImage.FileName;
                string filePath = Path.Combine(path, uniqueFileName);

                using(var fs = new FileStream(filePath, FileMode.Create))
                {
                    adminModel.UploadedImage.CopyTo(fs);
                }
            }
            return uniqueFileName;
        }

        public IActionResult Index()
        {
            List<AdminModel> adminModels;
            adminModels = _context.Menus.ToList();
            return View(adminModels);
        }
    }
}
