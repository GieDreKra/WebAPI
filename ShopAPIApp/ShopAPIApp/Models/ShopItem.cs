using System.ComponentModel.DataAnnotations;

namespace ShopAPIApp.Models
{
    public class ShopItem : Entity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int ShopId { get; set; }
    }
}
