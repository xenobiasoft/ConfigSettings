﻿using System.Collections.Generic;
using XenobiaSoft.ConfigSettings.Data.Models;
using XenobiaSoft.ConfigSettings.Services.Models;

namespace XenobiaSoft.ConfigSettings.Services.Interfaces.Parsers
{
	public interface IAppSettingsParser : IParser<List<AppSetting>>
	{
	}
}