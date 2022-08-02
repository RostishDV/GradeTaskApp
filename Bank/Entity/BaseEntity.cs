using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTaskApp.Bank.Entity
{
	public class BaseEntity : IEntity
	{
		[Key]
		public Guid Id { get; set; }
		public DateTime Created { get; set; }
		public void SetDefaultColumnValues()
		{
			if (Id == Guid.Empty) Id = Guid.NewGuid();
			Created = DateTime.UtcNow;
		}
	}
}
