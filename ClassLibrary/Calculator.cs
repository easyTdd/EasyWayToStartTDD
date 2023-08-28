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
				return double.Parse(tokens[0].Value, CultureInfo.InvariantCulture);
			}

			var result = double.Parse(tokens[0].Value, CultureInfo.InvariantCulture);

			for (var i = 1; i < tokens.Count - 1; i++)
			{
				if (tokens[i].Value == "+")
				{
					result += double.Parse(tokens[i + 1].Value, CultureInfo.InvariantCulture);
				}
				else
				{
					result -= double.Parse(tokens[i + 1].Value, CultureInfo.InvariantCulture);
				}
			}

			return result;
		}
	}
}