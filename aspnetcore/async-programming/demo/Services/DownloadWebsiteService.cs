using System.Net;
using System.Threading.Tasks;

namespace demo.Services
{
	public class DownloadWebsiteService
	{
		public async Task<string> GetContentAsync(string url)
		{
			using (var webClient = new WebClient())
			{
				var content = await webClient.DownloadStringTaskAsync(url);

				return content;
			}
		}

		public string GetContent(string url)
		{
			using (var webClient = new WebClient())
			{
				var content = webClient.DownloadString(url);

				return content;
			}
		}
	}
}
