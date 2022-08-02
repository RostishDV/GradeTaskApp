using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
