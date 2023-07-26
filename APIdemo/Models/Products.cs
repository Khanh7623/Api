using System.ComponentModel.DataAnnotations;

namespace APIdemo.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        public string? nameProduct { get; set; }
        public int Price { get; set; }
    }
}
