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
			item.SetDefaultColumnValues();
			item.Password = CalculatePasswordHash(item.Password);
			_bankContext.Users.Add(item);
			_bankContext.SaveChanges();
		}

		public User FindById(Guid id)
		{
			return _bankContext.Users.Find(id);
		}

		public IEnumerable<User> Get()
		{
			return _bankContext.Users.ToList();
		}

		public IEnumerable<User> Get(Func<User, bool> predicate)
		{
			return _bankContext.Users.Where(predicate).ToList();
		}

		public void Remove(User item)
		{
			_bankContext.Users.Remove(item);
			_bankContext.SaveChanges();
		}

		public void Update(User item)
		{
			_bankContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			_bankContext.SaveChanges();
		}

		public User? GetUserByLogpass(string login, string password)
		{
			var passwordHash = CalculatePasswordHash(password);
			User? user = _bankContext.Users.Where(x =>
					x.Login == login && x.Password == passwordHash).FirstOrDefault();
			return user;
		}

		public IEnumerable<User> GetUsersWithAccountAmountGreater(decimal amount)
		{
			return _bankContext.Accounts.Where(x => x.Monny > amount).Join(_bankContext.Users,
				a => a.UserId,
				u => u.Id,
				(a, u) => u).ToList();
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
