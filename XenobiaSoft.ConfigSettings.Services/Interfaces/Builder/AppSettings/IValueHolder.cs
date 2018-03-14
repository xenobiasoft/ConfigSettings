using System;
using System.Diagnostics.Contracts;

namespace XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.AppSettings
{
	[ContractClass(typeof(ValueHolder))]
	public interface IValueHolder
	{
		ITransformTypeHolder WithValue(string value);
	}

	[ContractClassFor(typeof(IValueHolder))]
	public abstract class ValueHolder : IValueHolder
	{
		public ITransformTypeHolder WithValue(string value)
		{
			Contract.Requires<ArgumentNullException>(value != null);

			return null;
		}
	}
}