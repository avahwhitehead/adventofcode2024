namespace Day1;

public class Challenge2
{
	public int Solve(int[] listA, int[] listB)
	{
		var occurenceMap = new Dictionary<int, int>();

		foreach (var val in listB)
		{
			if (!occurenceMap.TryAdd(val, 1))
			{
				occurenceMap[val]++;
			}
		}

		foreach (var v in listA)
		{
			occurenceMap.TryAdd(v, 0);
		}

		return listA.Select(val => val * occurenceMap[val]).Sum();
	}
}
