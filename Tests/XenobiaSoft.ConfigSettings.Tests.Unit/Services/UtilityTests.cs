using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Services;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Services
{
	[TestFixture()]
	public class UtilityTests
	{
		[TestFixture]
		public class GetEnvironmentNameTests : UtilityTests
		{
			[Test]
			public void ReturnsLocalForNonTransformedConfigs()
			{
				// Assemble
				var configNames = new List<string> { "web.config", "app.config" };
				var expectedEnvironmentName = "LOCAL";
				var actualEnvironmentNames = new List<string>();

				// Act
				configNames.ForEach(x => actualEnvironmentNames.Add(Utility.GetEnvironmentName(x)));

				// Assert
				actualEnvironmentNames.ForEach(x => x.Should().Be(expectedEnvironmentName));
			}

			[Test]
			public void CanParseEnvironmentFromTransformedConfig()
			{
				// Assemble
				var configFileName = "web.production.config";
				var expectedEnvironmentName = "PRODUCTION";

				// Act
				var actualEnvironmentName = Utility.GetEnvironmentName(configFileName);

				// Assert
				actualEnvironmentName.Should().Be(expectedEnvironmentName);
			}
		}
	}
}