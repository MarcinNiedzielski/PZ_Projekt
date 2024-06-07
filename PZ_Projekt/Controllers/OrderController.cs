using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PZ_Projekt.Data;
using PZ_Projekt.Models;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PZ_Projekt.Controllers
{// Kontroler obsługuje widoki w folderze Oder (wyświetlanie i usuwanie zamówień, zmiana statusu)
 // autoryzacja użytkownika - wymagany zalogowany uzytkownik dla całego kontrolera
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public OrderController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Wyświetlanie podsumowania zamówienia 
        public async Task<IActionResult> Checkout()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cart = await _context.Cart
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Item)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null || !cart.CartItems.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                DeliveryMethod = "Pickup", // Domyślna metoda dostawy
                Address = "", // Puste pole adresu, do uzupełnienia przez użytkownika
                Status = "Nowe", // Domyślny status
                OrderItems = cart.CartItems != null ? cart.CartItems.Select(ci => new OrderItem
                {
                    ItemId = ci.ItemId,
                    Item = ci.Item,
                    Quantity = ci.Quantity
                }).ToList() : new List<OrderItem>() // Zabezpieczenie przed null exception
            };

            return View(order);
        }


        // Składanie zamówienia 
        [HttpPost]
        public async Task<IActionResult> Checkout(Order order, string deliveryMethod, string address)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cart = await _context.Cart
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null || !cart.CartItems.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

            if (string.IsNullOrEmpty(deliveryMethod) || string.IsNullOrEmpty(address))
            {
                ModelState.AddModelError("", "Delivery method and address are required.");

                // Przekazujemy model Order ponownie do widoku
                return View(order);
            }

            // Jeśli istnieje ID zamówienia, pobierz istniejący obiekt Order z bazy danych
            if (order.Id != 0)
            {
                var existingOrder = await _context.Order
                    .Include(o => o.OrderItems)
                    .FirstOrDefaultAsync(o => o.Id == order.Id);

                if (existingOrder == null)
                {
                    return NotFound();
                }

                // Zaktualizuj istniejący obiekt Order
                existingOrder.DeliveryMethod = deliveryMethod;
                existingOrder.Address = address;

                _context.Order.Update(existingOrder);
            }
            else
            {
                // Utwórz nowy obiekt Order
                order.UserId = userId;
                order.OrderDate = DateTime.Now;
                order.DeliveryMethod = deliveryMethod;
                order.Address = address;
                order.OrderItems = cart.CartItems.Select(ci => new OrderItem
                {
                    ItemId = ci.ItemId,
                    Quantity = ci.Quantity
                }).ToList();

                _context.Order.Add(order);
            }

            // Usuń koszyk i zapisz zmiany w bazie danych
            _context.CartItem.RemoveRange(cart.CartItems);
            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();

            return RedirectToAction("OrderConfirmation", new { orderId = order.Id });
        }

        // Zmiana statusu zamówienia - tylko dla Administratora
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> ChangeOrderStatus(int id, string status)
        {
            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            
            if (!IsValidOrderStatus(status))
            {
                ModelState.AddModelError("", "Invalid order status.");
                return RedirectToAction(nameof(AllOrders));
            }

            
            order.Status = status;

            await _context.SaveChangesAsync();

            // Przekierowanie użytkownika na tę samą stronę
            return RedirectToAction(nameof(AllOrders));
        }

        private bool IsValidOrderStatus(string status)
        {
            // Lista prawidłowych statusów zamówienia
            var validStatuses = new List<string> { "Nowe", "W trakcie", "Gotowe do odbioru", "Gotowe do wysyłki", "Wysłane", "Zakończone" };
            return validStatuses.Contains(status, StringComparer.OrdinalIgnoreCase);
        }

        //Wyświetlanie potwierdzenia zamówienia
        public async Task<IActionResult> OrderConfirmation(int orderId)
        {
            var order = await _context.Order
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Item)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
        //Wyświetlanie listy zamówień zalogowanego użytkownika
        public async Task<IActionResult> MyOrders()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = await _context.Order
                .Where(o => o.UserId == userId)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Item)
                .ToListAsync();

            return View(orders);
        }

        //Wyświetlanie listy wszystkich zamówień
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> AllOrders()
        {
            var orders = await _context.Order
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Item)
                .ToListAsync();

            // Pobierz słownik par Id użytkownika - Nazwa użytkownika
            var userIdToNameMap = await GetUserIdToNameMap();

            // Przekazuj słownik do widoku wraz z zamówieniami
            ViewData["UserIdToNameMap"] = userIdToNameMap;

            return View(orders);
        }
        // Metoda pobierająca mapowanie ID użytkownika na nazwę użytkownika ( wyświetlanie nazwy użytkownika zamiast ID)
        private async Task<Dictionary<string, string>> GetUserIdToNameMap()
        {
            // Pobierz wszystkich użytkowników z bazy danych
            var users = await _userManager.Users.ToListAsync();

            // Utwórz słownik Id użytkownika - Nazwa użytkownika
            var userIdToNameMap = users.ToDictionary(u => u.Id, u => u.UserName);

            return userIdToNameMap;
        }


        // Usuwanie zamówienia
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> RemoveOrder(int id)
        {
            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return View("ConfirmRemoveOrder", order);
        }

        // Potwierdzenie usuwania zamówienia
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> ConfirmRemoveOrder(int id)
        {
            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Order.Remove(order);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(AllOrders));
        }

        // Sprawdzanie czy zamówienie istnieje
        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.Id == id);
        }
    }
}