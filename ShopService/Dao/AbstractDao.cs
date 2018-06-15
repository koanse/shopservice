using System.Configuration;
using System.Data.OleDb;
using ShopService.Service;

namespace ShopService.Dao
{
	public class AbstractDao
	{
		public OleDbConnection GetConnection()
		{
			var connectionString = ConfigurationManager.AppSettings[Constants.ConnectionStringSettingName];
			return new OleDbConnection(connectionString);
		}

	}
}