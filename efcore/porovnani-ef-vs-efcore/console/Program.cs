using System;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using console.lib.ef6;
using console.lib.efcore;
using OrderRepository = console.lib.ef6.OrderRepository;

namespace demo_porovnani_ef_core_ef_6
{
    class Program
    {
        static void Main(string[] args)
        {
	        SqlConnectionStringBuilder sqlString = new SqlConnectionStringBuilder()
	        {
		        DataSource = "HOLEC\\SQLEXPRESS",
		        InitialCatalog = "efdemo",
		        UserID = "sa",
		        Password = "asdfghjkl",
	        };

	        using (var db = new Ef6DbContext(sqlString.ConnectionString))
	        {
				console.lib.ef6.OrderRepository repository = new console.lib.ef6.OrderRepository(db);
		        var orders = repository.GetOrderItems();
	        }

	        using (var db = new EfCoreDbContext(sqlString.ConnectionString))
	        {
		        console.lib.efcore.OrderRepository repository = new console.lib.efcore.OrderRepository(db);
				var orders = repository.GetOrderItems();
			}
		}
    }
}
