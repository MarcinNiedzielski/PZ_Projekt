using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PZ_Projekt.Models
{
    // Model zamówienia w sklepie internetowym
    public class Order
    {
        // Identyfikator zamówienia
        public int Id { get; set; }

        // Identyfikator użytkownika, który złożył zamówienie
        [Required]
        public string UserId { get; set; }

        // Data złożenia zamówienia
        [Required]
        public DateTime OrderDate { get; set; }

        // Metoda dostawy zamówienia, wymagana 
        [Required(ErrorMessage = "Metoda dostawy jest wymagana.")]
        public string DeliveryMethod { get; set; }

        // Adres dostawy zamówienia, wymagany, maksymalna długość 100 znaków
        [Required(ErrorMessage = "Adres dostawy jest wymagany.")]
        [StringLength(100)]
        public string Address { get; set; }

        // Status zamówienia (np. "Nowe", "W trakcie", "Gotowe do odbioru", itp.)
        public string? Status { get; set; }

        // Lista pozycji zamówienia
        public List<OrderItem> OrderItems { get; set; }
    }
}
