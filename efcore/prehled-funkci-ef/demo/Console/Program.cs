using System;
using Lib.OneToMany;

namespace Console
{
	class Program
	{
		static void Main(string[] args)
		{
			new Lib.OneToMany		.Example().Run();
			new Lib.OwnedTypes		.Example().Run();
		}
	}
}
