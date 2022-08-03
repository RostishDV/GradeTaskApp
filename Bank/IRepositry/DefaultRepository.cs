using GradeTaskApp.Bank.Entity;

namespace GradeTaskApp.Bank.IRepositry
{
	public interface IDefaultRepository<TEntity> where TEntity : IEntity
	{
		public void Create(TEntity item);
		public TEntity FindById(Guid id);
		public IEnumerable<TEntity> Get();
		public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
		public void Remove(TEntity item);
		public void Update(TEntity item);
	}
}
