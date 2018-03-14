using System;

namespace XenobiaSoft.ConfigSettings.Repository.Models
{
	public abstract class BaseEntity
	{
		public int Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime ModifiedDate { get; set; }
		public bool IsNew => Id == 0;
	}
}