using System;
using FluentAssertions;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Data.Models;
using XenobiaSoft.ConfigSettings.Services.Exceptions;
using XenobiaSoft.ConfigSettings.Services.Interfaces;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Services.Cache
{
	[TestFixture]
	public abstract class CacheTests<TType> : AutoMockFixtureInterface<ConfigSettings.Services.Cache, ICache> where TType : BaseEntity
	{
		[Test]
		public void Exists_ReturnsFalse_WhenNotExists()
		{
			// Assemble

			// Act
			var exists = Sut.Exists<TType>(GetName());

			// Assert
			exists.Should().BeFalse();
		}

		[Test]
		public void Exists_ReturnsTrue_WhenExists()
		{
			// Assemble
			var entity = Create<TType>();
			Sut.Add(GetName(), entity);

			// Act
			var exists = Sut.Exists<TType>(GetName());

			// Assert
			exists.Should().BeTrue();
		}

		[Test]
		public void Get_ReturnsEntity_WhenExists()
		{
			// Assemble
			var expectedEntity = GetEntity();
			Sut.Add(GetName(), expectedEntity);

			// Act
			var entity = Sut.Get<TType>(GetName());

			// Assert
			entity.Should().Be(expectedEntity);
		}

		[Test]
		public void Get_ThrowsNotFoundException_WhenNotInCache()
		{
			// Assemble

			// Act
			Action get = () => Sut.Get<TType>(GetName());

			// Assert
			get.Should().Throw<NotFoundException>().WithMessage($"{typeof(TType).Name} {GetName()} was not found in cache.");
		}

		[Test]
		public void Add_ReturnsTrue_WhenEntityExists()
		{
			// Assemble
			var entity = GetEntity();

			// Act
			Sut.Add(GetName(), entity);

			// Assert
			Sut.Exists<TType>(GetName()).Should().BeTrue();
		}

		[Test]
		public void Add_ThrowsExistsInCacheException_WhenEntityAlreadyExistsInCache()
		{
			// Assemble
			var entity = GetEntity();
			Sut.Add(GetName(), entity);

			// Act
			Action add = () => Sut.Add(GetName(), entity);

			// Assert
			add.Should().Throw<ExistsInCacheException>().WithMessage($"{typeof(TType).Name} {GetName()} already exists in cache.");
		}

		protected abstract string GetName();
		protected abstract TType GetEntity();
	}
}