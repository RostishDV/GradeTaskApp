using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTaskApp.Football
{
	public class Footballer: IComparable
	{
		public Footballer()
		{
			Name = "";
		}

		public Footballer(string name)
		{
			Name = name;
		}

		public Footballer(string name, int number)
		{
			Name = name;
			Number = number;
		}

		public string Name { get; set; }
		public int Number { get; set; }

		public int CompareTo(object? other)
		{
			return other == null ? 1 : Number - ((Footballer)other).Number;
		}

		public int CompareTo(Footballer other)
		{
			return other == null ? 1 : Number - other.Number;
		}

		public string ToString() {
			return Name + "(" + Number + ")";
		}
	}
}
