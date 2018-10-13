using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo.Services.Generators;

namespace demo.Services
{
	public class GuidService
	{
		public GuidService(ITransientGuidGen transient, IScopedGuidGen scoped, ISingletonGuidGen singleton)
		{
			Transient = transient;
			Scoped = scoped;
			Singleton = singleton;
		}

		public ITransientGuidGen Transient { get; }
		public IScopedGuidGen Scoped { get; }
		public ISingletonGuidGen Singleton { get; }

	}
}
