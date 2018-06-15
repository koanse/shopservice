using System;
using ShopService.Dao;
using ShopService.DomainEntities;

namespace ShopService.Service
{
	public class BasketService
	{
		private readonly ItemsDao itemsDao;
		private readonly BasketsDao basketsDao;

		public BasketService(ItemsDao itemsDao, BasketsDao basketsDao)
		{
			this.itemsDao = itemsDao;
			this.basketsDao = basketsDao;
		}

		public Item GetItemByCode(string code)
		{
			return itemsDao.GetItemByCode(code);
		}

		public void SaveBasket(DateTime date, string content)
		{
			var basket = new Basket(date, content);
			basketsDao.CreateBasket(basket);
		}

	}
}