namespace Day7;

public class Challenge1
{
	public long Solve(IEnumerable<Equation> equations)
	{
		return equations.Where(CanBeEvaluated).Select(e => (long)e.TestValue).Sum();
	}

	public bool CanBeEvaluated(Equation equation)
	{
		return Evaluate(equation.Values.ToList())
			.Any(result => result == equation.TestValue);
	}

	public IEnumerable<long> Evaluate(List<int> values)
	{
		if (values.Count == 0)
		{
			throw new InvalidOperationException("Nothing to evaluate");
		}

		return Evaluate(values.First(), values.Skip(1).ToList());
	}

	private IEnumerable<long> Evaluate(long previous, List<int> values)
	{
		// End of list - return here
		if (!values.Any())
		{
			yield return previous;
			yield break;
		}

		var nextValue = values.First();

		foreach (var operation in GetOperations())
		{
			var res = PerformOperation(operation, previous, nextValue);

			foreach (var i in Evaluate(res, values.Skip(1).ToList()))
			{
				yield return i;
			}
		}
	}

	private long PerformOperation(Operation operation, long left, long right)
	{
		switch (operation)
		{
			case Operation.Add:
				return left + right;
			case Operation.Multiply:
				return left * right;
			default:
				throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
		}
	}

	private IEnumerable<Operation> GetOperations()
	{
		yield return Operation.Add;
		yield return Operation.Multiply;
	}
}

public enum Operation
{
	Add,
	Multiply,
}
