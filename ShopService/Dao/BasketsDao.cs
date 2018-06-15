using System;
using System.Data.OleDb;
using NLog;
using ShopService.DomainEntities;

namespace ShopService.Dao
{
	public class BasketsDao : AbstractDao
	{
		#region Constants

		private const string InsertBasketSql = "INSERT INTO [Baskets]([OrderDate], [Content]) VALUES(@date, @content)";

		#endregion Constants

		private readonly Logger logger;

		public BasketsDao()
		{
			logger = LogManager.GetCurrentClassLogger();
		}

		public virtual void CreateBasket(Basket basket)
		{
			using (var connection = GetConnection())
			{
				try
				{
					connection.Open();
					var command = new OleDbCommand(InsertBasketSql, connection);
					var dateParameter = new OleDbParameter("@date", OleDbType.Date)
					{
						Value = basket.Date
					};
					command.Parameters.Add(dateParameter);
					command.Parameters.Add(new OleDbParameter("@content", basket.Content));
					var count = command.ExecuteNonQuery();

					if (count != 1)
					{
						throw new Exception("The basket was not created!");
					}
				}
				catch (Exception e)
				{
					logger.Error($"Error occured: {e.Message}");
					throw;
				}
				finally
				{
					connection.Close();
				}
			}
		}
	}
}