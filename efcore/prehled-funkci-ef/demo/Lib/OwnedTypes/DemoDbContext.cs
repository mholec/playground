using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Lib.OwnedTypes
{
	public class Book
	{
		public Book()
		{
			Price = new Price();
			PriceAfterSale = new Price();
		}

		public int BookId { get; set; }
		public string Title { get; set; }

		//public decimal Price_PriceWithoutVat			{ get; set; }
		//public decimal Price_VatRate					{ get; set; }
		//public decimal PriceAfterSale_PriceWithoutVat { get; set; }
		//public decimal PriceAfterSale_VatRate			{ get; set; }

		public Price Price { get; set; }
		public Price PriceAfterSale { get; set; }
	}

	public class Price
	{
		public decimal PriceWithoutVat { get; set; }
		public decimal VatRate { get; set; }

		public decimal PriceWithVat =>  PriceWithoutVat * (1 + VatRate);
		public decimal Vat => PriceWithVat - PriceWithoutVat;
	}

	public class DemoDbContext : DbContext
	{
		public DbSet<Book> Books { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseInMemoryDatabase(this.GetType().Name);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Book>().OwnsOne(x => x.Price);
			modelBuilder.Entity<Book>().OwnsOne(x => x.PriceAfterSale);

			base.OnModelCreating(modelBuilder);
		}
	}

	public class Example
	{
		public void Run()
		{
			using (var db = new DemoDbContext())
			{
				var book = new Book
				{
					Title = "Moje kniha",
					Price =
					{
						PriceWithoutVat = 100,
						VatRate = 0.10M
					}
				};

				book.PriceAfterSale = new Price
				{
					PriceWithoutVat = book.Price.PriceWithoutVat - 20,
					VatRate = book.Price.VatRate
				};

				db.Books.Add(book);
				db.SaveChanges();

				var myBook = db.Books.FirstOrDefault();
			}
		}
	}
}
