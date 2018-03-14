namespace XenobiaSoft.ConfigSettings.Tests.Unit
{
	public abstract class AutoMockFixtureConcrete<TTestType> : AutoMockTestFixture where TTestType : class
	{
		protected TTestType Sut => Resolve<TTestType>();
	}
}