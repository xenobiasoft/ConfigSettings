using System;
using System.Reflection;

namespace XenobiaSoft.Tests.Utilities.ImmutableStructures
{
	public class PropertyGetterTest<T>
	{
		private readonly string _PropertyName;
		private readonly object _PropertyValue;

		public PropertyGetterTest(string propertyName, object value)
		{
			_PropertyName = propertyName;
			_PropertyValue = value;
		}

		public string Execute(object obj)
		{
			var prop = typeof(T).GetProperty(_PropertyName);

			if (prop == null)
			{
				return $"Property {_PropertyName} not found.";
			}

			return TestProperty(prop, obj);
		}

		private string TestProperty(PropertyInfo prop, object obj)
		{
			try
			{
				var value = GetPropertyValue(prop, obj);

				if (!_PropertyValue.Equals(value))
				{
					return $"Property {_PropertyName} returned {value} when expecting {_PropertyValue}.";
				}
			}
			catch (Exception ex)
			{
				return $"Property {_PropertyName} threw {ex.GetType()}: {ex.Message}.";
			}

			return string.Empty;
		}

		private object GetPropertyValue(PropertyInfo prop, object obj)
		{
			try
			{
				return prop.GetValue(obj, null);
			}
			catch (TargetInvocationException ex)
			{
				throw ex.InnerException;
			}
		}
	}
}