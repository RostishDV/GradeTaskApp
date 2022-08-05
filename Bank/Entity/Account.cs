using System.ComponentModel.DataAnnotations.Schema;

namespace GradeTaskApp.Bank.Entity
{
	public class Account : BaseEntity
	{
		public decimal Monny { get; set; }
		[ForeignKey("User")]
		public Guid UserId { get; set; }

		public User User { get; set; }
		public IEnumerable<History> Histories { get; set; }

		public Account()
		{

		}

		public Account(decimal _monny, Guid _userId, IEnumerable<History> _histories)
		{
			Monny = _monny;
			UserId = _userId;
			Histories = _histories;
		}
	}
}
