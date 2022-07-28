using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTaskApp.SingleLinkList
{
	public interface INode<T> 
	{
		public T Data { get; set; }
		public INode<T> Next { get; set; }

	}
}
