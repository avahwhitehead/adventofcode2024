namespace Day7;

public static class Utils
{
	public static IEnumerable<Equation> ParseEquations(string equations)
	{
		var lines = equations.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
		foreach (var line in lines)
		{
			var split = line.Split(':');
			var testValue = long.Parse(split[0]);

			var operators = split[1]
				.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
				.Select(int.Parse)
				.ToArray();

			var equation = new Equation(testValue, operators);
			yield return equation;
		}
	}
}

public class Equation
{
	public Equation(long test, int[] values)
	{
		TestValue = test;
		Values = values;
	}

	public long TestValue { get; }
	public int[] Values { get; }

	public override bool Equals(object obj)
	{
		return obj is Equation equation && TestValue == equation.TestValue && Values.SequenceEqual(equation.Values);
	}
}
