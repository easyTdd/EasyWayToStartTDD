namespace ClassLibrary
{
	public class Calculator
	{
		public decimal Calculate(string expression)
		{
			if (string.IsNullOrWhiteSpace(expression))
			{
				throw new ArgumentNullException(nameof(expression));
			}

			throw new NotImplementedException();
		}
	}
}