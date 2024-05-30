using Microsoft.AspNetCore.Mvc;
using PZ_Projekt.Models;
using System.Collections.Generic;

namespace OnlineStore.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            return View(cart);
        }

        public IActionResult AddToCart(int id)
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Produkt 1", Description = "Opis produktu 1", Price = 10.99m, ImageUrl = "~/images/product1.jpg" },
                new Product { Id = 2, Name = "Produkt 2", Description = "Opis produktu 2", Price = 20.99m, ImageUrl = "~/images/product2.jpg" },
                new Product { Id = 3, Name = "Produkt 3", Description = "Opis produktu 3", Price = 30.99m, ImageUrl = "~/images/product3.jpg" }
            };

            var product = products.Find(p => p.Id == id);
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            var cartItem = cart.Find(c => c.Product.Id == id);
            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                cart.Add(new CartItem { Product = product, Quantity = 1 });
            }

            HttpContext.Session.SetObjectAsJson("Cart", cart);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult RemoveFromCart(int id)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            var cartItem = cart.Find(c => c.Product.Id == id);
            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                }
                else
                {
                    cart.Remove(cartItem);
                }
            }

            HttpContext.Session.SetObjectAsJson("Cart", cart);

            return RedirectToAction("Index", "Cart");
        }
    }
}
