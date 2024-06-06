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
{
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
                OrderItems = cart.CartItems.Select(ci => new OrderItem
                {
                    ItemId = ci.ItemId,
                    Item = ci.Item,
                    Quantity = ci.Quantity
                }).ToList()
            };

            return View(order);
        }

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
                return View(order);
            }

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
            _context.CartItem.RemoveRange(cart.CartItems);
            _context.Cart.Remove(cart);

            await _context.SaveChangesAsync();

            return RedirectToAction("OrderConfirmation", new { orderId = order.Id });
        }

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

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> AllOrders()
        {
            var orders = await _context.Order
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Item)
                .ToListAsync();

            return View(orders);
        }


        // Metoda do usuwania zamówienia
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


        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.Id == id);
        }
    }
}
