namespace Day7;

public class Challenge2: Challenge1
{
	public new long Solve(IEnumerable<Equation> equations)
	{
		return equations.Where(CanBeEvaluated).Select(e => e.TestValue).Sum();
	}

	protected override IEnumerable<Operation> GetOperations()
	{
		yield return Operation.Add;
		yield return Operation.Multiply;
		yield return Operation.Concatenate;
	}

	protected override long PerformOperation(Operation operation, long left, long right)
	{
		switch (operation)
		{
			case Operation.Add:
				return left + right;
			case Operation.Multiply:
				return left * right;
			case Operation.Concatenate:
				return long.Parse(left.ToString() + right.ToString());
			default:
				throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
		}
	}
}
