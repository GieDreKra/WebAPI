using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopAPIApp.Data;
using ShopAPIApp.Dtos;
using ShopAPIApp.Exceptions;
using ShopAPIApp.Models;

namespace ShopAPIApp.Services
{
    public class ShopService
    {
        private readonly DataContext _dataContext;

        private MapperConfiguration _mapperConfiguration = new MapperConfiguration(cfg => cfg.CreateMap<Shop, CreateShop>());
        public ShopService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<CreateShop>> GetAllAsync()
        {
            var mapper = _mapperConfiguration.CreateMapper();
            List<Shop> shops = await _dataContext.Shops.Include(i => i.Items).ToListAsync();
            List<CreateShop> createShops = mapper.Map<List<Shop>, List<CreateShop>>(shops);
            return createShops;
        }

        public async Task<CreateShop> GetByIdAsync(int id)
        {
            var shop = await _dataContext.Shops.FindAsync(id);
            var mapper =_mapperConfiguration.CreateMapper();

            if (shop == null)
            {
                throw new ShopNotFoundException("Shop not found");
            }
            CreateShop createShop = mapper.Map<Shop, CreateShop>(shop);
            return createShop;
        }

        public async Task<int> CreateAsync(CreateShop createShop)
        {
            var model = new Shop()
            {
                Name = createShop.Name,
            };
            _dataContext.Add(model);
            await _dataContext.SaveChangesAsync();
            return model.Id;
        }

        public async Task UpdateAsync(int id, CreateShop createShop)
        {
            var shop = await _dataContext.Shops.FindAsync(id);
            if (shop == null)
            {
                throw new ShopNotFoundException("Shop not found");
            }
            shop.Name = createShop.Name;
            _dataContext.Update(shop);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var shop = await _dataContext.Shops.FindAsync(id);
            if (shop == null)
            {
                throw new ShopNotFoundException("Shop not found");
            }
            _dataContext.Remove(shop);
            await _dataContext.SaveChangesAsync();
        }
    }
}
