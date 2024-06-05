using Microsoft.AspNetCore.Mvc;
using PZ_Projekt.Models;
using System.Collections.Generic;

namespace PZ_Projekt.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            // Pobierz listę zamówień z bazy danych
            List<Order> orders = new List<Order>();
            return View(orders);
        }
    }
}
