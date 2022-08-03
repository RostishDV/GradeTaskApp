using System.ComponentModel.DataAnnotations.Schema;

namespace GradeTaskApp.Bank.Entity
{
	public class Account : BaseEntity
	{
		public decimal Monny { get; set; }
		[ForeignKey("User")]
		public Guid UserId { get; set; }

		public User User { get; set; }
		public List<History> Histories { get; set; }
	}
}
