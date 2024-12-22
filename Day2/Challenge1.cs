namespace Day2;

public class Challenge1
{
	public int Solve(int[][] reports)
	{
		return reports.Select(TestReport).Sum(b => b ? 1 : 0);
	}

	private bool TestReport(int[] report)
	{
		var previousValue = report[0];
		bool? isReportIncreasing = null;

		for (var i = 1; i < report.Length; i++)
		{
			var currentValue = report[i];

			var valuesDifference = currentValue - previousValue;
			// Check for diff by at least 1
			if (valuesDifference == 0) return false;

			isReportIncreasing ??= valuesDifference > 0;
			// Check for monotonic increase/decrease
			if (isReportIncreasing != valuesDifference > 0) return false;
			// Check for diff at most 3
			if (Math.Abs(valuesDifference) > 3) return false;

			// Increment for next iteration
			previousValue = currentValue;
		}

		return true;
	}
}
