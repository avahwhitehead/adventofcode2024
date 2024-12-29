namespace Day10;

public class Challenge1
{
	protected int[][] Map;

	public Challenge1(int[][] map)
	{
		Map = map;
	}

	public int Solve()
	{
		var totalScore = 0;
		for (var rowIndex = 0; rowIndex < Map.Length; rowIndex++)
		{
			for (var columnIndex = 0; columnIndex < Map[rowIndex].Length; columnIndex++)
			{
				if (Map[rowIndex][columnIndex] != 0) continue;

				var trailScore = CalculateTrailScore(rowIndex, columnIndex);
				totalScore += trailScore;
			}
		}
		return totalScore;
	}

	public int CalculateTrailScore(int rowIndex, int columnIndex)
	{
		return FindTrailEnds(rowIndex, columnIndex).ToHashSet().Count;
	}

	public IEnumerable<Coord> FindTrailEnds(int rowIndex, int columnIndex)
	{
		var currentValue = GetValueAtPosition(rowIndex, columnIndex);
		// Invalid position in the map
		if (currentValue == null) yield break;

		// Reached a head of the trail
		if (currentValue == 9) yield return new Coord(rowIndex, columnIndex);

		var nextValue = currentValue.Value + 1;

		IEnumerable<Coord> trailEnds = [];
		if (GetValueAtPosition(rowIndex + 1, columnIndex) == nextValue)
		{
			trailEnds = trailEnds.Concat(FindTrailEnds(rowIndex + 1, columnIndex));
		}

		if (GetValueAtPosition(rowIndex - 1, columnIndex) == nextValue)
		{
			trailEnds = trailEnds.Concat(FindTrailEnds(rowIndex - 1, columnIndex));
		}

		if (GetValueAtPosition(rowIndex, columnIndex + 1) == nextValue)
		{
			trailEnds = trailEnds.Concat(FindTrailEnds(rowIndex, columnIndex + 1));
		}

		if (GetValueAtPosition(rowIndex, columnIndex - 1) == nextValue)
		{
			trailEnds = trailEnds.Concat(FindTrailEnds(rowIndex, columnIndex - 1));
		}

		foreach (var trailEnd in trailEnds)
		{
			yield return trailEnd;
		}
	}

	protected int? GetValueAtPosition(int rowIndex, int columnIndex)
	{
		if (rowIndex < 0 || rowIndex >= Map.Length) return null;
		if (columnIndex < 0 || columnIndex >= Map[rowIndex].Length) return null;

		return Map[rowIndex][columnIndex];
	}
}
