using GradeTaskApp.Bank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTaskApp.Bank.IRepositry
{
	public interface IUserRepositry : IDefaultRepository<User>
	{
		public User GetUserByLogpass(string login, string password);
	}
}
