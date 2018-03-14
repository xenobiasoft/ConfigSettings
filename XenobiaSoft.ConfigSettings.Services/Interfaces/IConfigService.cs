namespace XenobiaSoft.ConfigSettings.Services.Interfaces
{
	public interface IConfigService
	{
		void LoadConfigurations(string rootPath);
		void ClearDb();
	}
}