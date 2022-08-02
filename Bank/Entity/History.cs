using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
