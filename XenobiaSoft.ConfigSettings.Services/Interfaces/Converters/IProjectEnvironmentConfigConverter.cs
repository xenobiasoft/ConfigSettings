using XenobiaSoft.ConfigSettings.Repository.Models;
using XenobiaSoft.ConfigSettings.Services.Models;

namespace XenobiaSoft.ConfigSettings.Services.Interfaces.Converters
{
	public interface IProjectEnvironmentConfigConverter
	{
		ProjectEnvironmentConfig Convert(ProjectEnvironmentConfiguration projectConfiguration);
	}
}