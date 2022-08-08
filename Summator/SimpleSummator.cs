using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTaskApp.Summator
{
	public class SimpleSummator
	{
		public int Sum(int a, int b)
		{ 
			return a + b; 
		}

		public int Sum(int a, int b, int c)
		{
			return a + b + c;
		}

		public int Sum(int a, int b, int c, int d)
		{ 
			return a + b + c + d;
		}
	}
}
