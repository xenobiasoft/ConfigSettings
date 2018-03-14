using XenobiaSoft.ConfigSettings.Services.Models;

namespace XenobiaSoft.ConfigSettings.Services.Interfaces.Parsers
{
	public interface IParser<out TType> where TType : class
	{
		TType Parse(ConfigFile configFile);
	}
}