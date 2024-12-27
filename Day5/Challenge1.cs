namespace Day5;

public class Challenge1
{
	private readonly Dictionary<int, SortedSet<int>> DependenciesGraph;

	public Challenge1((int DependencyPage, int DependentPage)[] pages)
	{
		DependenciesGraph = MakeDependencyGraph(pages);
	}

	public int Solve(IEnumerable<int[]> pageLists)
	{
		return pageLists
			.Where(IsOrdered)
			.Select(pages => pages[pages.Length / 2])
			.Sum();
	}

	public bool IsOrdered(int[] pages)
	{
		var previousPageNumbers = new HashSet<int>();

		var allPageNumbers = pages.ToHashSet();

		foreach (var currentPageNumber in pages)
		{
			if (!DependenciesGraph.TryGetValue(currentPageNumber, out var currentPageDependencies))
			{
				previousPageNumbers.Add(currentPageNumber);
				continue;
			}

			foreach (var pageDependency in currentPageDependencies)
			{
				if (!allPageNumbers.Contains(pageDependency)) continue;

				if (previousPageNumbers.Contains(pageDependency)) continue;

				return false;
			}

			previousPageNumbers.Add(currentPageNumber);
		}

		return true;
	}

	public static Dictionary<int, SortedSet<int>> MakeDependencyGraph((int DependencyPage, int DependentPage)[] pages)
	{
		var graph = new Dictionary<int, SortedSet<int>>();

		foreach (var (dependency, dependent) in pages)
		{
			if (!graph.TryGetValue(dependent, out var dependenciesCollection))
			{
				dependenciesCollection = [];
				graph.Add(dependent, dependenciesCollection);
			}

			dependenciesCollection.Add(dependency);
		}

		return graph;
	}

	public static ((int DependencyPage, int DependentPage)[] Requirements, int[][] PageLists) Parse(string input)
	{
		var lines = input.Trim('\n').Split('\n');

		var requirements = new List<(int DependencyPage, int DependentPage)>();

		var lineIndex = 0;
		while (lines[lineIndex] != "")
		{
			var pages = lines[lineIndex]
				.Split('|')
				.Select(int.Parse)
				.ToArray();

			requirements.Add((pages[0], pages[1]));

			lineIndex++;
		}

		var pageLists = lines
			.Skip(lineIndex)
			.Skip(1)
			.Select(line => line.Split(",").Select(int.Parse).ToArray());

		return (requirements.ToArray(), pageLists.ToArray());
	}
}
