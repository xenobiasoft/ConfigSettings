using System.Reflection;

namespace XenobiaSoft.Tests.Utilities.ConstructorTests
{
	public abstract class TestCase<T>
	{
		private readonly ConstructorInfo _Ctor;
		private readonly object[] _Args;
		private readonly string _FailMessage;

		protected TestCase(ConstructorInfo ctor, object[] args, string failMessage)
		{
			_Ctor = ctor;
			_Args = args;
			_FailMessage = failMessage;
		}

		public abstract string Execute();

		protected T InvokeConstructor()
		{
			try
			{
				return (T) _Ctor.Invoke(_Args);
			}
			catch (TargetInvocationException ex)
			{
				throw ex.InnerException;
			}
		}

		protected string Fail(string message)
		{
			return $"Test failed ({_FailMessage}): {message}";
		}

		protected string Success()
		{
			return string.Empty;
		}
	}
}
