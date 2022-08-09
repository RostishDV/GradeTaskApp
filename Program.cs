#region USINGS
using GradeTaskApp.Bank;
using GradeTaskApp.Bank.Services;
using GradeTaskApp.Football;
using GradeTaskApp.SingleLinkList;
using GradeTaskApp.Person;
using System.Reflection;
using GradeTaskApp.Summator;
using GradeTaskApp.Users;

#endregion
namespace GradeTaskApp {
	public class Program {
		public static void Main(string[] args) {
			TestValidators();
		}

		#region Football
		private static void TestFootball()
		{
			var firstFootballer = new Footballer()
			{
				Name = "First",
				Number = 1
			};
			var team = new FootballTeam();
			team[0] = firstFootballer;

			team[15] = new Footballer()
			{
				Name = "Test",
				Number = 2
			};
			Console.WriteLine(team[0].ToString());
		}

		#endregion

		#region SingleLinkList
		private static void TestSingleLinkList() {

			var list = new SingleLinkList<int>();
			var rand = new Random();
			for (int i = 0; i < 10000; i++)
			{
				int number = rand.Next(0, 9000);
				list.Add(number);
			}
			foreach (var link in list) { 
				Console.Write(link + " ");
			}
			Console.WriteLine();

			list.AlexseySort();

			foreach (var link in list)
			{
				Console.Write(link + " ");
			}
			// Test is sorted
			var prev = list.First().Data;
			foreach (var link in list)
			{
				if (prev.CompareTo(link) > 0)
				{
					Console.WriteLine("Not sorted prev =" + prev + "; cur = " + link);
				}
				prev = link;
			}
		}

		#endregion

		#region Bank

		private static void GenerateTestData()
		{
			BankContext context = new();
			TestDataService dataService = new(context);
			InfoService infoService = new(context);
			dataService.CheckUserExist("Ваня", "Vanya123");
			//dataService.AddTestData();
			var user = infoService.PrintUserInformationByLogpass("Ваня", "Vanya123");
			Console.WriteLine("/===============================================");
			Console.WriteLine();
			var accounts = infoService.PrintAccountsInformationByUser(user);
			Console.WriteLine("/===============================================");
			Console.WriteLine();
			infoService.PrintAccountsInformationWithHistoryByUser(user);
			Console.WriteLine("/===============================================");
			Console.WriteLine();
			infoService.PrintAdditionTransitions();
			Console.WriteLine("/===============================================");
			Console.WriteLine();
			infoService.PrintInformationAboutUsersWithMoney(1000);
		}

		#endregion

		#region WebsiteParser

		private static void TestWebsiteParser()
		{
			var startUrl = @"https://regex101.com/";
			var urls = GradeTaskApp.WebsiteParser.WebsiteParser.GetURLsFromSite(startUrl);
			foreach (var url in urls)
			{
				Console.WriteLine(url);
			}
		}

		#endregion

		#region Person Reflection
		public static void TestPersonReflection()
		{
			Console.WriteLine("=== Class info  ===");
			Person.Person.PrintClassInfo();
			Console.WriteLine("=== Object info ===");
			var person = new Person.Person();
			person.Name = "Ivan";
			person.Surname = "Ivanov";
			person.Patronimic = "Ivanovich";
			person.PrintObjectInfo();

			var personType = person.GetType();
			var personFields = personType.GetFields(BindingFlags.Instance |
					   BindingFlags.NonPublic);
			foreach (var field in personFields)
			{
				if (field.Name == "_salary")
				{
					field.SetValue(person, (decimal)140000);
				}
			}
			var method = person.GetType().GetMethod("SayInfo");
			if (method != null)
			{
				method.Invoke(person, null);
			}
		}

		#endregion

		#region Summator

		public static void TestSummator()
		{
			var methods = typeof(SimpleSummator).GetMethods(BindingFlags.Instance |
					BindingFlags.Public);
			foreach (var method in methods)
			{
				var parameter = method.GetParameters();
				if (parameter.Length == 2)
				{
					Console.WriteLine(method.Invoke(new SimpleSummator(), new object[] { 10, 25 }));
				}
				if (parameter.Length == 3)
				{
					Console.WriteLine(method.Invoke(new SimpleSummator(), new object[] { 10, 25, 35 }));
				}
				if (parameter.Length == 4)
				{
					Console.WriteLine(method.Invoke(new SimpleSummator(), new object[] { 10, 25, 35, 45 }));
				}
			}
		}

		#endregion

		#region Users delegate filter

		public static void TestDelegate()
		{
			var userDbSet = new UsersDbSet();
			userDbSet.Add(new User { Name = "Ivan", Surname = "Petrovich" });
			userDbSet.Add(new User { Name = "Ivan", Surname = "Ivanovich" });
			userDbSet.Add(new User { Name = "Ivan", Surname = "Petrov" });
			userDbSet.Add(new User { Name = "Pavel", Surname = "Dolgov" });

			var users = userDbSet.GetUsers(x => x.Name == "Ivan");
			foreach(var user in users)
			{
				Console.WriteLine(user.Name + " " + user.Surname);
			}
		}

		#endregion

		#region Users by FieldName FieldValue

		public static void TestFieldNameValue()
		{
			var userDbSet = new UsersDbSet();
			userDbSet.Add(new User { Name = "Ivan", Surname = "Petrovich" });
			userDbSet.Add(new User { Name = "Ivan", Surname = "Ivanovich" });
			userDbSet.Add(new User { Name = "Ivan", Surname = "Petrov" });
			userDbSet.Add(new User { Name = "Pavel", Surname = "Dolgov" });

			var users = userDbSet.GetUsers("Name", "Ivan");
			foreach (var user in users)
			{
				Console.WriteLine(user.Name + " " + user.Surname);
			}
		}

		#endregion

		#region User validators

		public static void TestValidators()
		{
			var usersDbSet = new UsersDbSet();
			var validUser = new User 
			{ 
				Name ="Valid",
				Surname = "Vilidovich",
				Email = "some@email.com",
				Phone = "+7(917) 654-78-98"
			};

			var invalidUser = new User
			{
				Name = "Valid",
				Surname = "Vilidovich",
				Email = "abc",
				Phone = "def"
			};
			usersDbSet.Add(validUser);
			usersDbSet.Add(invalidUser);
			Console.WriteLine("Валидные:");
			var users = usersDbSet.GetUsers(x => true);
			foreach (var user in users)
			{
				Console.WriteLine($"name = {user.Name}, surname = {user.Surname}, email = {user.Email}, phone = {user.Phone}");
			}
		}

		#endregion
	}
}



