using JetBrains.Annotations;

namespace Day11.Tests;

[TestSubject(typeof(Challenge2))]
public class Challenge2Test
{
	[Theory]
	[InlineData(true)]
	public void Step_Should_Produce_Expected_Values(bool runExtraLong)
	{
		// Arrange
		var sut = new Challenge2([125, 17]);

		// Act
		// Assert

		sut.StepStones();
		Assert.Equal(3, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(4, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(5, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(9, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(13, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(22, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(31, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(42, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(68, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(109, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(170, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(235, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(342, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(557, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(853, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(1298, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(1951, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(2869, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(4490, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(6837, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(10362, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(15754, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(23435, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(36359, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(55312, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(83230, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(127262, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(191468, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(292947, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(445882, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(672851, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(1028709, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(1553608, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(2363143, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(3604697, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(5445643, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(8300739, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(12585458, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(19103521, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(29115525, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(44059301, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(67054789, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(101858682, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(154443798, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(235189097, sut.StonesCount);

		if (!runExtraLong) return;

		sut.StepStones();
		Assert.Equal(356552789, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(541841962, sut.StonesCount);

		sut.StepStones();
		Assert.Equal(823634145, sut.StonesCount);
	}
}
