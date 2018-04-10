using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Data.Models;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Services.Cache
{
	[TestFixture]
	public class EnvironmentCacheTests : CacheTests<Environment>
	{
		private Environment _Environment;

		protected override Environment GetEntity()
		{
			return _Environment;
		}

		protected override string GetName()
		{
			return _Environment.EnvironmentName;
		}

		public override void PostSetup()
		{
			_Environment = Create<Environment>();
		}
	}
}