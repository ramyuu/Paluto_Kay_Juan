using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Paluto_Kay_Juan.Data;
using Paluto_Kay_Juan.Models;

namespace Paluto_Kay_Juan.Controllers
{
    public class UserAccController : Controller
    {
        private readonly AppDbContext _context;
        public UserAccController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<UsersModel> userModels;
            userModels = _context.UserAcc.ToList();
            return View(userModels);
        }

        [HttpGet]
        public IActionResult Registration()
        {
            UsersModel userModel = new UsersModel();
            return View(userModel);
        }

        [HttpPost]
        public IActionResult Registration(UsersModel userModel)
        {
            _context.Add(userModel);
            _context.Entry(userModel).State = EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        void connectionString()
        {
            con.ConnectionString = "Data Source=.\\sqlexpress;Initial Catalog=PalutoKayJuanDB1;Integrated Security=True";
        }

        [HttpPost]
        public IActionResult VerifyUser(LoginModel loginModel)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from RegLog where Username='" + loginModel.Username + "' and Password ='" + loginModel.Password + "' and isAdmin='" + "No" + "' ";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewData["LoginFlag"] = "Invalid username or password!";
                con.Close();
                return View("Login");
            }
        }


        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult VerifyAdmin(LoginModel loginModel)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from RegLog where Username='" + loginModel.Username + "' and Password ='" + loginModel.Password + "' and isAdmin='" + "Yes" + "' ";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return RedirectToAction("Index", "Menu");
            }
            else
            {
                ViewData["LoginFlag"] = "Invalid username or password!";
                con.Close();
                return View("AdminLogin");
            }
        }

        public IActionResult Menu()
        {
            List<AdminModel> adminModels;
            adminModels = _context.Menus.ToList();
            return View(adminModels);
        }
    }
}
