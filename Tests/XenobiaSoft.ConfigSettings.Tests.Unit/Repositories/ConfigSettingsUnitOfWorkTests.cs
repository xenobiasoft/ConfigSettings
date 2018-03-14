using FluentAssertions;
using Moq;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Repository;
using XenobiaSoft.ConfigSettings.Repository.Interfaces;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Repositories
{
	[TestFixture]
	public class ConfigSettingsUnitOfWorkTests : AutoMockFixtureInterface<ConfigSettingsUnitOfWork, IUnitOfWork>
	{
		[Test]
		public void Commit_CallsCommitOnDbContext()
		{
			// Assemble
			var mockDbContext = ResolveMock<IConfigSettingsContext>();

			// Act
			Sut.Commit();

			// Assert
			mockDbContext.Verify(x => x.Commit(), Times.Once);
		}

		[Test]
		public void Dispose_SetsIsDisposed_ToTrue()
		{
			// Assemble

			// Act
			Sut.Dispose();

			// Assert
			Sut.IsDisposed.Should().BeTrue();
		}
	}
}