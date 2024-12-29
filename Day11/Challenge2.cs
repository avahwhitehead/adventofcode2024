namespace Day11;

public class Challenge2
{
	public long StonesCount => _stoneValueMap.Values.Aggregate((a, b) => a + b);

	private Dictionary<long, long> _stoneValueMap;

	public Challenge2(long[] initialStones)
	{
		_stoneValueMap = new Dictionary<long, long>(int.MaxValue >> 2);

		foreach (var stone in initialStones)
		{
			if (!_stoneValueMap.TryAdd(stone, 1))
			{
				_stoneValueMap[stone]++;
			}
		}
	}

	public long Solve()
	{
		for (long i = 0; i < 25; i++)
		{
			StepStones();
		}
		return StonesCount;
	}

	public void StepStones()
	{
		long zeroStonesCount = 0;
		_stoneValueMap = _stoneValueMap.SelectMany<KeyValuePair<long, long>, (long, long)>(pair =>
		{
			var stoneValue = pair.Key;
			var stonesCount = pair.Value;

			if (stoneValue == 0)
			{
				return [(1L, stonesCount)];
			}

			var numberOfDigitsInCurrentValue = Utils.GetNumberOfDigits(stoneValue);
			if (numberOfDigitsInCurrentValue % 2 == 0)
			{
				var (leftHalfOfNumber, rightHalfOfNumber) = Utils.GetHalvesOfNumber(stoneValue, numberOfDigitsInCurrentValue);

				if (rightHalfOfNumber == 0)
				{
					zeroStonesCount += stonesCount;
					return [(leftHalfOfNumber, stonesCount)];
				}

				return [(rightHalfOfNumber, stonesCount), (leftHalfOfNumber, stonesCount)];
			}

			return [(stoneValue * 2024L, stonesCount)];
		})
			.GroupBy(tuple => tuple.Item1)
			.ToDictionary(
				result => result.First().Item1,
				result => result.Sum(t => t.Item2)
			);

		_stoneValueMap.Add(0, zeroStonesCount);
	}
}
