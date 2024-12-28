namespace Day8;

public class Challenge1(string[] grid)
{
	public long Solve()
	{
		var antennas = GetAntennaLabels();

		var antiNodesInGrid = new HashSet<Coord>();

		foreach (var antenna in antennas)
		{
			var positions = FindAntennaPositions(antenna).ToList();

			foreach (var position1 in positions)
			{
				foreach (var position2 in positions)
				{
					if (Equals(position1, position2)) continue;

					var (an1, an2) = GetAntiNodes(position1, position2);

					if (IsValidCoordinate(an1)) antiNodesInGrid.Add(an1);
					if (IsValidCoordinate(an2)) antiNodesInGrid.Add(an2);
				}
			}
		}

		return antiNodesInGrid.Count;
	}

	public IEnumerable<char> GetAntennaLabels()
	{
		var chars = grid.SelectMany(row => row.ToCharArray()).ToHashSet();
		chars.Remove('.');
		chars.Remove('\n');
		return chars;
	}

	public IEnumerable<Coord> FindAntennaPositions(char antenna)
	{
		for (var rowIndex = 0; rowIndex < grid.Length; rowIndex++)
		{
			for (var columnIndex = 0; columnIndex < grid[rowIndex].Length; columnIndex++)
			{
				if (grid[rowIndex][columnIndex] != antenna) continue;

				yield return new Coord(columnIndex, rowIndex);
			}
		}
	}

	public (Coord, Coord) GetAntiNodes(Coord antenna1, Coord antenna2)
	{
		var distanceX = antenna1.X - antenna2.X;
		var distanceY = antenna1.Y - antenna2.Y;

		var coord1 = new Coord(
			antenna1.X + distanceX,
			antenna1.Y + distanceY
		);
		var coord2 = new Coord(
			antenna2.X - distanceX,
			antenna2.Y - distanceY
		);

		return (coord1, coord2);
	}

	public bool IsValidCoordinate(Coord coord)
	{
		var gridHeight = grid.Length;
		var gridWidth = grid[0].Length;

		return coord.X >= 0 && coord.X < gridWidth && coord.Y >= 0 && coord.Y < gridHeight;
	}
}
