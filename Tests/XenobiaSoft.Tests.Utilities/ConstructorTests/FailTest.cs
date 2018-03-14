using System;
using System.Reflection;

namespace XenobiaSoft.Tests.Utilities.ConstructorTests
{
	public class FailTest<T> : TestCase<T>
	{
		private readonly Type _ExceptionType;

		public FailTest(ConstructorInfo ctor, object[] args, Type exceptionType, string failMessage)
			: base(ctor, args, failMessage)
		{
			_ExceptionType = exceptionType;
		}

		public override string Execute()
		{
			try
			{
				InvokeConstructor();

				return Fail($"{_ExceptionType.Name} not thrown when expected.");
			}
			catch (Exception ex)
			{
				if (ex.GetType() != _ExceptionType)
				{
					return Fail($"{ex.GetType().Name} thrown when {_ExceptionType.Name} was expected.");
				}
			}

			return Success();
		}
	}
}
