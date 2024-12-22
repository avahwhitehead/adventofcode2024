namespace Day4;

public class Challenge1
{
	public int Solve(string[] grid)
	{
		var count = grid.Sum(FindXmasHorizontally);

		count += GetVerticalLines(grid).Sum(FindXmasHorizontally);

		count += GetRightDiagonalLines(grid).Sum(FindXmasHorizontally);

		count += GetLeftDiagonalLines(grid).Sum(FindXmasHorizontally);

		return count;
	}

	public int FindXmasHorizontally(string line)
	{
		// ReSharper disable once InconsistentNaming
		const string XMAS = "XMAS";
		const string SAMX = "SAMX";

		var occurrences = 0;
		for (var i = 0; i <= line.Length - XMAS.Length; i++)
		{
			switch (line.Substring(i, XMAS.Length))
			{
				case XMAS:
				case SAMX:
					occurrences++;
					break;
			}
		}

		return occurrences;
	}

	public IEnumerable<string> GetVerticalLines(string[] grid)
	{
		for (var column = 0; column < grid.Length; column++)
		{
			var line = "";

			foreach (var row in grid)
			{
				line += row[column];
			}

			yield return line;
		}
	}

	public IEnumerable<string> GetRightDiagonalLines(string[] grid)
	{
		for (var columnIndex = grid[0].Length - 1; columnIndex >= 0; columnIndex--)
		{
			yield return GetRightDiagonal(grid, 0, columnIndex);
		}

		for (var rowIndex = 1; rowIndex < grid.Length; rowIndex++)
		{
			yield return GetRightDiagonal(grid, rowIndex, 0);
		}
	}

	private string GetRightDiagonal(string[] grid, int row, int column)
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

	public IEnumerable<string> GetLeftDiagonalLines(string[] grid)
	{
		grid = grid.Select(line => string.Join("", line.Reverse())).ToArray();

		return GetRightDiagonalLines(grid);
	}
}
