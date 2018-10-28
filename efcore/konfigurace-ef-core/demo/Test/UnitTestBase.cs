using System;
using Lib.Model;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
	public abstract class UnitTestBase
	{
		protected DbContextOptions<AppDbContext> GetInMemoryOptions(string name = "Default")
		{
			return new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(name).Options;
		}

		protected DbContextOptions<AppDbContext> GetSqlliteOptions(string name = "Default")
		{
			return new DbContextOptionsBuilder<AppDbContext>().UseSqlite(name).Options;
		}

		protected AppDbContext GetInMemoryDbContext(string name)
		{
			DbContextOptionsBuilder<AppDbContext> builder = new DbContextOptionsBuilder<AppDbContext>()
				.UseInMemoryDatabase(name);

			AppDbContext dbContext = new AppDbContext(builder.Options);

			return dbContext;
		}


		protected AppDbContext GetSqliteDbContext(string name)
		{
			DbContextOptionsBuilder<AppDbContext> builder = new DbContextOptionsBuilder<AppDbContext>()
				.UseSqlite($"DataSource={name}");

			AppDbContext dbContext = new AppDbContext(builder.Options);

			return dbContext;
		}

		protected AppDbContext GetSqliteDbContext()
		{
			return GetSqliteDbContext(Guid.NewGuid().ToString("N"));
		}
	}
}
