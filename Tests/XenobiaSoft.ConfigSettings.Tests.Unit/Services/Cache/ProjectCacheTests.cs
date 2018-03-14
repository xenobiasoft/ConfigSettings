using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Repository.Models;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Services.Cache
{
	[TestFixture]
	public class ProjectCacheTests : CacheTests<Project>
	{
		private Project _Project;

		protected override string GetName()
		{
			return _Project.ProjectName;
		}

		protected override Project GetEntity()
		{
			return _Project;
		}

		public override void PostSetup()
		{
			_Project = Create<Project>();
		}
	}
}