using AutoMapper;
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

        public List<CreateShopItem> GetAll()
        {
            var mapper = _mapperConfiguraion.CreateMapper();
            List<ShopItem> items = _dataContext.Items.ToList();
            List<CreateShopItem> createShopItems = mapper.Map<List<ShopItem>, List<CreateShopItem>>(items);
            return createShopItems;
        }

        public CreateShopItem GetById(int id)
        {
            var mapper = _mapperConfiguraion.CreateMapper();
            var item = _dataContext.Items.Find(id);
            if (item == null)
            {
                throw new ArgumentException("Shop item not found");
            }
            CreateShopItem createShopItem = mapper.Map<ShopItem, CreateShopItem>(item);
            return createShopItem;
        }

        public int Create(CreateShopItem createShopItem)
        {
            var ShopName = _shopService.GetById(createShopItem.ShopId).Name;
            ShopItem shopItem = new ShopItem()
            {
                Name = createShopItem.Name,
                Price = createShopItem.Price,
                ShopId = createShopItem.ShopId
            };
            _dataContext.Add(shopItem);
            _dataContext.SaveChanges();
            return shopItem.Id;
        }

        public void Update(int id, CreateShopItem createShopItem)
        {
            var updateModel = _dataContext.Items.Find(id);
            if (updateModel == null)
            {
                throw new ArgumentException("Shop item not found");
            }
            updateModel.Name = createShopItem.Name;
            updateModel.Price = createShopItem.Price;
            updateModel.ShopId = createShopItem.ShopId;
            _dataContext.Update(updateModel);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _dataContext.Items.Find(id);
            if (item == null)
            {
                throw new ArgumentException("Shop item not found");
            }
            _dataContext.Remove(item);
            _dataContext.SaveChanges();
        }
    }
}
