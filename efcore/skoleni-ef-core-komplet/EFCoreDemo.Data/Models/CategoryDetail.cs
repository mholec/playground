namespace EFCoreDemo.Data.Models
{
    public class CategoryDetail
    {
        public int CategoryId { get; set; }
        public string Url { get; set; }
        
        public Category Category { get; set; }
    }
}