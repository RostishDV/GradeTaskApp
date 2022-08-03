namespace GradeTaskApp.Bank.Entity
{
	public interface IEntity
	{
		public Guid Id { get; set; }
		public void SetDefaultColumnValues();
	}
}
