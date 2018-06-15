using System;
using ShopService.Dao;
using ShopService.DomainEntities;
using ShopService.Service;
using StructureMap;

namespace ShopService
{
	public class ShopService : IShopService
	{
		private readonly Container container;
		private readonly BasketService basketService;

		public ShopService()
		{
			container = new Container(_ =>
			{
				_.For<ItemsDao>().Use<ItemsDao>();
				_.For<BasketsDao>().Use<BasketsDao>();
			});

			basketService = container.GetInstance<BasketService>();
		}

		public Item GetItemData(string code)
		{
			return basketService.GetItemByCode(code);
		}

		public void SaveBasket(DateTime date, string content)
		{
			basketService.SaveBasket(date, content);
		}
	}
}
