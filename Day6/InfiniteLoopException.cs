using System.Runtime.Serialization;

namespace Day6;

public class InfiniteLoopException: Exception
{
	public InfiniteLoopException()
	{
	}

	protected InfiniteLoopException(SerializationInfo info, StreamingContext context) : base(info, context)
	{
	}

	public InfiniteLoopException(string? message) : base(message)
	{
	}

	public InfiniteLoopException(string? message, Exception? innerException) : base(message, innerException)
	{
	}
}
