using Model;

namespace WebApp.Facades
{
    public class ProductListQueryFilter : BaseFilter
    {
        public string SearchBy { get; set; }
    }

    public class BaseFilter
    {
        public string OrderBy { get; set; } = nameof(Product.ProductId);
        public bool Descending { get; set; } = true;
    }
}