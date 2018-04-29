using System;
using System.Diagnostics.Contracts;

namespace XenobiaSoft.ConfigSettings.Data.Interfaces.Builder.AppSettings
{
	[ContractClass(typeof(TransformTypeHolder))]
	public interface ITransformTypeHolder
	{
		IAppSettingBuilder WithTransformType(string transformType);
	}

	[ContractClassFor(typeof(ITransformTypeHolder))]
	public abstract class TransformTypeHolder : ITransformTypeHolder
	{
		public IAppSettingBuilder WithTransformType(string transformType)
		{
			Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(transformType));

			return null;
		}
	}
}