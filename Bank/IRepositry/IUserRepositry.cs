using GradeTaskApp.Bank.Entity;

namespace GradeTaskApp.Bank.IRepositry
{
	public interface IUserRepositry : IDefaultRepository<User>
	{
		public User GetUserByLogpass(string login, string password);
		public IEnumerable<User> GetUsersWithAccountAmountGreater(decimal amount);
		public bool CheckUserExists(string login, string password);
	}
}
