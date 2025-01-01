namespace Day12;

public class Region
{
	private readonly bool[][] _regionMap;

	public Region(bool[][] regionMapMap)
	{
		if (!IsRegionContiguous(regionMapMap))
		{
			throw new ArgumentException("Region is not contiguous");
		}

		_regionMap = regionMapMap;
	}

	public int GetPerimeterLength()
	{
		var perimeterLength = 0;
		for (var rowIndex = 0; rowIndex < _regionMap.Length; rowIndex++)
		{
			for (var columnIndex = 0; columnIndex < _regionMap[rowIndex].Length; columnIndex++)
			{
				// Not part of the region - skip this
				if (!_regionMap[rowIndex][columnIndex]) continue;

				var borders = 4;

				// Above
				if (rowIndex > 0 && _regionMap[rowIndex - 1][columnIndex]) borders--;

				// Below
				if (rowIndex < _regionMap.Length - 1 && _regionMap[rowIndex + 1][columnIndex]) borders--;

				// Above
				if (columnIndex > 0 && _regionMap[rowIndex][columnIndex - 1]) borders--;

				// Below
				if (columnIndex < _regionMap[rowIndex].Length - 1 && _regionMap[rowIndex][columnIndex + 1]) borders--;

				perimeterLength += borders;
			}
		}
		return perimeterLength;
	}

	public int GetArea()
	{
		return _regionMap
			.SelectMany(r => r.Where(v => v))
			.Count();
	}

	public int GetNumberOfSides()
	{
		if (_regionMap.Length == 0) return 0;

		var horizontalSides = FindHorizontalSides();
		var verticalSides = FindVerticalSides();
		return horizontalSides + verticalSides;
	}

	private int FindHorizontalSides()
	{
		var sidesCount = 0;
		// Count the number of horizontal sides (above/below)
		for (var rowIndex = 0; rowIndex < _regionMap.Length; rowIndex++)
		{
			var sideAbove = false;
			var sideBelow = false;
			for (var columnIndex = 0; columnIndex < _regionMap[rowIndex].Length; columnIndex++)
			{
				// Not part of the region - reset the sides and skip this
				if (!_regionMap[rowIndex][columnIndex])
				{
					sideAbove = false;
					sideBelow = false;
					continue;
				}

				// Above
				if (rowIndex == 0 || !_regionMap[rowIndex - 1][columnIndex])
				{
					// There is a side above this point
					if (!sideAbove) sidesCount++;
					sideAbove = true;
				}
				else if (rowIndex > 0 && _regionMap[rowIndex - 1][columnIndex])
				{
					// There was a side above the previous point, but not this one
					sideAbove = false;
				}

				// Below
				if (rowIndex == _regionMap.Length - 1 || !_regionMap[rowIndex + 1][columnIndex])
				{
					// There is a side below this point
					if (!sideBelow) sidesCount++;
					sideBelow = true;
				}
				else if (rowIndex < _regionMap.Length - 1 && _regionMap[rowIndex + 1][columnIndex])
				{
					// There was a side below the previous point, but not this one
					sideBelow = false;
				}
			}
		}
		return sidesCount;
	}

	private int FindVerticalSides()
	{
		var sidesCount = 0;
		// Count the number of vertical sides (left/right)
		for (var columnIndex = 0; columnIndex < _regionMap[0].Length; columnIndex++)
		{
			var sideLeft = false;
			var sideRight = false;
			foreach (var row in _regionMap)
			{
				// Not part of the region - reset the sides and skip this
				if (!row[columnIndex])
				{
					sideLeft = false;
					sideRight = false;
					continue;
				}

				// Left
				if (columnIndex == 0 || !row[columnIndex - 1])
				{
					// There is a side to the left of this point
					if (!sideLeft) sidesCount++;
					sideLeft = true;
				}
				else if (columnIndex > 0 && row[columnIndex - 1])
				{
					// There was a side to the left of the previous point
					sideLeft = false;
				}

				// Right
				if (columnIndex == row.Length - 1 || !row[columnIndex + 1])
				{
					// There is a side to the right of this point
					if (!sideRight) sidesCount++;
					sideRight = true;
				}
				else if (columnIndex < row.Length - 1 && row[columnIndex + 1])
				{
					// There was a side to the right of the previous point
					sideRight = false;
				}
			}
		}
		return sidesCount;
	}

	public IEnumerable<Coord> GetCoords()
	{
		return GetCoords(_regionMap);
	}

	private static IEnumerable<Coord> GetCoords(bool[][] regionMap)
	{
		return regionMap
			.SelectMany((row, rowIndex) =>
				row.Select(
					(value, columnIndex) => value ? new Coord(rowIndex, columnIndex) : null
				)
			)
			.Where(v => v is not null)
			.Cast<Coord>()
			.ToHashSet();
	}

	public static bool IsRegionContiguous(bool[][] regionMap)
	{
		// Find the set of non-empty coordinates
		var regionPoints = GetCoords(regionMap).ToHashSet();

		// Allow empty regions
		if (regionPoints.Count == 0) return true;

		// Get one of the points in the region
		var point = regionPoints.First();

		// Build the contiguous region containing that point
		var contiguousRegion = FindContiguousRegion(regionMap, point.X, point.Y);

		// Check that the contiguous region contains all the region points
		// And only the region points
		return
			regionPoints.Count == contiguousRegion.Count
			&& regionPoints.All(p => contiguousRegion.Contains(p))
			&& contiguousRegion.All(p => regionPoints.Contains(p))
		;
	}

	private static HashSet<Coord> FindContiguousRegion(bool[][] regionMap, int startRowIndex, int startColumnIndex)
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
			if (!regionMap[rowIndex][columnIndex]) continue;

			// Add to the region points
			// Or continue to the next point if it is already added
			if (!regionPoints.Add(coord)) continue;

			// Above
			if (rowIndex > 0)
			{
				toExplore.Enqueue(new Coord(rowIndex - 1, columnIndex));
			}

			// Below
			if (rowIndex < regionMap.Length - 1)
			{
				toExplore.Enqueue(new Coord(rowIndex + 1, columnIndex));
			}

			// Left
			if (columnIndex > 0)
			{
				toExplore.Enqueue(new Coord(rowIndex, columnIndex - 1));
			}

			// Right
			if (columnIndex < regionMap[rowIndex].Length - 1)
			{
				toExplore.Enqueue(new Coord(rowIndex, columnIndex + 1));
			}
		}

		return regionPoints;
	}
}
