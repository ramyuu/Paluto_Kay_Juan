using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Paluto_Kay_Juan.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Paluto_Kay_Juan.Controllers
{
    public class HomeController : Controller
    {
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();
        List<MenuItemsClass> ItemsMenu = new List<MenuItemsClass>();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            con.ConnectionString = Paluto_Kay_Juan.Properties.Resources.ConnectionString;
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
            FetchData();
            return View(ItemsMenu);
        }

        private void FetchData()
        {
            if(ItemsMenu.Count > 0)
            {
                ItemsMenu.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "select * from MenuItems";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    ItemsMenu.Add(new MenuItemsClass() {Id = dr["Id"].ToString(),
                    Category = dr["Category"].ToString(),
                    DishName = dr["DishName"].ToString(),
                    AmtPerOrder = dr["AmtPerOrder"].ToString(),
                    Price = dr["Price"].ToString(),
                    Picture = dr["Picture"].ToString()
                    });
                }
                con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IActionResult ContactUs()
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
