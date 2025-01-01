namespace Day12;

public class Challenge2(string[] map) : Challenge1(map)
{
	public override int Solve()
	{
		return GetRegions()
			.Select(r => r.GetArea() * r.GetNumberOfSides())
			.Sum();
	}
}
