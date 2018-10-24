using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EFCoreDemo.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EFCoreDemo.Tests.M5
{
    /// <summary>
    /// Všechny příklady pro M5
    /// </summary>
    [TestClass]
    public class Ukazky
    {
        private DemoDbContext context;

        [TestInitialize]
        public void TestInitialize()
        {
	        DbContextOptionsBuilder<DemoDbContext> builder = new DbContextOptionsBuilder<DemoDbContext>()
		        .UseInMemoryDatabase("demo");

			context = new DemoDbContext(builder.Options);
        }

        [TestMethod]
        [Description("Použití DB contextu")]
        public void PouzitiDbContextu()
        {
            using (var db = new DemoDbContext())
            {
                var all = db.Brands.ToList();
            }

            // per web request s DI
        }

        [TestMethod]
        [Description("Načtení všech dat a Queryable vs List")]
        public void NacteniVsechDatQueryableVsList()
        {
            // PRIKLAD 1 - dbset a list
            var dbset = context.Brands;
            var queryable = context.Brands as IQueryable<Brand>;
            var enumerable = context.Brands as IEnumerable<Brand>;
            var list = context.Brands.ToList();

            // PRIKLAD 2 - enumerable
            //foreach (var brand in context.Brands)
            //{
            //    var x = brand.Title;
            //}

            // PRIKLAD 3 - iterace
            //var queryable = context.Brands.ToList();
            //for (int i = 1; i < 3; i++)
            //{
            //    var x = queryable[i].Title;
            //}
        }

        [TestMethod]
        [Description("Načtení jednoho (prvního) záznamu")]
        public void NacteniVsechDat()
        {
            // PRIKLAD 1
            var pr1 = context.Brands.FirstOrDefault();

            // PRIKLAD 2 - First(OrDefault)
            //var pr2 = context.Brands.FirstOrDefault(x => x.BrandId == 2);
            //var pr3 = context.Brands.First(x => x.BrandId == 2);

            // PRIKLAD 3 - Single(OrDefault)
            //var pr4 = context.Brands.SingleOrDefault(x => x.BrandId == 2);
            //var pr5 = context.Brands.Single(x => x.BrandId == 2);

            // PRIKLAD 4 - Problemy se Single
            //var pr6 = context.Brands.SingleOrDefault(x => x.Title == "Nokia");
            //var pr7 = context.Brands.Single(x => x.Title == "Nokia");
        }

        [TestMethod]
        [Description("Filtrování dat")]
        public void FiltrovaniDat()
        {
            // PRIKLAD 1 - WHERE
            var brands = context.Brands.Where(x => x.Title.StartsWith("A")).ToList();
            Console.WriteLine("Počet:" + brands.Count);

            // PRIKLAD 2 - WHERE s LIKE
            //var brandsQuery = context.Brands.Where(x => x.Title.StartsWith("A"));
            //brandsQuery = brandsQuery.Where(x => x.Title.Contains("p"));
            //var brands = brandsQuery.ToList();
            //Console.WriteLine("Počet:" + brands.Count);

            // PRIKLAD 3 - WHERE s NOT NULL
            //var brands = context.Brands.Where(x => x.Title != null).ToList();
            //Console.WriteLine("Počet:" + brands.Count);

            // PRIKLAD 4 - WHERE se SKIP a TAKE
            //var brands = context.Brands.Where(x => x.BrandId > 0).Skip(1).Take(5).ToList();
            //Console.WriteLine("Počet:" + brands.Count);
        }

        [TestMethod]
        [Description("Projekce dat s klauzulí SELECT")]
        public void ProjekceDat()
        {
            // PRIKLAD 1 - anonymní typ, načtení s projekcí
            var brands1 = context.Brands.Select(x => new {x.BrandId, Ident = x.BrandIdentifier}).ToList();

            // PRIKLAD 2 - anonymni typ, spatne nacteni s projekci
            //var brands2 = context.Brands.ToList().Select(x => new { x.BrandId, Ident = x.BrandIdentifier });

            // PRIKLAD 3 - dictionary
            //var dictionary = context.Brands.ToDictionary(x => x.BrandId, x => x.BrandIdentifier);

            // PRIKLAD 4 - dictionary spravne
            //var dictionary = context.Brands.Select(x => new { x.BrandId, x.BrandIdentifier })
            //    .ToDictionary(x => x.BrandId, x => x.BrandIdentifier);
        }

        [TestMethod]
        [Description("Client a Server evaluation")]
        public void ClientServerEvaluation()
        {
            // PRIKLAD 1 - client evaluation
            var products = context.Products
                .OrderBy(x => x.Title)
                .Select(x => new
                {
                    Id = x.ProductId,
                    SeoLink = NormalizeSeoUrl(x.SeoLink)
                }).Take(3).ToList();

            // PRIKLAD 2 - client evaluation (!)
            //var categories = context.Categories
            //    .OrderBy(x => x.Title)
            //    .Where(x => NormalizeSeoUrl(x.SeoLink).Contains("telefon"))
            //    .Select(x => new
            //    {
            //        Id = x.CategoryId,
            //        SeoLink = NormalizeSeoUrl(x.SeoLink)
            //    }).Take(3).ToList();
        }

        public string NormalizeSeoUrl(string url)
        {
            url = url.ToLower();

            return url;
        }

        [TestMethod]
        [Description("Shadow Properties")]
        public void ShadowProperties()
        {
            // PRIKLAD 1 - order by
            var brand = context.Brands.OrderBy(x => EF.Property<DateTime>(x, "LastUpdated")).FirstOrDefault();

            // PRIKLAD 2 - get value přes entry
            //var lastUpdated = context.Entry(brand).Property("LastUpdated").CurrentValue;

            // PRIKLAD 3 - get many
            //var many = context.Brands.Select(x => new
            //{
            //    Brand = x,
            //    LastUpdated = EF.Property<DateTime>(x, "LastUpdated")
            //}).ToList();
        }

        [TestMethod]
        [Description("Agregace nad daty")]
        public void AgregaceNadDaty()
        {
            // PRIKLAD 1 - běžné operace
            var productsCount = context.Products.Count();

            // PRIKLAD 2 - podmíněné agregace
            //var freeProductsCount = context.Products.Count(x => x.Price.BasePrice == 0);

            //var productsWithImage = context.Products.Count(x => x.Images.Any());

            //var maxPrice = context.Products.Max(x => x.Price.BasePrice);

            //var avgImages = context.Products.Average(x => x.Images.Count);
        }

        [TestMethod]
        [Description("Query Types, Views, Tables bez PK, Storky")]
        public void QueryTypes()
        {
            // PRIKLAD 1 - SQL query + mapovani na views
            //context.Database.ExecuteSqlCommand(
            //    @"CREATE VIEW View_ProductImagesCounts AS SELECT SeoLink, Count(i.ImageId) as ImagesCount from Products p
            //        JOIN Images i on i.ProductId = p.ProductId GROUP BY p.SeoLink");

            //var all = context.ProductImagesCounts.ToList();

            // PRIKLAD 2 - plain SQL - ! neidealni queries
            //var data = context.Categories
            //    .FromSql("SELECT CategoryId, Title, SeoLink, Extras FROM Categories WHERE CategoryId > 0")
            //    .OrderBy(x => x.SeoLink)
            //    .ToList();

            // PRIKLAD 3 - stored procedure
            //var products = context.Products.FromSql("EXECUTE dbo.AllProducts").ToList();

            // PRIKLAD 4 - stored procedure s parametrem
            //var productsWithParam = context.Products.FromSql("EXECUTE dbo.AllProducts {0}", "parameter").ToList();

            // PRIKLAD 5 - stored procedure s sql parametrem
            //var param = new SqlParameter("productId", 1);
            //var productsWithSqlParam = context.Products.FromSql("EXECUTE dbo.AllProducts @productId", param).ToList();
        }

        [TestMethod]
        [Description("Group By")]
        public void GroupByMetoda()
        {
            // PRIKLAD 1 - group by
            var group = context.Products.GroupBy(
                x => x.SeoLink,
                x => x.Images.Count,
                (key, g) => new {ProductId = key, Count = g}).ToList();

            // PRIKLAD 2 - lookup
            //var lookup = context.Products.Select(x => new {x.SeoLink, x.Images.Count}).ToList();
        }

        [TestMethod]
        [Description("Asynchronní dotazy")]
        public async Task AsynchronniDotazy()
        {
            // PRIKLAD 1 - ToListAsync
            var all = await context.Brands.Where(x => x.BrandId > 0).ToListAsync();

            // PRIKLAD 2 - FirstOrDefaultAsync
            //var concrete = await context.Brands.FirstOrDefaultAsync(x => x.BrandId == 2);
        }

        [TestMethod]
        [Description("Eager loading - Include")]
        public void EagerLoading()
        {
            // PRIKLAD 1 - klasický include
            //var orderWithItems = context.Orders.Include(x => x.OrderItems).ToList();

            // PRIKLAD 2 - multiple include
            //var productCategories = context.ProductCategories
            //    .Include(x => x.Category).ThenInclude(x => x.CategoryDetail)
            //    .Select(x => new {x.ProductId, x.Category.CategoryDetail}).ToList();

            // PRIKLAD 3 - multiple include pro M:N
            //var prod = context.Products
            //    .Include(x => x.ProductCategories).ThenInclude(x => x.Category).ToList();

            // PRIKLAD 4 - include při alternate keys
            //var productsWithBrands = context.Products.Include(x => x.Brand).ToList();

            // PRIKLAD 5 - include při table splitu
            //var categoriesWithDetails = context.Categories.Include(c => c.CategoryDetail).ToList();
        }

        [TestMethod]
        [Description("Explicit loading")]
        public void ExlicitLoading()
        {
            var product = context.Products.FirstOrDefault();

            // PRIKLAD 1 - load kolekce
            context.Entry(product).Collection(x => x.Images).Load();

            // PRIKLAD 2 - load entity
            //context.Entry(product).Reference(x => x.Brand).Load();

            // PRIKLAD 3 - podmineny load kolekce
            //context.Entry(product).Collection(x => x.Images).Query().Where(x=> x.Title != null).Load(); // obrazky s titulkem
        }

        [TestMethod]
        [Description("Lazy loading")]
        public void LazyLoading()
        {
            // PRIKLAD
            var products = context.Products.ToList();
            foreach (var product in products)
            {
                Console.WriteLine(product.ProductCategories.Select(x => x.CategoryId).FirstOrDefault());
            }
        }

        [TestMethod]
        [Description("Entity Type Constructors")]
        public void EntityTypesCtors()
        {
            // PRIKLAD 1 - context jako vstupní parametr 
            var brands = context.Brands.Take(3).ToList()
                .Select(x => new
                {
                    x.BrandIdentifier,
                    ProductCount = x.GetPaidProductsWithBrand()
                }).ToList();
        }

        [TestMethod]
        [Description("Explicitni Join a Group")]
        public void ExplicitniJoinGroup()
        {
            // product with comments
            var result = (from product in context.Products
                    join relation in context.Relations
                        on new
                        {
                            a = product.ProductId,
                            b = (int) RelationObjectType.Product,
                            c = (int) RelationObjectType.Category
                        } equals new
                        {
                            a = relation.SourceObjectId,
                            b = relation.SourceObjectType,
                            c = relation.ObjectType
                        }
                    join category in context.Categories on relation.ObjectId equals category.CategoryId
                    group category by product
                    into gr
                    select new
                    {
                        Product = gr.Key,
                        Category = gr.ToList()
                    })
                .ToList();
        }
    }
}