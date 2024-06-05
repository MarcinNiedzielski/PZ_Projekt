using Microsoft.AspNetCore.Mvc;
using PZ_Projekt.Models;

namespace PZ_Projekt.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PlaceOrder(CheckoutViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Logika przetwarzania zamówienia
                if (model.DeliveryOption == "Kurier")
                {
                    model.TotalPrice += 9.99m; // Dodaj koszt dostawy
                }

                // Zapisz zamówienie do bazy danych (a przynajmniej powinno, po usunięciu tej linijki program odpala się, ale formularz nie działa)

               // return RedirectToAction("OrderSummary", new { id = newOrder.Id });
            }

            return View("Index", model);
        }
    }
}

