using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Examples
{
	public class ConfigureAwaitExample
	{
		public async void Execute()
		{
			// Prasárna, ale podchycená
			bool result2 = ExampleAsyncMethod().Result;

			// Ideální
			bool result1 = await ExampleAsyncMethod();
		}

		async Task<bool> ExampleAsyncMethod()
		{
			// Týká se spíše libraries, kde hrozí, že nějaký šotek udělá .Result, pak je lepší použít ConfigureAwait()
			// Spíš jde o UI apky, kde blokující volání zmrazí vlákno
			await Task.Delay(1000).ConfigureAwait(false);

			return true;
		}
	}
}
