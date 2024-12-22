namespace Day2;

public class Challenge2
{
	public int Solve(int[][] reports)
	{
		var validReportCount = 0;

		foreach (var report in reports)
		{
			// See if the report is valid
			var (success, errorIndex) = TestReport(report);
			if (success)
			{
				validReportCount += 1;
				continue;
			}

			// Try removing the value at which the error appeared
			var modifiedReport = RemoveFrom(report, errorIndex!.Value);
			if (TestReport(modifiedReport).IsValid)
			{
				validReportCount += 1;
				continue;
			}

			// Try removing the value before the error appeared
			modifiedReport = RemoveFrom(report, errorIndex!.Value - 1);
			if (TestReport(modifiedReport).IsValid)
			{
				validReportCount += 1;
				continue;
			}
		}

		return validReportCount;
	}

	private (bool IsValid, int? ErrorIndex) TestReport(int[] report)
	{
		var previousValue = report[0];
		bool? isReportIncreasing = null;

		for (var i = 1; i < report.Length; i++)
		{
			var currentValue = report[i];

			var valuesDifference = currentValue - previousValue;
			// Check for diff by at least 1
			if (valuesDifference == 0) return (false, i);

			isReportIncreasing ??= valuesDifference > 0;
			// Check for monotonic increase/decrease
			if (isReportIncreasing != valuesDifference > 0) return (false, i);
			// Check for diff at most 3
			if (Math.Abs(valuesDifference) > 3) return (false, i);

			// Increment for next iteration
			previousValue = currentValue;
		}

		return (true, null);
	}


	private T[] RemoveFrom<T>(T[] array, int index)
	{
		var list = new List<T>(array);
		list.RemoveAt(index);
		return list.ToArray();
	}
}
