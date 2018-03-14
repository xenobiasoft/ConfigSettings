using System;
using System.Data.Entity;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Repository;
using XenobiaSoft.ConfigSettings.Repository.Interfaces;
using XenobiaSoft.ConfigSettings.Repository.Models;
using XenobiaSoft.ConfigSettings.Tests.Unit.Mocks;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Repositories
{
	public abstract class EntityRepositoryTests<TEntityType> : AutoMockFixtureInterface<EntityRepository<TEntityType>, IRepository<TEntityType>> where TEntityType : BaseEntity
	{
		[Test]
		public void Add_ThrowsException_WhenEntityIsNull()
		{
			// Assemble

			// Act
			Action add = () => Sut.Add(null);

			// Assert
			add.Should().Throw<ArgumentNullException>();
		}

		[Test]
		public void Add_ThrowsException_IfEntityIsNotNew()
		{
			// Assemble

			// Act
			Action add = () => Sut.Add(Create<TEntityType>());

			// Assert
			add.Should().Throw<ArgumentException>().WithMessage($"Cannot add an existing {typeof(TEntityType).Name} to the collection.");
		}

		[Test]
		public void Add_AddsEntityToCollection()
		{
			// Assemble
			var mockDbSet = Resolve<MockDbEntitySet<TEntityType>>();

			// Act
			Sut.Add(CreateNewEntity());

			// Assert
			mockDbSet.Local.Count.Should().Be(1);
		}

		[Test]
		public void Add_AssignsIdToNewEntity()
		{
			// Assemble
			var newEntity = CreateNewEntity();

			// Act
			Sut.Add(newEntity);

			// Assert
			newEntity.Id.Should().BeGreaterThan(0);
		}

		[TestCase(0)]
		[TestCase(-8)]
		public void GetById_ThrowsException_WhenIdLessThanEqualToZero(int id)
		{
			// Assemble

			// Act
			Action getById = () => Sut.GetById(id);

			// Assert
			getById.Should().Throw<ArgumentException>().WithMessage($"{nameof(id)} must be greater than 0.");
		}

		[Test]
		public void GetById_ReturnsEntityWithExpectedId()
		{
			// Assemble
			var newEntity = CreateNewEntity();

			Sut.Add(newEntity);

			// Act
			var actualEntity = Sut.GetById(newEntity.Id);

			// Assert
			actualEntity.Should().Be(newEntity);
		}

		[Test]
		public void GetById_ThrowsException_WhenEntityIsNotInCollection()
		{
			// Assemble
			var id = Create<int>();

			// Act
			Action getById = () => Sut.GetById(id);

			// Assert
			getById.Should().Throw<ArgumentException>().WithMessage($"{typeof(TEntityType).Name} with Id {id} does not exist in the collection.");
		}

		[Test]
		public void Remove_ThrowsException_WhenEntityIsNull()
		{
			// Assemble

			// Act
			Action remove = () => Sut.Remove(null);

			// Assert
			remove.Should().Throw<ArgumentNullException>();
		}

		[Test]
		public void Remove_RemovesEntityFromCollection()
		{
			// Assemble
			var mockDbSet = Resolve<MockDbEntitySet<TEntityType>>();
			var entity = CreateNewEntity();
			Sut.Add(entity);

			// Act
			Sut.Remove(entity);

			// Assert
			mockDbSet.Local.Count.Should().Be(0);
		}

		[Test]
		public void RemoveAll_RemovesAllEntitiesFromCollection()
		{
			// Assemble
			var mockDbSet = Resolve<MockDbEntitySet<TEntityType>>();

			for (var i = 0; i < 10; i++)
			{
				Sut.Add(CreateNewEntity());
			}

			// Act
			Sut.RemoveAll();

			// Assert
			mockDbSet.Local.Count.Should().Be(0);
		}

		protected abstract TEntityType CreateNewEntity();

		public override void PostSetup()
		{
			Fixture.Register(() => Create<MockDbEntitySet<TEntityType>>() as IDbSet<TEntityType>);
		}
	}
}