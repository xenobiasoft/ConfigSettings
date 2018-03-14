using System;
using System.Reflection;

namespace XenobiaSoft.Tests.Utilities.ConstructorTests
{
	public class SuccessTest<T> : TestCase<T>
	{
		private readonly Func<T, bool> _Validator;

		public SuccessTest(ConstructorInfo ctor, object[] args, Func<T, bool> validator, string failMessage)
			: base(ctor, args, failMessage)
		{
			_Validator = validator;
		}

		public override string Execute()
		{
			try
			{
				var obj = InvokeConstructor();

				if (!_Validator(obj))
				{
					return Fail("Validation failed.");
				}
			}
			catch (Exception ex)
			{
				return Fail($"{ex.GetType().Name} occurred: {ex.Message}");
			}

			return Success();
		}
	}
}
