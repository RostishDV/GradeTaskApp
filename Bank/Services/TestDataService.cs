using GradeTaskApp.Bank.Entity;
using GradeTaskApp.Bank.IRepositry;
using GradeTaskApp.Bank.IService;
using GradeTaskApp.Bank.Repositry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTaskApp.Bank.Services
{
	public class TestDataService : ITestDataService
	{
		private readonly IAccountRepository _accountRepository;
		private readonly IHistoryRepository _historyRepository;
		private readonly IUserRepositry _userRepositry;
		
		private readonly ITransactionService _transactionService;

		public TestDataService(BankContext bankContext)
		{
			_accountRepository = new AccountRepository(bankContext);
			_historyRepository = new HistoryRepository(bankContext);
			_userRepositry = new UserRepository(bankContext);
			_transactionService = new TransactionService(bankContext);
		}
		public void AddTestData()
		{
			//GenerateUsers()
			var random = new Random();
			var users = _userRepositry.Get();
			foreach (var user in users)
			{
				var accountCount = random.Next(0, 3);
				for (var i = 0; i < accountCount; i++)
				{
					var account = new Account()
					{
						UserId = user.Id,
						Monny = random.Next(0, 100000),
					};
					_accountRepository.Create(account);
					Console.WriteLine("Пользователю " + user.Id + " создан счет " + account.Id);
					var transactionsCount = random.Next(0, 10);
					for (var j = 0; j < transactionsCount; j++)
					{
						var type = random.Next(0, 2);
						if (type == 0){
							_transactionService.PushMoney(account.Id, random.Next(0, 5000));
						} else {
							_transactionService.SpendMoney(account.Id, random.Next(0, 2000));
						}
					}
				}
			}
		}

		private IEnumerable<User> GenerateUsers()
		{
			var user1 = new User()
			{
				Name = "Иван",
				Surname = "Иванович",
				Patronimic = "Иванович",
				Passport = "Российсикй",
				Login = "Ваня",
				Phone = "рабочий",
				Password = "Vanya123"
			};
			_userRepositry.Create(user1);
			var user2 = new User()
			{
				Name = "Константин",
				Surname = "Долгов",
				Patronimic = "Батькович",
				Passport = "Другой паспорт",
				Login = "Constanto",
				Phone = "городской",
				Password = "Constantinio1"
			};
			_userRepositry.Create(user2);
			var user3 = new User()
			{
				Name = "Павел",
				Surname = "Васильев",
				Patronimic = "Андреевич",
				Passport = "Еще один паспорт",
				Login = "Pashahuskar2003",
				Phone = "домашний",
				Password = "Pasha3228"
			};
			_userRepositry.Create(user3);
			return _userRepositry.Get();
		}
	}
}
