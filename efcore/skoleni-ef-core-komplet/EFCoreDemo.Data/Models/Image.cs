using System.Net.Http;

namespace EFCoreDemo.Data.Models
{
    public class Image
    {
        private string _validatedUrl;
        
        public int ImageId { get; set; }
        public int ProductId { get; set; }
        public string Title { get; set; }

        public string GetUrl()
        {
            return _validatedUrl;
        }

        public void SetUrl(string url)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
            }

            _validatedUrl = url;
        }
        
        public Product Product { get; set; }
    }
}