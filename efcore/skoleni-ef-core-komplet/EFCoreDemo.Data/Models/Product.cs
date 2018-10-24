using System.Collections.Generic;

namespace EFCoreDemo.Data.Models
{
    public class Product
    {
        public static int MaxTitleLength = 100;
        
        public int ProductId { get; set; }
        public string BrandIdentifier { get; set; }
        public string Title { get; set; }
        public string SeoLink { get; set; }
        public Price Price { get; set; }
        public string TemporaryNotes { get; set; }
        public string ProductWarehouseIdent { get; set; }
        
        
        public Brand Brand { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public List<Image> Images { get; set; }
    }
}