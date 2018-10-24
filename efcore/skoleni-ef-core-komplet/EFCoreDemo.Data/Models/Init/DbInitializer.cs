using System.Linq;

namespace EFCoreDemo.Data.Models.Init
{
    public static class DbInitializer
    {
        public static void Initialize(DemoDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Products.Any())
            {
                // seed products
            }

            if (!context.Categories.Any())
            {
                // seed categories
            }

            context.SaveChanges();
        }
    }
}