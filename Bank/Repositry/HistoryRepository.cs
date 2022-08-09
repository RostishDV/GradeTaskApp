using GradeTaskApp.Bank.Entity;
using GradeTaskApp.Bank.IRepositry;
using System.Linq;

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

		public Dictionary<Account, List<History>> GetHistoriesWithAccountByUserId(Guid userId)
		{
			var t = (from acc in _bankContext.Accounts.Where(x => x.UserId == userId).ToList()
					 join history in _bankContext.History
						 on acc.Id equals history.AccountId into historyJoin
					 select new
					 {
						 Account = acc,
						 History = historyJoin.DefaultIfEmpty()
					 }).ToList();

			var t2 = (from acc in _bankContext.Accounts.Where(a => a.UserId == userId)
					  from history in _bankContext.History.Where(h => h.AccountId == acc.Id).DefaultIfEmpty()
					  select new
					  {
						  Account = acc,
						  History = history
					  }).ToList().GroupBy(h => h.Account).ToDictionary(h => h.Key, x => x.Select(_ => _.History));

			Dictionary < Account, List<History>> dict = _bankContext.History.Join(_bankContext.Accounts.Where(a => a.UserId == userId),
				h => h.AccountId,
				a => a.Id,
				(h, a) => new {
					History = h,
					Account = a
				}).ToList().GroupBy(x => x.Account)
				.ToDictionary(g => g.Key, g => g.Select(x => x.History).ToList());
			var keys = dict.Keys;
			Dictionary<Account, List<History>> accWithoutHistories = _bankContext.Accounts.Where(x => !keys.Contains(x) && x.UserId == userId)
				.ToDictionary(g => g, g => { return new List<History>(); });
			
			return dict.Union(accWithoutHistories).ToDictionary(x => x.Key, x => x.Value);
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
