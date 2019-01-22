using WebApp.Services;

namespace WebApp.Facades
{
    public class MainFacade
    {
        private readonly IMailService mail;
        private readonly IProductListQuery productListQuery;

        public MainFacade(IMailService mail, IProductListQuery productListQuery)
        {
            this.mail = mail;
            this.productListQuery = productListQuery;
        }

        public HomeViewModel GetHomepage(string searchBy = null)
        {
            productListQuery.Filter = new ProductListQueryFilter()
            {
                SearchBy = searchBy
            };

            QueryResult<ProductViewModel> data = productListQuery.Execute();

            mail.SendEmail();

            return new HomeViewModel() {Result = data};
        }
    }
}