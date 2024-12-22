using System;
using Day1;
using JetBrains.Annotations;
using Xunit;
using Xunit.Abstractions;

namespace Day1.Tests;

[TestSubject(typeof(Challenge1))]
public class Challenge1Test
{
	private readonly ITestOutputHelper _testOutputHelper;

	public Challenge1Test(ITestOutputHelper testOutputHelper)
	{
		_testOutputHelper = testOutputHelper;
	}

	[Fact]
	public void Provided_Example_Input_ShouldSucceed()
	{
		// Arrange
		var sut = new Challenge1();

		var listA = new int[] { 3, 4, 2, 1, 3, 3 };
		var listB = new int[] { 4, 3, 5, 3, 9, 3 };

		const int expectedResult = 11;
		
		// Act
		var actualResult = sut.ReconcileLists(listA, listB);

		// Assert
		Assert.Equal(expectedResult, actualResult);
	}
}