namespace XenobiaSoft.Tests.Utilities.ImmutableStructures
{
	public static class ImmutableStructureTests<T>
	{
		public static Tester<T> ConstructorParameter<A>(A value, string propertyName)
		{
			return new Tester<T>().ConstructorParameter<A>(value, propertyName);
		}
	}
}