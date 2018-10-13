using System;
using Lib.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
	public abstract class UnitTestBase
	{
		protected AppDbContext GetInMemoryDbContext(string name)
		{
			DbContextOptionsBuilder<AppDbContext> builder = new DbContextOptionsBuilder<AppDbContext>()
				.UseInMemoryDatabase(name);

			AppDbContext dbContext = new AppDbContext(builder.Options);
			dbContext.Database.EnsureDeleted();
			dbContext.Database.EnsureCreated();

			return dbContext;
		}

		protected AppDbContext GetInMemoryDbContext()
		{
			return GetInMemoryDbContext(Guid.NewGuid().ToString("N"));
		}

		protected AppDbContext GetSqliteDbContext(string name)
		{
			DbContextOptionsBuilder<AppDbContext> builder = new DbContextOptionsBuilder<AppDbContext>()
				.UseSqlite($"DataSource={name}");

			AppDbContext dbContext = new AppDbContext(builder.Options);
			//dbContext.Database.EnsureDeleted();
			dbContext.Database.EnsureCreated();

			return dbContext;
		}

		protected AppDbContext GetSqliteDbContext()
		{
			return GetSqliteDbContext(Guid.NewGuid().ToString("N"));
		}
	}
}
