namespace Day10;

public class Challenge2: Challenge1
{
	private int[][] Map;

	public Challenge2(int[][] map): base(map)
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

				var trailScore = CalculateTrailRating(rowIndex, columnIndex);
				totalScore += trailScore;
			}
		}
		return totalScore;
	}

	public int CalculateTrailRating(int rowIndex, int columnIndex)
	{
		return FindTrailEnds(rowIndex, columnIndex).Count();
	}
}
