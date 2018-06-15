using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using ShopService.Dao;
using ShopService.DomainEntities;
using ShopService.Service;

namespace ShopServiceTest
{
	[TestClass]
	public class BasketServiceTests
	{
		[TestMethod]
		public void BasketServiceGetItemByCodeTest()
		{
			var itemsDao = Substitute.For<ItemsDao>();

			itemsDao.GetItemByCode("123").Returns(new Item("123", "TestItem1", 123));
			itemsDao.GetItemByCode("234").Returns(new Item("234", "TestItem2", 234));

			var basketsDao = Substitute.For<BasketsDao>();
			var basketService = new BasketService(itemsDao, basketsDao);

			var item = basketService.GetItemByCode("123");
			Assert.AreEqual("123", item.Code);

			item = basketService.GetItemByCode("234");
			Assert.AreEqual("234", item.Code);
		}

		[TestMethod]
		public void BasketServiceCreateBasketTest()
		{
			var itemsDao = Substitute.For<ItemsDao>();
			itemsDao.GetItemByCode("123").Returns(new Item("123", "TestItem1", 123));

			var basketsDao = Substitute.For<BasketsDao>();
			var basketService = new BasketService(itemsDao, basketsDao);
			basketService.SaveBasket(DateTime.Now, "test content");

			basketsDao.ReceivedWithAnyArgs().CreateBasket(null);
		}
	}
}
