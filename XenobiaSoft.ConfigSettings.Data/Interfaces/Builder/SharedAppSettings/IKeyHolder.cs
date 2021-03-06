﻿using System;
using System.Diagnostics.Contracts;

namespace XenobiaSoft.ConfigSettings.Data.Interfaces.Builder.SharedAppSettings
{
	[ContractClass(typeof(KeyHolder))]
	public interface IKeyHolder
	{
		IValueHolder WithKey(string key);
	}

	[ContractClassFor(typeof(IKeyHolder))]
	public abstract class KeyHolder : IKeyHolder
	{
		public IValueHolder WithKey(string key)
		{
			Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(key));

			return null;
		}
	}
}