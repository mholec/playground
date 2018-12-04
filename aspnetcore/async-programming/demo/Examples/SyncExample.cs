using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Examples
{
	public class SyncExample
	{
		public void Execute()
		{
			// pokud potřebuji nutně sync, nepoužívat Wait / Result ale GetAwaiter().GetResult()
			bool syncResult = ExampleAsyncMethod().GetAwaiter().GetResult();
		}

		async Task<bool> ExampleAsyncMethod()
		{
			await Task.Delay(1000);

			return true;
		}
	}
}
