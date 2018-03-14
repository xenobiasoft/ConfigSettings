using System;
using System.Diagnostics.Contracts;

namespace XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.SharedAppSettings
{
	[ContractClass(typeof(ValueHolder))]
	public interface IValueHolder
	{
		ISharedAppSettingBuilder WithValue(string value);
	}

	[ContractClassFor(typeof(IValueHolder))]
	public abstract class ValueHolder : IValueHolder
	{
		public ISharedAppSettingBuilder WithValue(string value)
		{
			Contract.Requires<ArgumentNullException>(value != null);

			return null;
		}
	}
}