using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace GradeTaskApp.Users
{
	public class UsersDbSet
	{
		private List<User> _users = new List<User>();
		public void Add(User user)
		{
			var сontext = new ValidationContext(user);
			var results = new List<ValidationResult>();
			if (user == null) return;
			if (!Validator.TryValidateObject(user, сontext, results, true))
			{
				Console.WriteLine("Не удалось добавить пользователя");
				foreach (var item in results)
				{
					Console.WriteLine(item.ErrorMessage);
				}
				return;
			}
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

		public List<User> GetUsers(string fieldName, object value)
		{
			var userType = typeof(User);
			var field = userType.GetField($"<{fieldName}>k__BackingField", BindingFlags.Instance | BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.NonPublic);
			if (field == null) return new List<User>();

			return _users.Where((user) => {
				var fieldValue = field.GetValue(user);
				if (fieldValue == null)
					return false;
				return fieldValue.Equals(value);
			}).ToList();
		}
	}

	public class User
	{
		public string Name { get; set; }

		public string Surname { get; set; }
		[EmailValidator]
		public string Email { get; set; }
		[PhoneValidator]
		public string Phone { get; set; }
	};
}
