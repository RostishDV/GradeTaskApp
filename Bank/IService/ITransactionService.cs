namespace GradeTaskApp.Bank.IService
{
	internal interface ITransactionService
	{
		public void SpendMoney(Guid accountId, decimal amount);
		public void PushMoney(Guid accountId, decimal amount);
	}
}
