#region USINGS
using GradeTaskApp.Bank;
using GradeTaskApp.Bank.Services;
using GradeTaskApp.Football;
using GradeTaskApp.SingleLinkList;

#endregion
namespace GradeTaskApp {
	public class Program {
		public static void Main(string[] args) {
			GenerateTestData();
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
			for (int i = 0; i < 100; i++)
			{
				int number = rand.Next(0, 9000);
				list.Add(number);
			}
			foreach (var link in list) { 
				Console.Write(link + " ");
			}
			Console.WriteLine();

			list.Sort();

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

	}
}



