namespace Day8;

public class Challenge2(string[] grid) : Challenge1(grid)
{
	public override IEnumerable<Coord> GetAntiNodes(Coord antenna1, Coord antenna2)
	{
		// Get the horizontal and vertical differences between the points
		// Then reduce down to unit steps within the grid
		var fractionalDiff = new Fraction(
			antenna1.X - antenna2.X,
			antenna1.Y - antenna2.Y
		).Simplify();

		// Start from antenna1
		var point = antenna1.Clone();

		// Get a starting point at the edge of the grid
		while (IsValidCoordinate(point.X - fractionalDiff.Numerator, point.Y - fractionalDiff.Denominator))
		{
			point = new Coord(point.X - fractionalDiff.Numerator, point.Y - fractionalDiff.Denominator);
		}

		// Return this if it is not one of the antennas
		yield return point;

		// Return all the points in the grid that are exactly inline with the 2 antennas
		while (IsValidCoordinate(point.X + fractionalDiff.Numerator, point.Y + fractionalDiff.Denominator))
		{
			point = new Coord(point.X + fractionalDiff.Numerator, point.Y + fractionalDiff.Denominator);

			yield return point;
		}
	}
}

public class Fraction
{
	public int Numerator { get; set; }
	public int Denominator { get; set; }

	public Fraction(int numerator, int denominator)
	{
		Numerator = numerator;
		Denominator = denominator;
	}

	public Fraction Simplify()
	{
		var greatestCommonDivisor = GreatestCommonDivisor();

		var numerator = Numerator / greatestCommonDivisor;
		var denominator = Denominator / greatestCommonDivisor;

		return new Fraction(numerator, denominator);
	}

	public int GreatestCommonDivisor()
	{
		var a = Numerator;
		var b = Denominator;

		while (b != 0)
		{
			(a, b) = (b, a % b);
		}

		return a;
	}

	public override bool Equals(object? obj)
	{
		return obj is Fraction f && f.Numerator == Numerator && f.Denominator == Denominator;
	}
}
