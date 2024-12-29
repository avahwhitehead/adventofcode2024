namespace Day11;

public class Challenge1
{
	public List<long> Stones { get; private set;  }

	public Challenge1(IEnumerable<long> initialStones)
	{
		Stones = initialStones.ToList();
	}

	public int Solve()
	{
		for (long i = 0; i < 25; i++)
		{
			StepStones();
		}
		return Stones.Count;
	}

	public void StepStones()
	{
		Stones = Stones.SelectMany(StepStone).ToList();
	}

	protected virtual IEnumerable<long> StepStone(long currentValue)
	{
		if (currentValue == 0)
		{
			yield return 1;
			yield break;
		}

		if (Utils.DoesNumberHaveEvenNumberOfDigits(currentValue))
		{
			yield return Utils.GetLeftHalfOfNumber(currentValue);
			yield return Utils.GetRightHalfOfNumber(currentValue);
			yield break;
		}

		yield return currentValue * 2024;
	}
}
