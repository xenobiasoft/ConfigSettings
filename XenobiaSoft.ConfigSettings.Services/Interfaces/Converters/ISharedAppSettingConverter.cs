using XenobiaSoft.ConfigSettings.Data.Models;
using XenobiaSoft.ConfigSettings.Data.V2.Models;
using XenobiaSoft.ConfigSettings.Services.Models;

namespace XenobiaSoft.ConfigSettings.Services.Interfaces.Converters
{
	public interface ISharedAppSettingConverter
	{
		SharedAppSetting Convert(Data.V2.Models.AppSetting sharedAppSettingModel);
	}
}