using Microsoft.AspNetCore.Mvc;
using PZ_Projekt.Models;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PZ_Projekt.Data;

namespace PZ_Projekt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            var latestItems = _context.Item
                .OrderByDescending(i => i.Id)
                .Take(6)
                .ToList();

            return View(latestItems);
        }

        public IActionResult Products(string sortOrder, string categoryFilter)
        {
            ViewData["NameSortParam"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["PriceSortParam"] = sortOrder == "price_asc" ? "price_desc" : "price_asc";
            ViewBag.SortOrder = sortOrder;
            ViewBag.CategoryFilter = categoryFilter;

            IQueryable<Item> itemsQuery = _context.Item.AsQueryable();

            if (!string.IsNullOrEmpty(categoryFilter))
            {
                itemsQuery = itemsQuery.Where(item => item.Category == categoryFilter);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    itemsQuery = itemsQuery.OrderByDescending(i => i.Name);
                    break;
                case "price_asc":
                    itemsQuery = itemsQuery.OrderBy(i => i.Price);
                    break;
                case "price_desc":
                    itemsQuery = itemsQuery.OrderByDescending(i => i.Price);
                    break;
                default:
                    itemsQuery = itemsQuery.OrderBy(i => i.Name);
                    break;
            }

            var items = itemsQuery.ToList();
            return View(items);
        }

        public IActionResult Contact()
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
