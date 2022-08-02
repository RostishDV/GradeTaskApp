using GradeTaskApp.Bank.Entity;
using GradeTaskApp.Bank.IRepositry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTaskApp.Bank.Repositry
{
	public class AccountRepository : IAccountRepository
	{
		private readonly BankContext _bankContext;
		public AccountRepository(BankContext bankContext)
		{
			_bankContext = bankContext;
		}
		public void Create(Account item)
		{
			item.SetDefaultColumnValues();

			_bankContext.Accounts.Add(item);
			_bankContext.SaveChanges();
		}

		public Account FindById(Guid id)
		{
			return _bankContext.Accounts.Find(id);
		}

		public IEnumerable<Account> Get()
		{
			return _bankContext.Accounts.ToList();
		}

		public IEnumerable<Account> Get(Func<Account, bool> predicate)
		{
			return _bankContext.Accounts.Where(predicate).ToList();
		}

		public IEnumerable<Account> GetByUserId(Guid userId)
		{
			return _bankContext.Accounts.Where(x => x.UserId == userId).ToList();
		}

		public void Remove(Account item)
		{
			_bankContext.Accounts.Remove(item);
			_bankContext.SaveChanges();
		}

		public void Update(Account item)
		{
			_bankContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			_bankContext.SaveChanges();
		}
	}
}
