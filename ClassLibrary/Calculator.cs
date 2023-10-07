using System.Globalization;
using System.Text.RegularExpressions;

namespace ClassLibrary
{
	public class Calculator
	{
		public double Calculate(string expression)
		{
			if (string.IsNullOrWhiteSpace(expression))
			{
				throw new ArgumentNullException(nameof(expression));
			}

			var regex = new Regex(@"^\d+(\.\d+)?((\+|\-)\d+(\.\d+)?)*$");

			if (!regex.IsMatch(expression))
			{
				throw new ArgumentException($"'{expression}' is not valid expression.");
			}

			var tokens = Regex.Matches(expression, @"(\d+(\.\d+)?)|(\+|\-)");

			if (tokens.Count == 1)
			{
				return ParseDouble(tokens[0]);
			}

			var result = ParseDouble(tokens[0]);

			for (var i = 1; i < tokens.Count - 1; i += 2)
			{
				if (tokens[i].Value == "+")
				{
					result += ParseDouble(tokens[i + 1]);
				}
				else
				{
					result -= ParseDouble(tokens[i + 1]);
				}
			}

			return result;
		}

		private double ParseDouble(Match token)
		{
			return double.Parse(
				token.Value, 
				CultureInfo.InvariantCulture
			);
		}
	}
}