using GradeTaskApp.Bank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTaskApp.Bank.IService
{
	public interface IInfoService
	{
		public User PrintUserInformationByLogpass(string login, string password);
		public IEnumerable<Account> PrintAccountsInformationByUser(User user);
		public void PrintAccountsInformationWithHistoryByUser(User user);
		public void PrintAdditionTransitions();

	}
}
