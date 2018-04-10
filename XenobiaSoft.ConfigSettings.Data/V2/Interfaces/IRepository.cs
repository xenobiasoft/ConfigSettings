using System;
using System.Data.Common;

namespace XenobiaSoft.ConfigSettings.Data.V2.Interfaces
{
	public interface IRepository : IDisposable
	{
		void UseTransation(DbTransaction transation);
	}
}