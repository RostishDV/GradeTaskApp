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
		
		public void Create(Account item)
		{
			throw new NotImplementedException();
		}

		public Account FindById(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Account> Get()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Account> Get(Func<Account, bool> predicate)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Account> GetByUser(User user)
		{
			throw new NotImplementedException();
		}

		public void Remove(Account item)
		{
			throw new NotImplementedException();
		}

		public void Update(Account item)
		{
			throw new NotImplementedException();
		}
	}
}
