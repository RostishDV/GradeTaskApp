using GradeTaskApp.Bank.Entity;

namespace GradeTaskApp.Bank.IRepositry
{
	public interface IAccountRepository : IDefaultRepository<Account>
	{
		public IEnumerable<Account> GetByUserId(Guid userId);
	}
}
