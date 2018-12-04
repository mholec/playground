using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;

namespace demo.Examples
{
	/// <summary>
	/// Fire & Forget (and get exception)
	/// </summary>
	public class FireAndForgetExample
	{
		public void Execute()
		{
			// Jestliže nechám provést metodu, kde může vzniknout chyba, toto je bezpečný způsob jejího odchycení
			ExampleAsyncMethod().SafeFireAndForget(onException: ex => Console.WriteLine(ex.Message));
		}

		async Task ExampleAsyncMethod()
		{
			await Task.Delay(1000);
		}
	}
}
