using ClassLibrary;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace ClassLibrary.Tests
{
	public class CalculatorTests
	{
		private string _expression;

		[SetUp]
		public void Setup()
		{
			_expression = string.Empty;
		}

		[TestCase(null)]
		[TestCase("")]
		[TestCase("  ")]
		[TestCase("a")]
		[TestCase("aabb")]
		[TestCase("=")]
		[TestCase("+")]
		[TestCase("-")]
		[TestCase("35.21a")]
		[TestCase("a123")]
		public void ThrowsExceptionWhenExpressionIsInvalid(string expression)
		{
			_expression = expression;

			Action action = () => CallCalculate();

			action
				.Should()
				.Throw<ArgumentException>();
		}

		[TestCase("3", 3)]
		[TestCase("3.5", 3.5)]
		[TestCase("2+2", 4)]
		[TestCase("2.5+2", 4.5)]
		[TestCase("2.5+2.8", 5.3)]
		[TestCase("2.5-2", 0.5)]
		[TestCase("2.5-2.8", -0.3)]
		[TestCase("10+20-5.5+8-3+2.8", 32.3)]
		public void ReturnsExpectedCalculatedExpression(string expression, double expectedResult)
		{
			_expression = expression;

			var result = CallCalculate();

			result
				.Should()
				.BeApproximately(expectedResult, 0.001);
		}

		private double CallCalculate()
		{
			var sut = Create();

			return sut
				.Calculate(
					_expression
				);
		}

		private Calculator Create()
		{
			return new Calculator();
		}
	}
}