using System.Collections.Generic;

namespace EFCoreDemo.Data.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string SeoLink { get; set; }
        public string Extras { get; set; }
        
        public CategoryDetail CategoryDetail { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}