using System;
using System.Diagnostics;

namespace XenobiaSoft.Tests.Utilities.ConstructorTests
{
	public class MissingConstructorTester<T> : Tester<T>
	{
		public override Tester<T> Fail(object[] args, Type exceptionType, string failMessage)
		{
			return this;
		}

		public override Tester<T> Succeed(object[] args, Func<T, bool> validator, string failMessage)
		{
			return this;
		}

		public override void Assert()
		{
			Debug.Assert(false, "Missing constructor.");
		}
	}
}
