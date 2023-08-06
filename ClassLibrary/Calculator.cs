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

			throw new NotImplementedException();
		}
	}
}