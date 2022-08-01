using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTaskApp.Bank.Entity
{
	public class OperationType : IEntity
	{
		public string Name { get; set; }
		public Guid Id { get; set; }
	}
}
