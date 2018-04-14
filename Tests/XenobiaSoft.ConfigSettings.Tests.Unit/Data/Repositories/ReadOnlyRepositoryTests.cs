using System;
using System.Data.Common;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Data.V2.Interfaces;
using XenobiaSoft.ConfigSettings.Data.V2.Repositories;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Data.Repositories
{
	[TestFixture]
	public abstract class ReadOnlyRepositoryTests<TModel> : AutoMockFixtureInterface<ReadOnlyRepository<TModel>, IReadOnlyRepository<TModel>>
	{
		[Test]
		public void QueryAll_ReturnsQueryableListOfT()
		{
			// Assemble

			// Act
			var queryable = Sut.QueryAll();

			// Assert
			queryable.Should().AllBeAssignableTo<TModel>();
		}

		[Test]
		public void DoesNotSupportTransactions()
		{
			// Assemble
			
			// Act
			Action useTransaction = () => Sut.UseTransation(It.IsAny<DbTransaction>());

			// Assert
			useTransaction.Should().Throw<NotSupportedException>();
		}
	}
}