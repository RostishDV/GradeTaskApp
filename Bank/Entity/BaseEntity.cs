using System.ComponentModel.DataAnnotations;

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
