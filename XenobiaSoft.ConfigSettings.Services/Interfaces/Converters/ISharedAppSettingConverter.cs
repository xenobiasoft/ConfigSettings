using XenobiaSoft.ConfigSettings.Data.Models;
using XenobiaSoft.ConfigSettings.Services.Models;

namespace XenobiaSoft.ConfigSettings.Services.Interfaces.Converters
{
	public interface ISharedAppSettingConverter
	{
		SharedAppSetting Convert(AppSettingModel sharedAppSettingModel);
	}
}