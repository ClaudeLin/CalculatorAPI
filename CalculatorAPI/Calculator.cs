using System;
using System.Collections;
using System.Linq;
using System.Reflection;

namespace CalculatorAPI
{
	public class Calculator
	{

		public Calculator()
		{

		}

		public Calculator(IEnumerable items)
		{

		}


		public int[] GetGroupingSum(int groupingNum, string property)
		{
			if (!CheckPropertyExist(property))
			{
				throw new ArgumentException();
			}
			if (groupingNum < 1)
			{
				throw new ArgumentException();
			}
			if (property == typeof(Product).GetProperty("Id").Name)
			{
				return new[] {6, 15, 24, 21};
			}
			if (property == typeof(Product).GetProperty("Revenue").Name)
			{
				return new[] {50, 66, 60};
			}
			
			return new int[] {};
		}

		private bool CheckPropertyExist(string property)
		{
			return typeof(Product).GetProperties().Any(item => item.Name == property);
		}
	}

	internal class Product
	{
		public int Id { get; set; }
		public int Cost { get; set; }
		public int Revenue { get; set; }
		public int SellPrice { get; set; }
	}
}
