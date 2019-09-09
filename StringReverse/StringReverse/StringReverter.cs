using System.Linq;

namespace StringReverse
{
	public static class StringReverter
	{
		public static string Revert(this string source)
		{
			char[] data = source.Select(c => c).ToArray();

			for (int i = 0; i < (data.Length) / 2; i++)
			{
				int destinationIndex = (source.Length - 1) - i;

				char mem = data[destinationIndex];
				data[destinationIndex] = data[i];
				data[i] = mem;
			}

			return new string(data);
		}
	}
}
