using System.Collections.Generic;
using System.Linq;

namespace EFCoreDemo.Data.Models
{
    public class Brand
    {
        public Brand()
        {
        }

        public Brand(DemoDbContext context)
        {
            Context = context;
        }

        public DemoDbContext Context { get; set; }

        public int BrandId { get; set; }

        public string BrandIdentifier { get; set; }
        public string Title { get; set; }

        public byte[] Timestamp { get; set; }
        
        public List<Product> Products { get; set; }
        
        public int GetPaidProductsWithBrand()
        {
            return Context.Products.Count(x => x.BrandIdentifier == BrandIdentifier && x.Price.BasePrice > 0);
        }

    }
}