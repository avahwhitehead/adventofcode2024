namespace Day6;

public class Challenge1
{
	public int Solve(Grid grid)
	{
		var previousPositions = new HashSet<(int X, int Y)>();

		while (grid.ContainsGuard())
		{
			previousPositions.Add(grid.GuardPosition!.Value);
			grid.Step();
		}

		return previousPositions.Count;
	}
}
