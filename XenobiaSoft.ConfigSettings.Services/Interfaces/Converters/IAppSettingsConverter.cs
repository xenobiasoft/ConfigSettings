using XenobiaSoft.ConfigSettings.Data.Models;

namespace XenobiaSoft.ConfigSettings.Services.Interfaces.Converters
{
	public interface IAppSettingConverter
	{
		AppSetting Convert(Data.V2.Models.AppSetting appSettingModel);
	}
}