namespace Day13;

public class Challenge1
{
	private static int MAXIMUM_BUTTON_PRESSES = 100;

	public int Solve(IEnumerable<PuzzleMachine> puzzleMachines)
	{
		return puzzleMachines
			.Select(FindMinimumCostToSolveMachine)
			.Sum(v => v ?? 0);
	}

	public int? FindMinimumCostToSolveMachine(PuzzleMachine puzzleMachine)
	{
		var buttonPresses = FindButtonPressesWithMinimumCostToSolveMachine(puzzleMachine);
		if (buttonPresses is null) return null;

		var buttonAPresses = buttonPresses.Value.ButtonAPresses;
		var buttonBPresses = buttonPresses.Value.ButtonBPresses;

		return buttonAPresses * PuzzleMachine.ButtonACost + buttonBPresses * PuzzleMachine.ButtonBCost;
	}

	public (int ButtonAPresses, int ButtonBPresses)? FindButtonPressesWithMinimumCostToSolveMachine(PuzzleMachine puzzleMachine)
	{
		var target = puzzleMachine.PrizeLocation;

		var aOffset = puzzleMachine.ButtonAOffset;
		var bOffset = puzzleMachine.ButtonBOffset;

		// Maximum possible number of presses of Button A
		// Either the largest number of divisions that goes into the target value
		// Or the maximum allowed number of presses
		var maximumAPresses = Math.Min(
			target.X / aOffset.X,
			target.Y / aOffset.Y
		);
		maximumAPresses = Math.Min(maximumAPresses, MAXIMUM_BUTTON_PRESSES);

		// Work up from the smallest number of presses of button A
		for (var aPresses = 0; aPresses <= maximumAPresses; aPresses++)
		{
			// Current coordinate from only the A presses
			var currentX = aPresses * aOffset.X;
			var currentY = aPresses * aOffset.Y;

			// Number of Button B presses required to get to the target coordinate
			var requiredButtonBPressesX = (int) ((target.X - currentX) / bOffset.X);
			var requiredButtonBPressesY = (int) ((target.Y - currentY) / bOffset.Y);

			// Greater than the allowed maximum
			if (requiredButtonBPressesX > MAXIMUM_BUTTON_PRESSES || requiredButtonBPressesY > MAXIMUM_BUTTON_PRESSES) continue;

			// Not the same multiple of presses for X and Y
			if (requiredButtonBPressesX != requiredButtonBPressesY) continue;

			// A and B offsets don't end up at the target location
			if ((target.X - currentX) % bOffset.X != 0 || (target.Y - currentY) % bOffset.Y != 0) continue;

			return (aPresses, requiredButtonBPressesX);
		}

		// Couldn't find a solution
		return null;
	}
}
