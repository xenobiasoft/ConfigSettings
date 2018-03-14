using System;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.Environments;
using Environment = XenobiaSoft.ConfigSettings.Repository.Models.Environment;

namespace XenobiaSoft.ConfigSettings.Services.Builders
{
	public class EnvironmentBuilder : IEnvironmentBuilder, IEnvironmentNameHolder
	{
		private EnvironmentBuilder()
		{}

		public static IEnvironmentNameHolder CreateNew()
		{
			return new EnvironmentBuilder();
		}

		public static IEnvironmentNameHolder CreateExisting(int id)
		{
			if (id <= 0)
			{
				throw new ArgumentException(nameof(id));
			}

			return new EnvironmentBuilder
			{
				Id = id
			};
		}

		public IEnvironmentBuilder WithName(string environmentName)
		{
			if (string.IsNullOrEmpty(environmentName))
			{
				throw new ArgumentException("Environment Name is required.");
			}

			return new EnvironmentBuilder
			{
				Id = Id,
				EnvironmentName = environmentName
			};
		}

		public Environment Build()
		{
			return new Environment
			{
				Id = Id,
				EnvironmentName = EnvironmentName,
				CreatedDate = DateTime.Now,
				ModifiedDate = DateTime.Now
			};
		}

		private int Id { get; set; }
		private string EnvironmentName { get; set; }
	}
}