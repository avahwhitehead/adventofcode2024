namespace Day14;

public class Coord(int x, int y)
{
	public int X { get; set; } = x;
	public int Y { get; set; } = y;

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

	public Coord Add(Coord other)
	{
		return new Coord(X + other.X, Y + other.Y);
	}

	public override string ToString()
	{
		return $"({X}, {Y})";
	}
}
