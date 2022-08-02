using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTaskApp.Bank.IService
{
	internal interface ITransactionService
	{
		public void SpendMoney(Guid accountId, decimal amount);
		public void PushMoney(Guid accountId, decimal amount);
	}
}
