namespace Day6;

public class Challenge2
{
	public int Solve(Grid grid)
	{
		var height = grid.GridArray.Length;
		var width = grid.GridArray[0].Length;

		var loopCount = 0;
		for (var rowIndex = 0; rowIndex < height; rowIndex++)
		{
			for (var columnIndex = 0; columnIndex < width; columnIndex++)
			{
				if (grid.GetSquare(columnIndex, rowIndex) != null) continue;

				var newGrid = grid.Clone();

				newGrid.SetSquare(columnIndex, rowIndex, Grid.SquareContent.Obstacle);

				if (newGrid.WillGuardLoop(10000))
				{
					loopCount++;
				}
			}
		}

		return loopCount;
	}
}
