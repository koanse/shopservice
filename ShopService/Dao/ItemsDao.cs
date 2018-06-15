using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using NLog;
using ShopService.DomainEntities;

namespace ShopService.Dao
{
	public class ItemsDao : AbstractDao
	{
		#region Constants

		private const string SelectItemsSql = "SELECT * FROM [Items] WHERE [Id] = @code";

		#endregion Constants

		private readonly Logger logger;

		public ItemsDao()
		{
			logger = LogManager.GetCurrentClassLogger();
		}

		public virtual Item GetItemByCode(string itemCode)
		{
			var results = new List<Item>();
			using (var connection = GetConnection())
			{
				try
				{
					connection.Open();
					var command = new OleDbCommand(SelectItemsSql, connection);
					command.Parameters.Add(new OleDbParameter("@code", itemCode));
					var reader = command.ExecuteReader();

					while (reader.Read())
					{
						var code = (string) reader[0];
						var description = (string) reader[1];
						var price = (decimal)reader[2];
						var item = new Item(code, description, price);
						results.Add(item);
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

			return results.SingleOrDefault();
		}
	}
}