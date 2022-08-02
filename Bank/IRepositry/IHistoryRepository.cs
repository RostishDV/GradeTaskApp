using GradeTaskApp.Bank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTaskApp.Bank.IRepositry
{
	public interface IHistoryRepository : IDefaultRepository<History>
	{
		public IEnumerable<History> GetByAccount(Guid accountId);
		public Dictionary<History, User> GetAdditions();
	}
}
