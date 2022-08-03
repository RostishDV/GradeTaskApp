using System.ComponentModel.DataAnnotations.Schema;

namespace GradeTaskApp.Bank.Entity
{
	public class History : BaseEntity
	{
		public OperationType OperationType { get; set; }
		public decimal Amount { get; set; }

		[ForeignKey("Account")]
		public Guid AccountId { get; set; }
		public Account Account { get; set; }
		
	}
}
