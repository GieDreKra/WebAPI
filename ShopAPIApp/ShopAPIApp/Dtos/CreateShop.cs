using System.ComponentModel.DataAnnotations;

namespace ShopAPIApp.Dtos
{
    public class CreateShop
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; }
    }
}
