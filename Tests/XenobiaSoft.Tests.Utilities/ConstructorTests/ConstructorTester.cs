using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace XenobiaSoft.Tests.Utilities.ConstructorTests
{
	public class ConstructorTester<T> : Tester<T>
	{
		private readonly ConstructorInfo _Ctor;
		private readonly IList<TestCase<T>> _TestCases = new List<TestCase<T>>();

		public ConstructorTester(ConstructorInfo ctor)
		{
			_Ctor = ctor;
		}

		public override Tester<T> Fail(object[] args, Type exceptionType, string failMessage)
		{
			var testCase = new FailTest<T>(_Ctor, args, exceptionType, failMessage);

			_TestCases.Add(testCase);

			return this;
		}

		public override Tester<T> Succeed(object[] args, Func<T, bool> validator, string failMessage)
		{
			var testCase = new SuccessTest<T>(_Ctor, args, validator, failMessage);

			_TestCases.Add(testCase);

			return this;
		}

		public override void Assert()
		{
			var errors = new List<string>();
			ExecuteTestCases(errors);
			Assert(errors);
		}

		private void ExecuteTestCases(List<string> errors)
		{
			foreach (var testCase in _TestCases)
			{
				ExecuteTestCase(errors, testCase);
			}
		}

		private void ExecuteTestCase(List<string> errors, TestCase<T> testCase)
		{
			var error = testCase.Execute();

			if (!string.IsNullOrEmpty(error))
			{
				errors.Add($"----> {error}");
			}
		}

		private void Assert(List<string> errors)
		{
			if (errors.Count > 0)
			{
				var error = $"{errors.Count} error(s) occurred: \n{string.Join("\n", errors.ToArray())}";

				Debug.Assert(false, error);
			}
		}
	}
}