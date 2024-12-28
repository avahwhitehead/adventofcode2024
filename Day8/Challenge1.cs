namespace Day8;

public class Challenge1(string[] Grid)
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
					if (position1.Equals(position2)) continue;

					var antiNodes = GetAntiNodes(position1, position2);

					foreach (var antiNode in antiNodes)
					{
						if (IsValidCoordinate(antiNode)) antiNodesInGrid.Add(antiNode);
					}
				}
			}
		}

		return antiNodesInGrid.Count;
	}

	public IEnumerable<char> GetAntennaLabels()
	{
		var chars = Grid.SelectMany(row => row.ToCharArray()).ToHashSet();
		chars.Remove('.');
		chars.Remove('\n');
		return chars;
	}

	public IEnumerable<Coord> FindAntennaPositions(char antenna)
	{
		for (var rowIndex = 0; rowIndex < Grid.Length; rowIndex++)
		{
			for (var columnIndex = 0; columnIndex < Grid[rowIndex].Length; columnIndex++)
			{
				if (Grid[rowIndex][columnIndex] != antenna) continue;

				yield return new Coord(columnIndex, rowIndex);
			}
		}
	}

	public virtual IEnumerable<Coord> GetAntiNodes(Coord antenna1, Coord antenna2)
	{
		var distanceX = antenna1.X - antenna2.X;
		var distanceY = antenna1.Y - antenna2.Y;

		yield return new Coord(
			antenna1.X + distanceX,
			antenna1.Y + distanceY
		);

		yield return new Coord(
			antenna2.X - distanceX,
			antenna2.Y - distanceY
		);
	}

	public bool IsValidCoordinate(Coord coord) => IsValidCoordinate(coord.X, coord.Y);

	public bool IsValidCoordinate(int x, int y)
	{
		var gridHeight = Grid.Length;
		var gridWidth = Grid[0].Length;

		return x >= 0 && x < gridWidth && y >= 0 && y < gridHeight;
	}
}
