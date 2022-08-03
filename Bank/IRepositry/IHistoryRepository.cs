using GradeTaskApp.Bank.Entity;

namespace GradeTaskApp.Bank.IRepositry
{
	public interface IHistoryRepository : IDefaultRepository<History>
	{
		public IEnumerable<History> GetByAccount(Guid accountId);
		public Dictionary<History, User> GetAdditions();
	}
}
