using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Lib.OneToMany
{
	public class Author
	{
		public int AuthorId { get; set; }
		public string Name { get; set; }

		public List<Book> Books { get; set; }
	}

	public class Book
	{
		public int BookId { get; set; }
		public string Title { get; set; }
		public Author Author { get; set; }
	}

	public class DemoDbContext : DbContext
	{
		public DbSet<Author> Authors { get; set; }
		public DbSet<Book> Books { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseInMemoryDatabase(this.GetType().Name);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Author>().HasMany(x => x.Books);

			base.OnModelCreating(modelBuilder);
		}
	}

	public class Example
	{
		public void Run()
		{
			using (var db = new DemoDbContext())
			{
				var author = db.Authors.Include(x => x.Books).FirstOrDefault();
			}
		}
	}
}
