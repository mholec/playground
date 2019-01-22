namespace WebApp.Facades
{
    public interface IProductListQuery
    {
        ProductListQueryFilter Filter { get; set; }

        QueryResult<ProductViewModel> Execute();
    }
}