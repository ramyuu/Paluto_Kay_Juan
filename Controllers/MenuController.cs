using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        /*
        public IActionResult Index()
        {
            List<AdminModel> adminModels;
            adminModels = _context.Menus.ToList();
            return View(adminModels);
        }*/

        public async Task<IActionResult> Index(string sortOrder)
        {

            var foods = from x in _context.Menus select x;

            ViewData["CategorySortParam"] = String.IsNullOrEmpty(sortOrder) ? "CategorySort" : "";

            ViewData["NameSortParam"] = sortOrder == "DishName" ? "NameSort" : "NameSort";

            ViewData["IDSortParam"] = sortOrder == "Id" ? "IdSort" : "IdSort";

            ViewData["AmtSortParam"] = sortOrder == "AmtPerOrder" ? "AmtSort" : "AmtSort";

            ViewData["PriceSortParam"] = sortOrder == "Price" ? "PriceSort" : "PriceSort";

            switch (sortOrder)
            {
                case "NameSort":
                    foods = foods.OrderBy(x => x.DishName);
                    
                    break;
                case "CategorySort":
                    foods = foods.OrderBy(x => x.DishCategory);
                    break;
                case "AmtSort":
                    foods = foods.OrderBy(x => x.AmtPerOrder);
                    break;
                case "PriceSort":
                    foods = foods.OrderBy(x => x.Price);
                    break;
                case "IdSort":
                default:
                    foods = foods.OrderBy(x => x.Id);
                    break;
            }

            return View(await foods.AsNoTracking().ToListAsync());
        }

        // Start for Create
        [HttpGet]
        public IActionResult Create()
        {
            AdminModel adminModel = new AdminModel();

            ViewBag.Category = GetCategory();

            return View(adminModel);
        }

        [HttpPost]
        public IActionResult Create(AdminModel adminModel)
        {
            string uniqueFileName = UploadFile(adminModel);
            adminModel.FoodImgUrl = uniqueFileName;

            _context.Add(adminModel);
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
        // End of Create


        //Start of Details
        public IActionResult Details(int Id)
        {
            AdminModel adminModel = _context.Menus.Where(m=>m.Id==Id).FirstOrDefault();
            return View(adminModel);
        }
        //End of Details
        
        //Start of Delete

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            AdminModel adminModel = _context.Menus.Where(m => m.Id == Id).FirstOrDefault();
            return View(adminModel);
        }

        [HttpPost]
        public IActionResult Delete(AdminModel adminModel) 
        {
            _context.Attach(adminModel);
            _context.Entry(adminModel).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        //End of Delete

        //Start of Edit
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            AdminModel adminModel = _context.Menus.Where(m => m.Id == Id).FirstOrDefault();

            ViewBag.Category = GetCategory();

            return View(adminModel);
        }

        [HttpPost]
        public IActionResult Edit(AdminModel adminModel)
        {
            
            if (adminModel.UploadedImage != null)
            {
                string uniqueFileName = UploadFile(adminModel);
                adminModel.FoodImgUrl = uniqueFileName;
            }

            _context.Attach(adminModel);
            _context.Entry(adminModel).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        //End of Edit


        //Start for CategoryList


        private List<SelectListItem> GetCategory()
        {
            List<SelectListItem> selCategory = new List<SelectListItem>();

            var selItem = new SelectListItem() { Value="", Text="Select Category"};

            selCategory.Insert(0, selItem);

            selItem = new SelectListItem()
            {
                Value = "Main",
                Text = "Main Dish"
            };
            selCategory.Add(selItem);

            selItem = new SelectListItem()
            {
                Value = "Appetizer",
                Text = "Appetizer"
            };
            selCategory.Add(selItem);

            selItem = new SelectListItem()
            {
                Value = "Dessert",
                Text = "Dessert"
            };
            selCategory.Add(selItem);

            selItem = new SelectListItem()
            {
                Value = "Drinks",
                Text = "Drinks"
            };
            selCategory.Add(selItem);

            return selCategory;
        }

        
    }
}
