using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTaskApp.Bank.Entity
{
	public class User : IEntity
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Patronimic { get; set; }
		public string Phone { get; set; }
		public string Passport { get; set; }
		public DateTime RegistrationDate { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
	}
}
