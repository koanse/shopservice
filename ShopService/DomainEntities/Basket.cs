using System;

namespace ShopService.DomainEntities
{
	public class Basket
	{
		public int Id { get; set; }

		public DateTime? Date { get; set; }

		public string Content { get; set; }

		public Basket(DateTime date, string content)
		{
			Date = date;
			Content = content;
		}
	}
}