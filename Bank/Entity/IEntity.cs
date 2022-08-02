using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTaskApp.Bank.Entity
{
	public interface IEntity
	{
		public Guid Id { get; set; }
		public void SetDefaultColumnValues();
	}
}
