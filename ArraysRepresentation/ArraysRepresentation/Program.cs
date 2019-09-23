using System;

namespace ArraysRepresentation
{
	class Program
	{
		static void Main(string[] args)
		{
			Random contentGenerator = new Random(DateTime.Now.Millisecond);

			int firstDimensionLength = 10;
			int secondDimensionLength = 10;

			int initialIndexForFirstDimension = 10;
			int ininialIndexForSecondDimension = 10;

			int[,] twoDimensionArray = (int[,])Array.CreateInstance(typeof(int), new int[] { firstDimensionLength, secondDimensionLength }, new int[] { initialIndexForFirstDimension, ininialIndexForSecondDimension });

			firstDimensionLength = initialIndexForFirstDimension + firstDimensionLength;
			secondDimensionLength = ininialIndexForSecondDimension + secondDimensionLength;

			for (int i = initialIndexForFirstDimension; i < firstDimensionLength; i++)
			{
				for (int j = ininialIndexForSecondDimension; j < secondDimensionLength; j++)
				{
					twoDimensionArray[i, j] = contentGenerator.Next(1, 11);
				}
			}

			Console.WriteLine("------------------------------------------------------");

			for (int i = initialIndexForFirstDimension; i < firstDimensionLength; i++)
			{
				for (int j = ininialIndexForSecondDimension; j < secondDimensionLength; j++)
				{
					Console.Write($"-{twoDimensionArray[i, j], 2}| ");
				}
				Console.WriteLine();
			}

			Console.WriteLine("------------------------------------------------------");

			Console.ReadLine();
		}
	}
}
