using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Examples
{
	public class ReturnAwaitExample
	{
		public async void Execute()
		{
			var syncResult =  await ExampleAsyncMethod();
		}

		/// <summary>
		/// Pokud metoda může vracet ne-awaitable výsledek, použít ValueTask
		/// </summary>
		async ValueTask<bool> ExampleAsyncMethod()
		{
			try
			{
				return await Task.FromResult(true);
			}
			catch (Exception e)
			{
				// log e
				return false;
			}
		}
	}
}
