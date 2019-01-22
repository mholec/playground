using System.Linq;
using Model;

namespace WebApp.Facades
{
    public class ProductListQuery : IProductListQuery
    {
        private readonly DemoContext db;

        public ProductListQueryFilter Filter { get; set; }

        public ProductListQuery(DemoContext db)
        {
            this.db = db;
        }

        public QueryResult<ProductViewModel> Execute()
        {
            var result = Query().Skip(0).Take(int.MaxValue).ToList(); // paging
            var count = Query().Count(); // count

            return new QueryResult<ProductViewModel>(result, count);
        }

        protected IQueryable<ProductViewModel> Query()
        {
            var query = db.Products.AsQueryable();

            if (!string.IsNullOrEmpty(Filter?.SearchBy))
            {
                query = query.Where(x => x.Title.Contains(Filter.SearchBy));
            }

            // ... order by..

            return query.OrderBy(x => x.ProductId).Select(x => new ProductViewModel()
            {
                ProductId = x.ProductId,
                Title = x.Title
            });
        }
    }
}