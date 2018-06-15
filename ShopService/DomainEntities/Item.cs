using System;
using System.Runtime.Serialization;

namespace ShopService.DomainEntities
{
	[DataContract]
	[Serializable]
	public class Item
	{
		[DataMember]
		public string Code { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public decimal Price { get; set; }

		public Item(string code, string description, decimal price)
		{
			Code = code;
			Description = description;
			Price = price;
		}
	}
}