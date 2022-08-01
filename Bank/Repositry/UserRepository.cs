using GradeTaskApp.Bank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using GradeTaskApp.Bank.IRepositry;

namespace GradeTaskApp.Bank
{

	public class UserRepository : IUserRepositry
	{
		private readonly BankContext _bankContext;
		public UserRepository(BankContext bankContext) {
			_bankContext = bankContext;
		}

		public void Create(User item)
		{
			var newUser = new User
			{
				Id = Guid.NewGuid(),
				Name = item.Name,
				Surname = item.Surname,
				Patronimic = item.Patronimic,
				Phone = item.Phone,
				Passport = item.Passport,
				RegistrationDate = DateTime.Now,
				Login = item.Login,
				Password = CalculatePasswordHash(item.Password),
			};

		}

		public User FindById(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<User> Get()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<User> Get(Func<User, bool> predicate)
		{
			throw new NotImplementedException();
		}

		public User? GetUserByLogpass(string login, string password)
		{
			var passwordHash = CalculatePasswordHash(password);
			User? user = _bankContext.Users.Where(x => 
					x.Login == login && x.Password == passwordHash).FirstOrDefault();
			return user;
		}

		public void Remove(User item)
		{
			throw new NotImplementedException();
		}

		public void Update(User item)
		{
			throw new NotImplementedException();
		}

		private string CalculatePasswordHash(string password)
		{
			byte[]? array = new MD5CryptoServiceProvider()
					.ComputeHash(UTF8Encoding.UTF8.GetBytes(password));
			int i;
			StringBuilder sOutput = new StringBuilder(array.Length);
			for (i = 0; i < array.Length; i++)
			{
				sOutput.Append(array[i].ToString("X2"));
			}
			return sOutput.ToString();
		}
	}
}
