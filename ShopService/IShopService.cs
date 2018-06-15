using System;
using System.ServiceModel;
using ShopService.DomainEntities;

namespace ShopService
{
	[ServiceContract]
	public interface IShopService
	{

		[OperationContract]
		Item GetItemData(string code);

		[OperationContract]
		void SaveBasket(DateTime date, string content);
	}
}
