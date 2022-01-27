using System.ComponentModel.DataAnnotations;

namespace ShopAPIApp.Models
{
    public class Shop : Entity
    {
        public string Name { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public List<ShopItem> Items { get; set; }
    }
}
