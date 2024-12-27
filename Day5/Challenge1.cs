namespace Day5;

public class Challenge1(Dictionary<int, SortedSet<int>> DependenciesGraph)
{
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
}
