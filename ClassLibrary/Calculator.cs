namespace ClassLibrary
{
	public class Calculator
	{
		public decimal Calculate(string expression)
		{
			if (expression == null)
			{
				throw new ArgumentNullException(nameof(expression));
			}

			throw new NotImplementedException();
		}
	}
}