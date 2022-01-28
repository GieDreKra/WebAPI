using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopAPIApp.Data;
using ShopAPIApp.Dtos;
using ShopAPIApp.Models;

namespace ShopAPIApp.Services
{
    public class ShopItemService
    {
        private readonly DataContext _dataContext;

        private readonly ShopService _shopService;

        private MapperConfiguration _mapperConfiguraion = new MapperConfiguration(cfg => cfg.CreateMap<ShopItem, CreateShopItem>());

        public ShopItemService(DataContext dataContext, ShopService shopService)
        {
            _dataContext = dataContext;
            _shopService = shopService;
        }

        public async Task<List<CreateShopItem>> GetAllAsync()
        {
            var mapper = _mapperConfiguraion.CreateMapper();
            List<ShopItem> items = await _dataContext.Items.ToListAsync();
            List<CreateShopItem> createShopItems = mapper.Map<List<ShopItem>, List<CreateShopItem>>(items);
            return createShopItems;
        }

        public async Task<CreateShopItem> GetByIdAsync(int id)
        {
            var mapper = _mapperConfiguraion.CreateMapper();
            var item = await _dataContext.Items.FindAsync(id);
            if (item == null)
            {
                throw new ArgumentException("Shop item not found");
            }
            CreateShopItem createShopItem = mapper.Map<ShopItem, CreateShopItem>(item);
            return createShopItem;
        }

        public async Task<int> CreateAsync(CreateShopItem createShopItem)
        {
            var shop = await _shopService.GetByIdAsync(createShopItem.ShopId);
            ShopItem shopItem = new ShopItem()
            {
                Name = createShopItem.Name,
                Price = createShopItem.Price,
                ShopId = createShopItem.ShopId
            };
            _dataContext.Add(shopItem);
            await _dataContext.SaveChangesAsync();
            return shopItem.Id;
        }

        public async Task UpdateAsync(int id, CreateShopItem createShopItem)
        {
            var updateModel = await _dataContext.Items.FindAsync(id);
            if (updateModel == null)
            {
                throw new ArgumentException("Shop item not found");
            }
            updateModel.Name = createShopItem.Name;
            updateModel.Price = createShopItem.Price;
            updateModel.ShopId = createShopItem.ShopId;
            _dataContext.Update(updateModel);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _dataContext.Items.FindAsync(id);
            if (item == null)
            {
                throw new ArgumentException("Shop item not found");
            }
            _dataContext.Remove(item);
            await _dataContext.SaveChangesAsync();
        }
    }
}
