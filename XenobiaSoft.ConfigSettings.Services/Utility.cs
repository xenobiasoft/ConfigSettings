namespace XenobiaSoft.ConfigSettings.Services
{
	public static class Utility
	{
		public static string GetEnvironmentName(string fileName)
		{
			var environmentName = fileName.ToLower()
				.Replace("web", string.Empty)
				.Replace("app", string.Empty)
				.Replace("config", string.Empty)
				.Replace(".", string.Empty)
				.ToUpper();

			if (string.IsNullOrEmpty(environmentName))
			{
				environmentName = "LOCAL";
			}

			return environmentName;
		}
	}
}