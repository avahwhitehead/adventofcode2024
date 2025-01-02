using System.Text.RegularExpressions;

namespace Day13;

public static partial class Utils
{
	public static PuzzleMachine[] ParseInput(string input)
	{
		var lines = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);

		List<PuzzleMachine> machineList = [];

		Coord? buttonA = null;
		Coord? buttonB = null;
		foreach (var line in lines)
		{
			if (line.StartsWith("Button A"))
			{
				var match = ButtonCoordinateRegex().Match(line);
				buttonA = new Coord(
					int.Parse(match.Groups[1].Value),
					int.Parse(match.Groups[2].Value)
				);
			}
			else if (line.StartsWith("Button B"))
			{
				var match = ButtonCoordinateRegex().Match(line);
				buttonB = new Coord(
					int.Parse(match.Groups[1].Value),
					int.Parse(match.Groups[2].Value)
				);
			}
			else if (line.StartsWith("Prize"))
			{
				var match = PrizeLocationCoordinateRegex().Match(line);
				var prizeLocation = new Coord(
					int.Parse(match.Groups[1].Value),
					int.Parse(match.Groups[2].Value)
				);

				if (buttonA is null) throw new FormatException("Button A was not provided before the prize location");
				if (buttonB is null) throw new FormatException("Button B was not provided before the prize location");

				machineList.Add(new PuzzleMachine(buttonA, buttonB, prizeLocation));
			}
		}

		return machineList.ToArray();
	}

	public static int GreatestCommonFactor(int a, int b)
	{
		while (b != 0)
		{
			(a, b) = (b, a % b);
		}
		return a;
	}

	public static int LowestCommonMultiple(int a, int b)
	{
		return (a / GreatestCommonFactor(a, b)) * b;
	}


	[GeneratedRegex(@"X\+(\d+), Y\+(\d+)")]
	private static partial Regex ButtonCoordinateRegex();

	[GeneratedRegex(@"X=(\d+), Y=(\d+)")]
	private static partial Regex PrizeLocationCoordinateRegex();
}

public class PuzzleMachine
{
	public Coord ButtonAOffset { get; init; }
	public Coord ButtonBOffset { get; init; }
	public Coord PrizeLocation { get; init; }

	public const int ButtonACost = 3;
	public const int ButtonBCost = 1;

	public PuzzleMachine(Coord buttonAOffset, Coord buttonBOffset, Coord prizeLocation)
	{
		ButtonAOffset = buttonAOffset;
		ButtonBOffset = buttonBOffset;
		PrizeLocation = prizeLocation;
	}

	public override bool Equals(object? obj)
	{
		return obj is PuzzleMachine puzzleMachine
			&& puzzleMachine.ButtonAOffset.Equals(ButtonAOffset)
			&& puzzleMachine.ButtonBOffset.Equals(ButtonBOffset)
			&& puzzleMachine.PrizeLocation.Equals(PrizeLocation);
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(ButtonAOffset, ButtonBOffset, PrizeLocation);
	}
}
