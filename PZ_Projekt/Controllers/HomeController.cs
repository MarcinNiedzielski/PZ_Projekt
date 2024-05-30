using Microsoft.AspNetCore.Mvc;
using PZ_Projekt.Models;
using System.Diagnostics;
using System.Collections.Generic;

namespace PZ_Projekt.Controllers
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
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Produkt 1", Description = "Opis produktu 1", Price = 10.99m, ImageUrl = "~/images/product1.jpg" },
                new Product { Id = 2, Name = "Produkt 2", Description = "Opis produktu 2", Price = 20.99m, ImageUrl = "~/images/product2.jpg" },
                new Product { Id = 3, Name = "Produkt 3", Description = "Opis produktu 3", Price = 30.99m, ImageUrl = "~/images/product3.jpg" }
            };

            return View(products);
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
    }
}
