namespace Day12;

public class Challenge1
{
	private readonly char[][] Map;

	public Challenge1(string[] map)
	{
		Map = map.Select(s => s.ToCharArray()).ToArray();
	}

	public virtual int Solve()
	{
		return GetRegions()
			.Select(r => r.GetArea() * r.GetPerimeterLength())
			.Sum();
	}

	public IEnumerable<Region> GetRegions()
	{
		var regions = new List<Region>();
		var completedCoords = new HashSet<Coord>();

		for (var rowIndex = 0; rowIndex < Map.Length; rowIndex++)
		{
			for (var columnIndex = 0; columnIndex < Map[rowIndex].Length; columnIndex++)
			{
				if (completedCoords.Contains(new Coord(rowIndex, columnIndex))) continue;

				var region = FindRegion(Map[rowIndex][columnIndex], rowIndex, columnIndex);
				regions.Add(region);

				foreach (var coord in region.GetCoords())
				{
					completedCoords.Add(coord);
				}
			}
		}

		return regions;
	}

	private Region FindRegion(char regionType, int startRowIndex, int startColumnIndex)
	{
		var regionPoints = new HashSet<Coord>();
		var toExplore = new Queue<Coord>();
		toExplore.Enqueue(new Coord(startRowIndex, startColumnIndex));

		while (toExplore.Count > 0)
		{
			var coord = toExplore.Dequeue();
			var rowIndex = coord.X;
			var columnIndex = coord.Y;

			// Current value is not part of the region
			if (Map[rowIndex][columnIndex] != regionType) continue;
			// Add to the region points
			// Or continue to the next point if it is already added
			if (!regionPoints.Add(coord)) continue;

			// Above
			if (rowIndex > 0)
			{
				toExplore.Enqueue(new Coord(rowIndex - 1, columnIndex));
			}

			// Below
			if (rowIndex < Map.Length - 1)
			{
				toExplore.Enqueue(new Coord(rowIndex + 1, columnIndex));
			}

			// Left
			if (columnIndex > 0)
			{
				toExplore.Enqueue(new Coord(rowIndex, columnIndex - 1));
			}

			// Right
			if (columnIndex < Map[rowIndex].Length - 1)
			{
				toExplore.Enqueue(new Coord(rowIndex, columnIndex + 1));
			}
		}

		var regionMap = Map.Select(
			(row, rowI) => row.Select(
				(point, colI) => point == regionType && regionPoints.Contains(new Coord(rowI, colI))
			).ToArray()
		).ToArray();

		return new Region(regionMap);
	}
}
