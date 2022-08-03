using GradeTaskApp.Bank.Entity;

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
