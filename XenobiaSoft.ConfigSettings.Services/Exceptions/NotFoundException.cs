using System;

namespace XenobiaSoft.ConfigSettings.Services.Exceptions
{
	public class NotFoundException : ApplicationException
	{
		private const string _ExceptionMessage = "{0} {1} was not found in cache.";

		public NotFoundException(Type type, string key)
			: base(string.Format(_ExceptionMessage, type.Name, key))
		{}
	}
}