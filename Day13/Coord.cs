namespace Day13;

public class Coord(long x, long y)
{
	public long X { get; set; } = x;
	public long Y { get; set; } = y;

	public override bool Equals(object? obj)
	{
		return obj is Coord coord && Equals(coord);
	}

	protected bool Equals(Coord other)
	{
		return X == other.X && Y == other.Y;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(X, Y);
	}

	public Coord Clone() => new Coord(X, Y);
}
