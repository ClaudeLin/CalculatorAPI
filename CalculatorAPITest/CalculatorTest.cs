using System;
using System.Collections.Generic;
using CalculatorAPI;
using ExpectedObjects;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorAPITest
{
	[TestClass]
	public class CalculatorTest
	{
		private List<Product> _productList = new List<Product>
		{
			new Product {Id = 1, Cost = 1, Revenue = 11, SellPrice = 21},
			new Product {Id = 2, Cost = 2, Revenue = 12, SellPrice = 22},
			new Product {Id = 3, Cost = 3, Revenue = 13, SellPrice = 23},
			new Product {Id = 4, Cost = 4, Revenue = 14, SellPrice = 24},
			new Product {Id = 5, Cost = 5, Revenue = 15, SellPrice = 25},
			new Product {Id = 6, Cost = 6, Revenue = 16, SellPrice = 26},
			new Product {Id = 7, Cost = 7, Revenue = 17, SellPrice = 27},
			new Product {Id = 8, Cost = 8, Revenue = 18, SellPrice = 28},
			new Product {Id = 9, Cost = 9, Revenue = 19, SellPrice = 29},
			new Product {Id = 10, Cost = 10, Revenue = 20, SellPrice = 30},
			new Product {Id = 11, Cost = 11, Revenue = 21, SellPrice = 31}
		};

		private Calculator target;

		[TestInitialize]
		public void TestInit()
		{
			target = new Calculator(_productList);
		}

		[TestMethod]
		public void GetSum_When_Grouping_Is_3_Property_Is_Cost()
		{
			var expected = new[] { 6, 15, 24, 21 };
			var groupingNum = 3;
			var property = typeof(Product).GetProperty("Id").Name;

			var actual = target.GetGroupingSum(groupingNum, property);

			expected.ToExpectedObject().ShouldEqual(actual);
		}

		[TestMethod]
		public void GetSum_When_Grouping_Is_4_Property_Is_Revenue()
		{
			var expected = new[] { 50, 66, 60 };
			var groupingNum = 4;
			var property = typeof(Product).GetProperty("Revenue").Name;

			var actual = target.GetGroupingSum(groupingNum, property);

			expected.ToExpectedObject().ShouldEqual(actual);
		}

		[TestMethod]
		public void GetArgumentException_When_Grouping_Is_NegativeNumber()
		{
			var groupingNum = -1;
			var property = "Id";

			Action action = () => target.GetGroupingSum(groupingNum, property);

			action.ShouldThrow<ArgumentException>();
		}

		[TestMethod]
		public void GetArgumentException_When_Property_NonExist()
		{
			var groupingNum = 2;
			var property = "NonExistProperty";

			Action action = () => target.GetGroupingSum(groupingNum, property);

			action.ShouldThrow<ArgumentException>();
		}

		[TestMethod]
		public void GetArgumentException_When_Grouping_Is_Zero()
		{
			var groupingNum = 0;
			var property = "Id";

			Action action = () => target.GetGroupingSum(groupingNum, property);

			action.ShouldThrow<ArgumentException>();
		}
	}


}
