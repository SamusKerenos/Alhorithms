namespace BinarySearch
{
	internal static class StringArrayHelper
	{
		public static string[] CopyData(this string[] source)
		{
			string[] result = new string[source.Length];

			for (int i = 0; i < source.Length; i++)
			{
				result[i] = string.Copy(source[i]);
			}

			return result;
		}

		public static string[] CopyDataFrom(this string[] source, int start)
		{
			if (start < source.Length)
			{
				int resultLength = source.Length - start;
				string[] result = new string[resultLength];
				
				for (int i = 0; i < resultLength; i++)
				{
					result[i] = string.Copy(source[start + i]);
				}

				return result;
			}

			return new string[0];
		}

		public static string[] CopyDataTill(this string[] source, int end)
		{
			if (end > source.Length)
			{
				end = source.Length;
			}

			int resultLength = source.Length - end;
			string[] result = new string[resultLength];

			for (int i = 0; i < resultLength; i++)
			{
				result[i] = string.Copy(source[i]);
			}

			return result;
		}
	}
}
