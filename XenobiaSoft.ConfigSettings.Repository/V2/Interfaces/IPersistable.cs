using System;

namespace XenobiaSoft.ConfigSettings.Repository.V2.Interfaces
{
	public interface IPersistable : IDisposable
	{
		void Save();
	}
}