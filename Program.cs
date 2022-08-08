#region USINGS
using GradeTaskApp.Bank;
using GradeTaskApp.Bank.Services;
using GradeTaskApp.Football;
using GradeTaskApp.SingleLinkList;
using GradeTaskApp.Person;
using System.Reflection;

#endregion
namespace GradeTaskApp {
	public class Program {
		public static void Main(string[] args) {
			TestPersonReflection();
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

		#region: Person Reflection
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
	}
}



