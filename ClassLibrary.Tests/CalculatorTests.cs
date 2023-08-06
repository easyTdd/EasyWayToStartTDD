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

		[Test]
		public void ThrowsExceptionWhenExpressionIsNull()
		{
			_expression = null;

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