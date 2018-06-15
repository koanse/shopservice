using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopClient.Service;
using ShopClient.ShopServiceReference;

namespace ShopClientTest
{
	[TestClass]
	public class ListItemExtensionsTest
	{
		[TestMethod]
		public void ListItemExtensionsToHtmlTest()
		{
			var list = new List<Item>
			{
				new Item {Code = "test1", Description = "Desc1", Price = 12},
				new Item {Code = "test2", Description = "Desc2", Price = 23}
			};

			var html = list.ToHtml();
			
			Assert.AreEqual(html.IndexOf("Red"), html.LastIndexOf("Red"));
			Assert.AreEqual(html.IndexOf("Black"), html.LastIndexOf("Black"));
		}

		[TestMethod]
		public void ListItemExctensionsToHtmlTest()
		{
			var list = new List<Item>
			{
				new Item {Code = "test1", Description = "Desc1", Price = 12},
				new Item {Code = "test2", Description = "Desc2", Price = 23}
			};

			var html = list.SerializeToXml();

			Assert.IsTrue(html.IndexOf("test1") > 0);
			Assert.IsTrue(html.IndexOf("test2") > 0);
			Assert.IsTrue(html.IndexOf("Desc1") > 0);
			Assert.IsTrue(html.IndexOf("Desc2") > 0);
		}
	}
}
