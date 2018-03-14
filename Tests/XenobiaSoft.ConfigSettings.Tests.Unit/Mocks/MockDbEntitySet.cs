using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using XenobiaSoft.ConfigSettings.Repository.Models;

namespace XenobiaSoft.ConfigSettings.Tests.Unit.Mocks
{
	public class MockDbEntitySet<TEntityType> : IDbSet<TEntityType> where TEntityType : BaseEntity
	{
		public MockDbEntitySet()
		{
			Local = new ObservableCollection<TEntityType>();
		}

		public TEntityType Add(TEntityType entity)
		{
			var newId = Local.Count + 1;

			Local.Add(entity);
			entity.Id = newId;

			return entity;
		}

		public TEntityType Attach(TEntityType entity)
		{
			throw new NotImplementedException();
		}

		public TEntityType Create()
		{
			throw new NotImplementedException();
		}

		public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, TEntityType
		{
			throw new NotImplementedException();
		}

		public IEnumerator<TEntityType> GetEnumerator()
		{
			foreach (var entity in Local)
			{
				yield return entity;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public TEntityType Find(params object[] keyValues)
		{
			int.TryParse(keyValues.First().ToString(), out var id);

			return Local.FirstOrDefault(x => x.Id == id);
		}

		public TEntityType Remove(TEntityType entity)
		{
			Local.Remove(entity);
			entity.Id = 0;

			return entity;
		}


		public Expression Expression { get; }
		public Type ElementType { get; }
		public ObservableCollection<TEntityType> Local { get; }
		public IQueryProvider Provider { get; }
	}
}
