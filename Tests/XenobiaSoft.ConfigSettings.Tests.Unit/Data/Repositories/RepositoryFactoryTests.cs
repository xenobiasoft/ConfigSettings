using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Data.V2.Interfaces;
using XenobiaSoft.ConfigSettings.Data.V2.Models;
using XenobiaSoft.ConfigSettings.Data.V2.Repositories;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Data.Repositories
{
	[TestFixture]
	public class RepositoryFactoryTests : AutoMockFixtureInterface<RepositoryFactory, IRepositoryFactory>
	{
		[Test]
		public void CreateReadOnly_ReturnsReadOnlyRepository()
		{
			// Assemble

			// Act
			var instance = Sut.CreateReadOnly<ProjectEnvironmentConfiguration>();

			// Assert
			instance.Should().BeAssignableTo<IReadOnlyRepository<ProjectEnvironmentConfiguration>>();
		}

		[Test]
		public void CreateSaving_ReturnsSavingRepository()
		{
			// Assemble
			
			// Act
			var instance = Sut.CreateSaving<ProjectEnvironmentConfiguration, int>();

			// Assert
			instance.Should().BeAssignableTo<ISavingRepository<ProjectEnvironmentConfiguration, int>>();
		}
	}
}