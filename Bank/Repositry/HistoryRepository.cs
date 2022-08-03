using GradeTaskApp.Bank.Entity;
using GradeTaskApp.Bank.IRepositry;

namespace GradeTaskApp.Bank.Repositry
{
	internal class HistoryRepository : IHistoryRepository
	{
		private readonly BankContext _bankContext;
		public HistoryRepository(BankContext bankContext)
		{
			_bankContext = bankContext;
		}
		public void Create(History item)
		{
			item.SetDefaultColumnValues();
			_bankContext.History.Add(item);
			_bankContext.SaveChanges();
		}

		public History FindById(Guid id)
		{
			return _bankContext.History.Find(id);
		}

		public IEnumerable<History> Get()
		{
			return _bankContext.History.ToList();
		}

		public IEnumerable<History> Get(Func<History, bool> predicate)
		{
			return _bankContext.History.Where(predicate).ToList();
		}

		public IEnumerable<History> GetByAccount(Guid accountId)
		{
			return _bankContext.History.Where(x => x.AccountId == accountId).OrderBy(x => x.Created).ToList();
		}

		public Dictionary<History, User> GetAdditions()
		{
			return _bankContext.History.Where(x => x.OperationType == OperationType.ADD)
			.Join(
				_bankContext.Accounts,
				h => h.AccountId,
				a => a.Id,
				(h, a) => new {
					History = h, 
					Account = a
				}).Join(_bankContext.Users,
					ha => ha.Account.UserId,
					u => u.Id,
					(ha, u) => new {
						History = ha.History,
						User = u
					}).ToDictionary(o => o.History, o => o.User);
		}

		public void Remove(History item)
		{
			_bankContext.History.Remove(item);
			_bankContext.SaveChanges();
		}

		public void Update(History item)
		{
			_bankContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			_bankContext.SaveChanges();
		}
	}
}
