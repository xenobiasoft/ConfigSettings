using System;

namespace XenobiaSoft.Tests.Utilities.ConstructorTests
{
	public static class ConstructorTests<T>
	{
		public static Tester<T> For(params Type[] argTypes)
		{
			var ctor = typeof(T).GetConstructor(argTypes);

			if (ctor == null)
			{
				return new MissingConstructorTester<T>();
			}

			return new ConstructorTester<T>(ctor);
		}
	}
}