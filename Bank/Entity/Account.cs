using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTaskApp.Bank.Entity
{
	public class Account : IEntity
	{
		public DateTime Created { get; set; }
		public decimal Monny { get; set; }
		public Guid UserId { get; set; }
		public Guid Id { get; set; }
	}
}
