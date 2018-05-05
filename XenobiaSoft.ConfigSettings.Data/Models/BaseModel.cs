using System;

namespace XenobiaSoft.ConfigSettings.Data.Models
{
	public class BaseModel
	{
		public int Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime ModifiedDate { get; set; }
	}
}