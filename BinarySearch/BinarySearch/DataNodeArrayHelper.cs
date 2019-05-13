namespace BinarySearch
{
	internal static class DataNodeArrayHelper
	{
		public static DataNode[] CopyDataFrom(this DataNode[] source, int start)
		{
			if (start < source.Length)
			{
				int resultLength = source.Length - start;
				DataNode[] result = new DataNode[resultLength];
				
				for (int i = 0; i < resultLength; i++)
				{
					int indexInSource = start + i;
					result[i] = new DataNode()
					{
						Name = string.Copy(source[indexInSource].Name),
						Number = source[indexInSource].Number
					};
				}

				return result;
			}

			return new DataNode[0];
		}

		public static DataNode[] CopyDataTill(this DataNode[] source, int end)
		{
			if (end > source.Length)
			{
				end = source.Length;
			}

			int resultLength = source.Length - end;
			DataNode[] result = new DataNode[resultLength];

			for (int i = 0; i < resultLength; i++)
			{
				result[i] = new DataNode()
				{
					Name = string.Copy(source[i].Name),
					Number = source[i].Number
				};
			}

			return result;
		}
	}
}
