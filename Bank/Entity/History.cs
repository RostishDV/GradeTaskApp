using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTaskApp.Bank.Entity
{
	public class History : IEntity
	{
		public Guid OperationTypeId { get; set; }
		public DateTime Created { get; set; }
		public decimal Amount { get; set; }
		public Guid AccountId { get; set; }
		public Guid Id { get; set; }
	}
}
