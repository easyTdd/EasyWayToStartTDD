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
		public void ThrowsExceptionWhenExpressionIsNull(string expression)
		{
			_expression = expression;

			Action action = () => CallCalculate();

			action
				.Should()
				.Throw<ArgumentException>();
		}

		private decimal CallCalculate()
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