namespace Day12;

public class Coord(int x, int y)
{
	public int X { get; } = x;
	public int Y { get; } = y;

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
