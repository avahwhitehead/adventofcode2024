namespace Day9;

public class Challenge1
{
	public readonly ushort?[] DiskArray;

	public Challenge1(byte[] diskLayout)
	{
		var diskLength = diskLayout.Sum(b => b);

		DiskArray = new ushort?[diskLength];

		FillDiskArray(diskLayout);
	}

	public long Solve()
	{
		while (!IsDiskComplete())
		{
			StepDefragmentation();
		}

		long checksum = 0;
		for (var diskIndex = 0; diskIndex < DiskArray.Length; diskIndex++)
		{
			// Disk is complete at this point
			// Encountering an empty spot means the end of the files
			if (DiskArray[diskIndex] == null) break;

			checksum += (long)DiskArray[diskIndex]!.Value * diskIndex;
		}
		return checksum;
	}

	public void StepDefragmentation()
	{
		var sourceBlockIndex = GetLastFileBlockIndex();
		var destinationBlockIndex = GetFirstFreeBlockIndex();

		// If either of these are null, the disk is complete
		if (sourceBlockIndex == null) return;
		if (destinationBlockIndex == null) return;

		DiskArray[destinationBlockIndex.Value] = DiskArray[sourceBlockIndex.Value];
		DiskArray[sourceBlockIndex.Value] = null;
	}

	public bool IsDiskComplete()
	{
		var hasFoundDigit = false;

		for (var i = DiskArray.Length - 1; i >= 0; i--)
		{
			// There is a null before the final character
			if (DiskArray[i] == null && hasFoundDigit) return false;

			// We have found a character - mark as true and continue looking for nulls
			if (DiskArray[i] != null) hasFoundDigit = true;
		}

		// All the `null`s in the array are after the final non-null byte
		return true;
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

	private int? GetLastFileBlockIndex()
	{
		for (var diskIndex = DiskArray.Length - 1; diskIndex >= 0; diskIndex--)
		{
			if (DiskArray[diskIndex] != null) return diskIndex;
		}

		// There are no files in the disk at all
		return null;
	}

	public int? GetFirstFreeBlockIndex()
	{
		for (var diskIndex = 0; diskIndex < DiskArray.Length; diskIndex++)
		{
			if (DiskArray[diskIndex] == null) return diskIndex;
		}

		// There is no free space on the disk
		return null;
	}
}
