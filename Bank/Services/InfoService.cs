using GradeTaskApp.Bank.Entity;
using GradeTaskApp.Bank.IRepositry;
using GradeTaskApp.Bank.IService;
using GradeTaskApp.Bank.Repositry;

namespace GradeTaskApp.Bank.Services
{
	public class InfoService : IInfoService
	{
		private readonly IAccountRepository _accountRepository;
		private readonly IUserRepositry _userRepositry;
		private readonly IHistoryRepository _historyRepository;

		public InfoService(BankContext bankContext)
		{
			_accountRepository = new AccountRepository(bankContext);
			_userRepositry = new UserRepository(bankContext);
			_historyRepository = new HistoryRepository(bankContext);
		}

		/// <summary>
		/// Вывод информации о заданном аккаунте по логину и паролю.
		/// </summary>
		/// <param name="login"> Логин пользователя </param>
		/// <param name="password"> Пароль </param>
		public User PrintUserInformationByLogpass(string login, string password)
		{
			var user = _userRepositry.GetUserByLogpass(login, password);
			if (user != null) {
				Console.WriteLine("Пользователь:");
				Console.WriteLine("\tИмя:" + user.Name);
				Console.WriteLine("\tФамилия:" + user.Surname);
				Console.WriteLine("\tОтчество:" + user.Patronimic);
				Console.WriteLine("\tТелефон:" + user.Phone);
				Console.WriteLine("\tПаспорт:" + user.Passport);
				Console.WriteLine("\tДата регистрации:" + user.Created);
			} else {
				Console.WriteLine("Пользователь с такой парой логина и пароля не найден в системе");
			}
			return user;
		}

		/// <summary>
		/// Вывод данных о всех счетах заданного пользователя.
		/// </summary>
		/// <param name="user"> Пользователь </param>
		public IEnumerable<Account> PrintAccountsInformationByUser(User user)
		{
			var accounts = _accountRepository.GetByUserId(user.Id);
			Console.WriteLine("Счета пользователя " + user.Name + ":");
			var accountNumber = 1;
			foreach (var account in accounts) {
				Console.WriteLine("\tНа счете " + accountNumber + 
					", созданом " + account.Created + 
					", сейчас " + account.Monny + " денег");
				accountNumber++;
			}
			return accounts;
		}

		/// <summary>
		/// Вывод данных о всех счетах заданного пользователя, включая историю по каждому счету.
		/// </summary>
		/// <param name="user"></param>
		public void PrintAccountsInformationWithHistoryByUser(User user)
		{
			var currentUser = _userRepositry.FindById(user.Id);
			Console.WriteLine("Для пользователя " + currentUser.Name + " " + currentUser.Surname + ":");
			var accountNumber = 1;
			var accounts = _accountRepository.GetByUserId(currentUser.Id);
			foreach (var account in accounts) {
				Console.WriteLine("\tПо счету " + accountNumber + " с текущим балансом " + 
					account.Monny + ", выполнены операции:");
				var historyNumber = 1;
				var histories = _historyRepository.GetByAccount(account.Id);
				foreach (var history in histories) {
					Console.WriteLine("\t\t" + history.Created + 
						(history.OperationType == OperationType.ADD ? " Пополнение на : ": " Списание : ") +
						history.Amount + " денег");
				}
				accountNumber++;
			}
		}
		/// <summary>
		/// Вывод данных о всех операциях пополнения счёта с указанием владельца каждого счета.
		/// </summary>
		public void PrintAdditionTransitions()
		{
			var historyUser = _historyRepository.GetAdditions();
			foreach (var hu in historyUser)
			{
				History history = hu.Key;
				User user = hu.Value;
				Console.WriteLine(history.Created + " пополнение счета " +
					user.Name + " " + user.Surname +
					" на " + history.Amount + " денег ");
			}
		}

		/// <summary>
		/// Вывод данных о всех пользователях у которых на счёте сумма больше заданной.
		/// </summary>
		/// <param name="amount">Заданная сумма на счете</param>
		public void PrintInformationAboutUsersWithMoney(decimal amount)
		{
			var users = _userRepositry.GetUsersWithAccountAmountGreater(amount);
			foreach (User user in users)
			{
				Console.WriteLine("Пользователь:");
				Console.WriteLine("\tИмя:" + user.Name);
				Console.WriteLine("\tФамилия:" + user.Surname);
				Console.WriteLine("\tОтчество:" + user.Patronimic);
				Console.WriteLine("\tТелефон:" + user.Phone);
				Console.WriteLine("\tПаспорт:" + user.Passport);
				Console.WriteLine("\tДата регистрации:" + user.Created);
			}
		}
	}
}
