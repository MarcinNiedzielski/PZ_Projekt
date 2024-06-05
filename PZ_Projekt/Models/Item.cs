using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace PZ_Projekt.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string? Category { get; set; }

        public string? ImageUrl { get; set; } // Ścieżka do zapisanego obrazu na serwerze

        [NotMapped]
        public IFormFile ImageFile { get; set; } // Do przesyłania obrazu przez formularz
    }
}
