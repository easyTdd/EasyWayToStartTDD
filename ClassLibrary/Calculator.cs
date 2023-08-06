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

			var regex = new Regex(@"^\d+(\.\d+)?$");

			if (!regex.IsMatch(expression))
			{
				throw new ArgumentException($"'{expression}' is not valid expression.");
			}

			return double.Parse(expression, CultureInfo.InvariantCulture);
		}
	}
}