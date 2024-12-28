namespace Day9;

public class Challenge2
{
	public readonly ushort?[] DiskArray;

	public Challenge2(byte[] diskLayout)
	{
		var diskLength = diskLayout.Sum(b => b);

		DiskArray = new ushort?[diskLength];

		FillDiskArray(diskLayout);
	}

	public long Solve()
	{
		var endIndex = DiskArray.Length;
		do
		{
			endIndex = StepDefragmentation(endIndex);
		} while (endIndex > 0);

		long checksum = 0;
		for (var diskIndex = 0; diskIndex < DiskArray.Length; diskIndex++)
		{
			if (DiskArray[diskIndex] == null) continue;

			checksum += (long)DiskArray[diskIndex]!.Value * diskIndex;
		}
		return checksum;
	}

	private (int StartIndex, int Length)? FindNextFileIndex(int startIndex)
	{
		var blockLength = 0;

		for (var diskIndex = startIndex - 1; diskIndex >= 1; diskIndex--)
		{
			// Skip free space
			if (DiskArray[diskIndex] == null) continue;

			// There is a file in this block
			// Record the current index and increase the block length
			// This will end up at the start of the block
			var sourceBlockIndex = diskIndex;
			blockLength++;

			// Exit when a different file block starts
			// Or when free space starts
			if (DiskArray[diskIndex] != DiskArray[diskIndex - 1])
			{
				return (sourceBlockIndex, blockLength);
			}
		}

		return null;
	}

	private (int StartIndex, int Length, int DestinationIndex)? FindNextFileIndexWithDestination(int startIndex)
	{
		do
		{
			// No more files to organise
			if (startIndex == 0) return null;

			var fileRes = FindNextFileIndex(startIndex);

			// No more files to organise
			if (fileRes == null) return null;

			var blockLength = fileRes.Value.Length;
			var sourceBlockIndex = fileRes.Value.StartIndex;

			startIndex = sourceBlockIndex;

			var destinationBlockIndex = GetFirstFreeBlockIndex(blockLength);

			// Check there is enough free space for this file
			// Otherwise continue searching
			if (destinationBlockIndex != null && destinationBlockIndex < sourceBlockIndex)
			{
				return (sourceBlockIndex, blockLength, destinationBlockIndex.Value);
			}
		} while (true);
	}

	public int StepDefragmentation(int endIndex)
	{
		var fileRes = FindNextFileIndexWithDestination(endIndex);
		if (fileRes == null) return 0;

		var blockLength = fileRes.Value.Length;
		var sourceBlockIndex = fileRes.Value.StartIndex;
		var destinationBlockIndex = fileRes.Value.DestinationIndex;

		Array.Fill(DiskArray, DiskArray[sourceBlockIndex]!.Value, destinationBlockIndex, blockLength);
		Array.Fill(DiskArray, null, sourceBlockIndex, blockLength);

		return sourceBlockIndex;
	}

	private void FillDiskArray(byte[] diskLayout)
	{
		int diskIndex = 0;
		ushort fileId = 0;

		// Digits in the layout array alternate file block definition/free space definition
		var isFileBlockDefinition = true;
		foreach (var blockLength in diskLayout)
		{
			if (isFileBlockDefinition)
			{
				// Fill the next `blockLength` blocks with the file ID
				// And increment the file ID for the next block
				Array.Fill(DiskArray, fileId++, diskIndex, blockLength);
			}

			// Increment the current index in the disk
			diskIndex += blockLength;

			isFileBlockDefinition = !isFileBlockDefinition;
		}
	}

	public int? GetFirstFreeBlockIndex(int blockLength)
	{
		int? freeSpaceStartIndex = null;
		for (var diskIndex = 0; diskIndex < DiskArray.Length; diskIndex++)
		{
			// Reset the counter for any non-empty blocks
			if (DiskArray[diskIndex] != null)
			{
				freeSpaceStartIndex = null;
				continue;
			}

			freeSpaceStartIndex ??= diskIndex;

			if (diskIndex + 1 - freeSpaceStartIndex >= blockLength)
			{
				return freeSpaceStartIndex;
			}
		}

		// There is no free space large enough on the disk
		return null;
	}
}
