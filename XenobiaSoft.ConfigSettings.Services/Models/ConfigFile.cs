namespace XenobiaSoft.ConfigSettings.Services.Models
{
	public class ConfigFile
	{
		public ConfigFile(string filePath, string fileName, string directoryName)
		{
			FilePath = filePath;
			FileName = fileName;
			DirectoryName = directoryName;
		}

		public string FilePath { get; }
		public string DirectoryName { get; }
		public string FileName { get; }

		public override string ToString()
		{
			return FilePath;
		}

		public override int GetHashCode()
		{
			return FilePath.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			var configFile = obj as ConfigFile;

			if (configFile == null)
			{
				return false;
			}

			return configFile.FilePath == FilePath;
		}
	}
}