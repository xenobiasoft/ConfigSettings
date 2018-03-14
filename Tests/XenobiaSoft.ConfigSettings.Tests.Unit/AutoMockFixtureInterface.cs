namespace XenobiaSoft.ConfigSettings.Tests.Unit
{
	public abstract class AutoMockFixtureInterface<TTestType, TInterfaceType> : AutoMockTestFixture where TTestType : class, TInterfaceType
	{
		protected TInterfaceType Sut => Resolve<TTestType>();
	}
}