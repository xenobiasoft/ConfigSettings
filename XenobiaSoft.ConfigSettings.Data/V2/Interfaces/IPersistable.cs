using System;

namespace XenobiaSoft.ConfigSettings.Data.V2.Interfaces
{
	public interface IPersistable : IDisposable
	{
		void Save();
	}
}