using System;

namespace XenobiaSoft.ConfigSettings.Services.Exceptions
{
	public class ExistsInCacheException : ApplicationException
	{
		private const string _ExceptionMessage = "{0} {1} already exists in cache.";

		public ExistsInCacheException(Type type, string key)
			: base(string.Format(_ExceptionMessage, type.Name, key))
		{}
	}
}