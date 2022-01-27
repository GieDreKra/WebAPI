using FluentValidation;
using ShopAPIApp.Dtos;

namespace ShopAPIApp.Validators
{
    public class ShopItemValidator : AbstractValidator<CreateShopItem>
    {
        public ShopItemValidator()
        {
            RuleFor(shopItem => shopItem.Price).NotNull().GreaterThan(0);
        }
    }
}
