using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace GradeTaskApp.Person
{
	public class Person
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Patronimic { get; set; }
		private decimal _salary;
		public void SayInfo()
		{
			Console.WriteLine("Я, " + Name + " " + Surname + " " + Patronimic + " зарабатываю " + _salary);
		}
		/// <summary>
		/// Вывести информацию о методах и полях класса.
		/// </summary>
		public static void PrintClassInfo()
		{
			var className = typeof(Person).FullName;
			Console.WriteLine("Класс " + className + " содержит следующие поля:");
			var fields = typeof(Person).GetFields( BindingFlags.Static |
					   BindingFlags.NonPublic |
					   BindingFlags.Public);
			foreach (var field in fields)
			{
				Console.WriteLine($"\t name = {field.Name}, type = {field.FieldType }, {(field.IsPublic ? " pulic" : " not public")}");
			}
			Console.WriteLine("Класс " + className + " содержит следующие методы:");
			foreach (var method in typeof(Person).GetMethods(BindingFlags.Static |
					   BindingFlags.NonPublic |
					   BindingFlags.Public))
			{
				Console.WriteLine("\t" + method.Name + (method.IsPublic ? " public" : " not public") + " возвращяющий " + method.ReturnType);
				var i = 1;
				foreach (var parameter in method.GetParameters())
				{
					Console.WriteLine("\tПараметр " + i + " " + parameter.Name + " " + parameter.ParameterType);
					i++;
				}
			}
		}

		public void PrintObjectInfo()
		{
			var className = this.GetType().FullName;
			Console.WriteLine("Класс " + className + " содержит следующие поля:");
			var fields = this.GetType().GetFields(BindingFlags.Instance |
					   BindingFlags.NonPublic |
					   BindingFlags.Public);
			foreach (var field in fields)
			{
				Console.WriteLine($"\t name = {field.Name}, type = {field.FieldType }, {(field.IsPublic ? " pulic" : " not public")}");
			}
			Console.WriteLine("Класс " + className + " содержит следующие методы:");
			foreach (var method in this.GetType().GetMethods(BindingFlags.Instance |
					   BindingFlags.NonPublic |
					   BindingFlags.Public))
			{
				Console.WriteLine("\t" + method.Name + (method.IsPublic ? " public" : " not public") + " возвращяющий " + method.ReturnType);
				var i = 1;
				foreach (var parameter in method.GetParameters())
				{
					Console.WriteLine("\tПараметр " + i + " " + parameter.Name + " " + parameter.ParameterType);
					i++;
				}
			}
		}
	}
}
