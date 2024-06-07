using Microsoft.AspNetCore.Mvc;
using PZ_Projekt.Models;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PZ_Projekt.Data;
using System.Linq;

namespace PZ_Projekt.Controllers
{// Kontroler obs³uguje widoki w folderze Home (Kontakt, G³ówna, Lista produktów)
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Strona g³ówna
        public IActionResult Index()
        {
            // Pobieranie z bazy 6 najnowszych produktów (najwiêksze ID)
            var latestItems = _context.Item
                .OrderByDescending(i => i.Id)
                .Take(6)
                .ToList();

            return View(latestItems);
        }
        // Strona z produktami
        public IActionResult Products(string sortOrder, string categoryFilter, string searchString)
        {
            // Ustawienie parametrów sortowania i filtrów widoku
            ViewData["NameSortParam"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["PriceSortParam"] = sortOrder == "price_asc" ? "price_desc" : "price_asc";
            ViewBag.SortOrder = sortOrder;
            ViewBag.CategoryFilter = categoryFilter;
            ViewBag.SearchString = searchString;

            // Zapytanie do bazy danych
            IQueryable<Item> itemsQuery = _context.Item.AsQueryable();

            // Zastosuj filtr kategorii, jeœli jest podany
            if (!string.IsNullOrEmpty(categoryFilter))
            {
                itemsQuery = itemsQuery.Where(item => item.Category == categoryFilter);
            }
            // Zastosuj wyszukiwanie, jeœli jest podane
            if (!string.IsNullOrEmpty(searchString))
            {
                itemsQuery = itemsQuery.Where(item => item.Name.Contains(searchString));
            }
            // Zastosuj sortowanie
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
        // Strona z danymi kontaktowymi
        public IActionResult Contact()
        {
            return View();
        }
        // Strona b³êdu 
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
