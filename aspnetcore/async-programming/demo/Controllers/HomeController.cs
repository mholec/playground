using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using demo.Data;
using demo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demo.Controllers
{
    public class HomeController : Controller
    {
	    private readonly DownloadWebsiteService downloadWebsiteService;

	    public HomeController(DownloadWebsiteService downloadWebsiteService)
	    {
		    this.downloadWebsiteService = downloadWebsiteService;
	    }

		[Route("")]
	    public async Task<IActionResult> Index()
        {
			Stopwatch sw = new Stopwatch();
	        sw.Start();

	        for (int i = 0; i < 5; i++)
	        {
				// nejčastější užití - diskové a síťové operace, přístup do db, I/O
				var content = await downloadWebsiteService.GetContentAsync("http://httpstat.us/200?sleep=2000");

		        // práce na něčem jiném, nezávislém
				// mělo by to být něco, co je long-running (jinak to nemá smysl)
		        Thread.Sleep(2000);
		        
				// práce s daty získanými asynchronně
				var cont = content.Substring(0,1);
			}
			sw.Stop();

	        return Ok(sw.ElapsedMilliseconds);
		}

	    [Route("all")]
	    public async Task<IActionResult> All()
	    {
		    Stopwatch sw = new Stopwatch();
		    sw.Start();

			List<string> results = new List<string>();
			List<Task<string>> awaitResults = new List<Task<string>>();

		    for (int i = 0; i < 5; i++)
		    {
				var content = await downloadWebsiteService.GetContentAsync("http://httpstat.us/200?sleep=4000");
				results.Add(content);

				//var content = downloadWebsiteService.GetContentAsync("http://httpstat.us/200?sleep=4000");
				//awaitResults.Add(content);
			}

			await Task.WhenAll(awaitResults);
			//awaitResults.ForEach(x => x.Wait());
			//awaitResults.ForEach(async x => results.Add(await x));

			sw.Stop();

		    return Ok(sw.ElapsedMilliseconds);
	    }


		[Route("canceltoken")]
		public async Task<IActionResult> CancelToken(CancellationToken cancellationToken)
	    {
		    Stopwatch sw = new Stopwatch();
		    sw.Start();

		    for (int i = 0; i < 10; i++)
		    {
			    if (cancellationToken.IsCancellationRequested)
			    {
				    return BadRequest();
			    }

			    Thread.Sleep(1000);
			}

			sw.Stop();

		    return Ok(sw.ElapsedMilliseconds);
	    }

	    [Route("data")]
	    public async Task<IActionResult> Data()
	    {
		    Stopwatch sw = new Stopwatch();
		    sw.Start();

		    using (var db = new DemoDbContext())
		    {
				// v případě single DB serveru bez podpory connection poolingu by bylo cokoliv async zbytečné
			    var data = await db.Articles.ToListAsync();

			    for (int i = 0; i < 50; i++)
			    {
				    db.Books.Add(new Book()
				    {
						BookId = i + 1,
						Title = "Book extra #" + i + 1
				    });
			    }

				// async update jen v případě nezávislých dat
			    await db.SaveChangesAsync();
		    }

		    sw.Stop();

		    return Ok(sw.ElapsedMilliseconds);
	    }
	}
}