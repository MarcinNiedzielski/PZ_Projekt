using Microsoft.AspNetCore.Authorization;
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

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Checkout()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartItems = await _context.CartItem
                .Include(ci => ci.Item)
                .Where(ci => ci.UserId == userId)
                .ToListAsync();

            if (!cartItems.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                OrderItems = cartItems.Select(ci => new OrderItem
                {
                    ItemId = ci.ItemId,
                    Item = ci.Item,
                    Quantity = ci.Quantity
                }).ToList()
            };

            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(Order order)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cartItems = await _context.CartItem
                .Where(ci => ci.UserId == userId)
                .ToListAsync();

            if (!cartItems.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

            order.UserId = userId;
            order.OrderDate = DateTime.Now;
            order.OrderItems = cartItems.Select(ci => new OrderItem
            {
                ItemId = ci.ItemId,
                Quantity = ci.Quantity
            }).ToList();

            _context.Order.Add(order);
            _context.CartItem.RemoveRange(cartItems);

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
    }
}
