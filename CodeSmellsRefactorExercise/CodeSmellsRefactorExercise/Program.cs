using System.Diagnostics;

namespace CodeSmellsRefactorExercise
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var calculator = new Calculator();
			calculator.Run();
		}
	}

	public class Calculator
	{
		private List<int> numbers = new List<int>();

		public void Run()
		{

			AddInputs();
			int sum = GetSum();
			var average = GetAverage(sum);

			ReturnResult(sum, average);

			Console.WriteLine("Program finished.");
		}

		private List<int> AddInputs()
		{
			Console.WriteLine("Enter numbers separated by spaces:");
			var input = Console.ReadLine();

			if (string.IsNullOrEmpty(input))
			{
				throw new ArgumentException("No input provided.");
			}

			var numList = input.Split(' ');

			foreach (var n in numList)
			{
				numbers.Add(int.Parse(n));
			}

			return numbers;
		}

		public int GetSum()
		{
			var sum = 0;
			foreach (var number in numbers)
			{
				sum += number;
			}
			return sum;
		}

		public int GetAverage(int sum)
		{
			var average = sum / numbers.Count;
			return average;
		}

		public void ReturnResult(int sum, int average)
		{
			if (isValueValid(sum, average))
			{
				Console.WriteLine($"Sum: {sum}");
				Console.WriteLine($"Average: {average}");
			}
		}

		private bool isValueValid(int sum, int average)
		{
			return numbers.Count > 0 && sum > 0 && average > 0;
		}
	}
}

// Long Methods
//Inconsistent Naming
//Conditional Complexity
//Lack of Error Handling