using System;

namespace demo.Services.Generators
{
	public class GuidGen : IScopedGuidGen, ITransientGuidGen, ISingletonGuidGen
	{
		private readonly Guid guid;

		public GuidGen() : this(Guid.NewGuid())
		{
		}

		public GuidGen(Guid guid)
		{
			this.guid = guid;
		}

		public string GetGuid()
		{
			return guid.ToString();
		}
	}
}