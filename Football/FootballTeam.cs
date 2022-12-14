using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTaskApp.Football
{
	public class FootballTeam
	{
		private Footballer[] players = new Footballer[11];
		public Footballer this[int index]
		{
			get { return players[index]; }
			set {
				if (index >= players.Length) 
				{
					var tmp = players;
					players = new Footballer[index * 2];
					tmp.CopyTo(players, 0);
				}
				players[index] = value; 
			}
		}
	}
}
