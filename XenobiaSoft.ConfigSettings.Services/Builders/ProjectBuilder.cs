using System;
using XenobiaSoft.ConfigSettings.Repository.Models;
using XenobiaSoft.ConfigSettings.Services.Interfaces.Builder.Projects;

namespace XenobiaSoft.ConfigSettings.Services.Builders
{
	public class ProjectBuilder : IProjectBuilder, IProjectNameHolder
	{
		private ProjectBuilder()
		{}

		public static IProjectNameHolder CreateNew()
		{
			return new ProjectBuilder();
		}

		public static IProjectNameHolder CreateExisting(int id)
		{
			if (id <= 0)
			{
				throw new ArgumentException(nameof(id));
			}

			return new ProjectBuilder
			{
				Id = id
			};
		}

		public IProjectBuilder WithName(string projectName)
		{
			if (string.IsNullOrEmpty(projectName))
			{
				throw new ArgumentNullException(nameof(projectName));
			}

			return new ProjectBuilder
			{
				Id = Id,
				ProjectName = projectName
			};
		}

		public Project Build()
		{
			return new Project
			{
				Id = Id,
				ProjectName = ProjectName,
				CreatedDate = DateTime.Now,
				ModifiedDate = DateTime.Now
			};
		}

		private int Id { get; set; }
		private string ProjectName { get; set; }
	}
}