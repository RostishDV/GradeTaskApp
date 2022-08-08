using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTaskApp.Users
{
	public class UsersDbSet
	{
		private List<User> _users = new List<User>();

		public void Add(User user)
		{
			_users.Add(user);
		}

		public List<User> GetUsers(Func<User, bool> filter)
		{
			var result = _users.Where(filter);
			var users = new List<User>();
			foreach (var user in _users)
			{
				if (filter(user))
				{
					users.Add(user);
				}
			}
			return users;
		}
	}

	public class User
	{
		public string Name { get; set; }
		public string Surname { get; set; }
	};
}
