using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace XenobiaSoft.Tests.Utilities.ImmutableStructures
{
	public class Tester<TType>
	{
		private readonly List<Type> _CtorArgumentTypes = new List<Type>();
		private readonly List<object> _CtorArguments = new List<object>();
		private readonly List<PropertyGetterTest<TType>> _PropertyTests = new List<PropertyGetterTest<TType>>();

		public Tester<TType> ConstructorParameter<TValue>(TValue value, string propertyName)
		{
			var copy = new Tester<TType>();

			copy._CtorArgumentTypes.AddRange(_CtorArgumentTypes);
			copy._CtorArgumentTypes.Add(typeof(TValue));

			copy._CtorArguments.AddRange(_CtorArguments);
			copy._CtorArguments.Add(value);

			copy._PropertyTests.AddRange(_PropertyTests);
			copy._PropertyTests.Add(new PropertyGetterTest<TType>(propertyName, value));

			return copy;
		}

		public void Assert()
		{
			var ctor = GetConstructor();

			Assert(ctor);
		}

		private ConstructorInfo GetConstructor()
		{
			return typeof(TType).GetConstructor(_CtorArgumentTypes.ToArray());
		}

		private void Assert(ConstructorInfo ctor)
		{
			var errorMessage = Test(ctor);
			var success = string.IsNullOrEmpty(errorMessage);

			Debug.Assert(success, errorMessage);
		}

		private string Test(ConstructorInfo ctor)
		{
			if (ctor == null)
			{
				return "Missing constructor";
			}

			try
			{
				var obj = (TType)ctor.Invoke(_CtorArguments.ToArray());

				return Test(obj);
			}
			catch (TargetInvocationException ex)
			{
				return ex.InnerException.Message;
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		private string Test(TType obj)
		{
			var errors = new StringBuilder();

			foreach (var test in _PropertyTests)
			{
				var error = test.Execute(obj);

				if (!string.IsNullOrEmpty(error))
				{
					errors.AppendLine(error);
				}
			}

			if (errors.Length > 0)
			{
				return $"Some property getters failed: {errors}";
			}

			return string.Empty;
		}
	}
}