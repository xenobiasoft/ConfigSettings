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
	public abstract class SavingRepositoryTests<TModel, TKey> : AutoMockFixtureInterface<SavingRepository<TModel, TKey>, ISavingRepository<TModel, TKey>>
	{
		[Test]
		public void GetById_WithValidId_ReturnsSingleInstance()
		{
			// Assemble
			
			// Act
			var instance = Sut.GetById(GetValidId());

			// Assert
			instance.Should().BeAssignableTo<TModel>();
		}

		[Test]
		public void Save_AfterModifyingModel_UpdatesTheModel()
		{
			// Assemble
			var existing = Sut.GetById(GetValidId());

			ModifyModel(existing);

			// Act
			Sut.Save();

			var actual = Sut.GetById(GetValidId());

			// Assert
			actual.Should().Be(existing);
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

		protected abstract TKey GetValidId();

		protected abstract void ModifyModel(TModel model);
	}
}
