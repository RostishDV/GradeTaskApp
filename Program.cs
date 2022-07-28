#region USINGS
using GradeTaskApp.Football;
using GradeTaskApp.SingleLinkList;

#endregion
namespace GradeTaskApp {
	public class Program {
		public static void Main(string[] args) {
			TestSingleLinkList(); ;
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
			for (int i = 0; i < 10; i++) {
				list.Add(rand.Next(100));
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

		}

		#endregion
	}
}



