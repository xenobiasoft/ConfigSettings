using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Parsers;
using XenobiaSoft.ConfigSettings.Services.Models;

namespace XenobiaSoft.ConfigSettings.Services.Parsers
{
	public class AppSettingsParser : IAppSettingsParser
	{
		public List<AppSettingModel> Parse(ConfigFile configFile)
		{
			XNamespace ns = "http://schemas.microsoft.com/XML-Document-Transform";
			var xElement = XDocument.Load(configFile.FilePath).Root;

			return xElement
				?.Element("appSettings")
				?.Elements()
				.Select(x =>
				{
					var key = x.Attribute("key")?.Value;
					var value = x.Attribute("value")?.Value;
					var transformType = x.Attribute(ns + "Transform")?.Value;

					return new AppSettingModel(key, value, transformType);
				})
				.ToList();
		}
	}
}