using GradeTaskApp.Bank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTaskApp.Bank.IRepositry
{
	public interface IAccountRepository : IDefaultRepository<Account>
	{
		public IEnumerable<Account> GetByUser(User user);
	}
}
