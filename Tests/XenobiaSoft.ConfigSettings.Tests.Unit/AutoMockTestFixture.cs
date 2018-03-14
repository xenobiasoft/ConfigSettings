using System.Linq;
using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using NUnit.Framework;

namespace XenobiaSoft.ConfigSettings.Tests.Unit
{
	public abstract class AutoMockTestFixture
	{
		protected IFixture Fixture;

		[SetUp]
		public void Setup()
		{
			PreSetup();

			Fixture = new Fixture().Customize(new AutoConfiguredMoqCustomization());
			Fixture.Behaviors.OfType<ThrowingRecursionBehavior>()
				.ToList()
				.ForEach(x => Fixture.Behaviors.Remove(x));
			Fixture.Behaviors.Add(new OmitOnRecursionBehavior());

			PostSetup();
		}

		public virtual void PreSetup() { }

		public virtual void PostSetup() { }

		protected TType Create<TType>()
		{
			return Fixture.Create<TType>();
		}

		protected Mock<TType> ResolveMock<TType>() where TType : class
		{
			return Fixture.Freeze<Mock<TType>>();
		}

		protected TType Resolve<TType>() where TType : class
		{
			return Fixture.Freeze<TType>();
		}

		public TestContext TestContext => TestContext.CurrentContext;
	}
}