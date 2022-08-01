using GradeTaskApp.Bank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTaskApp.Bank.IRepositry
{
	public interface IDefaultRepository<TEntity> where TEntity : IEntity
	{
		public void Create(TEntity item);
		public TEntity FindById(int id);
		public IEnumerable<TEntity> Get();
		public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
		public void Remove(TEntity item);
		public void Update(TEntity item);
	}
}
