namespace Day4;

public class Challenge2
{
	public int Solve(string[] grid)
	{
		const int wordLength = 3;

		var count = 0;

		for (var rowIndex = 0; rowIndex <= grid.Length - wordLength; rowIndex++)
		{
			for (var columnIndex = 0; columnIndex <= grid[0].Length - wordLength; columnIndex++)
			{
				var subGrid = GetSubGrid(grid, rowIndex, columnIndex, wordLength);

				var rightDiagonal = GetRightDiagonal(subGrid, 0, 0);
				if (rightDiagonal is not ("MAS" or "SAM")) continue;

				var leftDiagonal = GetLeftDiagonal(subGrid, 0, wordLength - 1);
				if (leftDiagonal is not ("MAS" or "SAM")) continue;

				count++;
			}
		}

		return count;
	}

	public string[] GetSubGrid(string[] grid, int startRow, int startColumn, int size)
	{
		string[] subGrid = new string[size];

		for (var rowOffset = 0; rowOffset < size; rowOffset++)
		{
			subGrid[rowOffset] = "";
			for (var colOffset = 0; colOffset < size; colOffset++)
			{
				subGrid[rowOffset] += grid[startRow + rowOffset][startColumn + colOffset];
			}
		}

		return subGrid;
	}

	public string GetRightDiagonal(string[] grid, int row, int column)
	{
		var line = "";
		for (var offset = 0; offset < grid.Length; offset++)
		{
			if (grid.Length <= row + offset) break;
			if (grid[row + offset].Length <= column + offset) break;

			line += grid[row + offset][column + offset];
		}
		return line;
	}

	public string GetLeftDiagonal(string[] grid, int row, int column)
	{
		grid = grid.Select(line => string.Join("", line.Reverse())).ToArray();

		return GetRightDiagonal(grid, row, grid.Length - 1 - column);
	}
}
