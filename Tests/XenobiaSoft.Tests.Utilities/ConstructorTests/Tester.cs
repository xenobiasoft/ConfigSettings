using System;

namespace XenobiaSoft.Tests.Utilities.ConstructorTests
{
	public abstract class Tester<T>
	{
		public abstract Tester<T> Fail(object[] args, Type exceptionType, string failMessage);
		public abstract Tester<T> Succeed(object[] args, Func<T, bool> validator, string failMessage);
		public abstract void Assert();
	}
}
