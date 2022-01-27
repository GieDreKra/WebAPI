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

        public List<CreateShop> GetAll()
        {
            var mapper = _mapperConfiguration.CreateMapper();
            List<Shop> shops = _dataContext.Shops.Include(i => i.Items).ToList();
            List<CreateShop> createShops = mapper.Map<List<Shop>, List<CreateShop>>(shops);
            return createShops;
        }

        public CreateShop GetById(int id)
        {
            var shop = _dataContext.Shops.Find(id);
            var mapper = _mapperConfiguration.CreateMapper();

            if (shop == null)
            {
                throw new ShopNotFoundException("Shop not found");
            }
            CreateShop createShop = mapper.Map<Shop, CreateShop>(shop);
            return createShop;
        }

        public int Create(CreateShop createShop)
        {
            var model = new Shop()
            {
                Name = createShop.Name,
            };
            _dataContext.Add(model);
            _dataContext.SaveChanges();
            return model.Id;
        }

        public void Update(int id, CreateShop createShop)
        {
            var shop = _dataContext.Shops.Find(id);
            if (shop == null)
            {
                throw new ShopNotFoundException("Shop not found");
            }
            shop.Name = createShop.Name;
            _dataContext.Update(shop);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var shop = _dataContext.Shops.Find(id);
            if (shop == null)
            {
                throw new ShopNotFoundException("Shop not found");
            }
            _dataContext.Remove(shop);
            _dataContext.SaveChanges();
        }
    }
}
