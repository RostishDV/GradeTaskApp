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
	public class TransactionService : ITransactionService
	{
		private readonly IAccountRepository _accountRepository;
		private readonly IHistoryRepository _historyRepository;

		public TransactionService(BankContext bankContext)
		{
			_accountRepository = new AccountRepository(bankContext);
			_historyRepository = new HistoryRepository(bankContext);
		}

		public void SpendMoney(Guid accountId, decimal amount)
		{
			var account = _accountRepository.FindById(accountId);
			if (account == null) {
				Console.WriteLine("Счет не найден");
				return;
			}
			if (account.Monny < amount) {
				Console.WriteLine("Недостаточно средств");
				return;
			}
			var history = new History(){
				AccountId = accountId,
				Amount = amount,
				OperationType = OperationType.SUBTRACT
			};
			_historyRepository.Create(history);
			account.Monny -= amount;
			_accountRepository.Update(account);
		}

		public void PushMoney(Guid accountId, decimal amount)
		{
			var account = _accountRepository.FindById(accountId);
			if (account == null)
			{
				Console.WriteLine("Счет не найден");
			}
			if (account.Monny < amount)
			{
				Console.WriteLine("Недостаточно средств");
			}
			var history = new History()
			{
				AccountId = accountId,
				Amount = amount,
				OperationType = OperationType.ADD
			};
			_historyRepository.Create(history);
			account.Monny -= amount;
			_accountRepository.Update(account);
		}
	}
}
