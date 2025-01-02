namespace Day13;

public class Challenge2
{
	/*
	 * This solution works through simultaneous equations.
	 * Given the vectors A, B, and T (the 2 buttons and the target coordinate respectively),
	 * we need to find values for K and L, such that KA + LB = T.
	 *
	 * (The following uses the notation Ax and Ay to mean the X and Y components of the A vector respectively)
	 *
	 * We can split this up into 2 equations:
	 *	KAx + LBx = Tx
	 *	KAy + LBy = Ty
	 *
	 * Which can then be rearranged as follows:
	 *	K = (Ty - LBy) / Ay
	 *	L = (Tx - KAx) / Bx
	 *
	 * Substituting L into the equation for K gives us this:
	 *	K = By(Ty - [Tx - KAx]/Bx) / Ay
	 *	KAyBx = TyBx - By(Tx-KAx)
	 *	KAyBx = TyBx - ByTx + KByAx
	 *	K(AyBx - ByAx) = TyBx - ByTx
	 *
	 * And finally that gives us:
	 *	K = (TyBx - ByTx) / (AyBx - ByAx)
	 *
	 * Then, whatever value for K we receive can be put into the equation for L.
	 *
	 * This calculates the values in constant time (O(1))
	 */

	public long Solve(IEnumerable<PuzzleMachine> puzzleMachines)
	{
		return puzzleMachines
			.Select(FindMinimumCostToSolveMachine)
			.Sum(v => v ?? 0);
	}

	public long? FindMinimumCostToSolveMachine(PuzzleMachine puzzleMachine)
	{
		var buttonPresses = FindButtonPressesWithMinimumCostToSolveMachine(puzzleMachine);
		if (buttonPresses is null) return null;

		var buttonAPresses = buttonPresses.Value.ButtonAPresses;
		var buttonBPresses = buttonPresses.Value.ButtonBPresses;

		return buttonAPresses * PuzzleMachine.ButtonACost + buttonBPresses * PuzzleMachine.ButtonBCost;
	}

	public (long ButtonAPresses, long ButtonBPresses)? FindButtonPressesWithMinimumCostToSolveMachine(PuzzleMachine puzzleMachine)
	{
		var target = puzzleMachine.PrizeLocation;

		var aOffset = puzzleMachine.ButtonAOffset;
		var bOffset = puzzleMachine.ButtonBOffset;

		var multipleOfA = CalculateMultipleOfA(aOffset, bOffset, target);
		if (multipleOfA is null) return null;

		var multipleOfB = CalculateMultipleOfB(aOffset, bOffset, target, multipleOfA.Value);
		if (multipleOfB is null) return null;

		return (multipleOfA.Value, multipleOfB.Value);
	}

	private long? CalculateMultipleOfA(Coord aOffset, Coord bOffset, Coord target)
	{
		var numerator = (target.Y * bOffset.X - target.X * bOffset.Y);
		var denominator = (aOffset.Y * bOffset.X - aOffset.X * bOffset.Y);

		if (numerator % denominator != 0) return null;
		return numerator / denominator;
	}

	private long? CalculateMultipleOfB(Coord aOffset, Coord bOffset, Coord target, long multipleOfB)
	{
		var numerator = (target.X - multipleOfB * aOffset.X);
		var denominator = bOffset.X;

		if (numerator % denominator != 0) return null;
		return numerator / denominator;
	}
}
