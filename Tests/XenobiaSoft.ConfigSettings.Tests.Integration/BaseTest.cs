using Autofac;
using NUnit.Framework;
using XenobiaSoft.ConfigSettings.Installer;

namespace XenobiaSoft.ConfigSettings.Tests.Integration
{
	public abstract class BaseTest<TTestType> where TTestType : class
	{
		private IContainer _Container;

		[SetUp]
		public void Setup()
		{
			PreSetup();

			var builder = new ContainerBuilder();
			builder.RegisterModule(new InstallerModule());

			_Container = builder.Build();

			PostSetup();
		}

		public virtual void PreSetup() { }

		public virtual void PostSetup() { }

		protected TType Resolve<TType>() where TType : class
		{
			return _Container.Resolve<TType>();
		}

		public TestContext TestContext => TestContext.CurrentContext;

		protected TTestType Sut => Resolve<TTestType>();
	}
}