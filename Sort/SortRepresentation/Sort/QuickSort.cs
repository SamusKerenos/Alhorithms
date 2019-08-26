using System;

namespace Sort
{
	public class QuickSort : ISort
	{
		public string Title => "Quick Sort";

		public void Descending(int[] source)
		{
			Sort(source, 0, source.Length - 1, (element, baseElement) => element <= baseElement);
		}

		public void Ascending(int[] source)
		{
			Sort(source, 0, source.Length - 1, (element, baseElement) => element >= baseElement);
		}

		private void Sort(int[] source, int startIndex, int endIndex, Func<int, int, bool> elementShouldBeAfterBase)
		{
			int baseIndex = startIndex + ((endIndex - startIndex) / 2);
			// this element can be random, or can be selected by some function
			// but in should located on sorting part of source array

			#region iterate to left from the base element till start index
			if (baseIndex > startIndex)
			{
				for (int i = baseIndex - 1; i >= startIndex; i--)
				{
					// here we iterate to left direction from the base element
					// and move all element which should be to the right of base element
					if (elementShouldBeAfterBase(source[i], source[baseIndex]))
					{
						if (i == baseIndex - 1)
						{
							// we have special case when:
							// ... [i][baseIndex]

							int mem = source[baseIndex];
							source[baseIndex] = source[i];
							source[i] = mem;
							// we simple change it places:
							// ... [baseIndex][i]
						}
						else
						{
							// we have this:
							// [i] ... [baseIndex - 1] [baseIndex]

							int mem = source[baseIndex];
							source[baseIndex] = source[i];
							// it become that:
							// [i] ... [baseIndex - 1] [i] | mem = [baseIndex] 

							int memTwo = source[baseIndex - 1];
							source[baseIndex - 1] = mem;
							// it become that:
							// [i] ... [baseIndex] [i] | memTwo = [baseIndex - 1] 

							source[i] = memTwo;
							// and finaly:
							// [baseIndex - 1] ... [baseIndex] [i]
						}

						baseIndex--;
						// in any case we, as a result of movement, decrease base index.
					}
				}
				// as a result ot this action, all elements to the left of base element
				// are less then base element. But some elements to the right of base element
				// could also be less then base element

			}
			#endregion
			
			#region iterate to right from the base element till end index
			if (baseIndex < endIndex)
			{
				for (int i = baseIndex + 1; i <= endIndex; i++)
				{
					// here we iterate to right direction from the base element
					// and move all element which should be to the right of base element
					if (!elementShouldBeAfterBase(source[i], source[baseIndex]))
					{
						if (i == baseIndex + 1)
						{
							// we have special case when:
							// [baseIndex][i] ...

							int mem = source[i];
							source[i] = source[baseIndex];
							source[baseIndex] = mem;
							// we simple change it places:
							// [i][baseIndex] ...
						}
						else
						{
							// we have this:
							// [baseIndex][baseIndex + 1] ... [i]

							int mem = source[baseIndex];
							source[baseIndex] = source[i];
							// it become that:
							// [i][baseIndex + 1] ... [i] | mem = [baseIndex] 

							int memTwo = source[baseIndex + 1];
							source[baseIndex + 1] = mem;
							// it become that:
							// [i] [baseIndex] ... [i] | memTwo = [baseIndex + 1] 

							source[i] = memTwo;
							// and finaly:
							// [i][baseIndex] ... [baseIndex + 1]
						}
						baseIndex++;
						// in any case we, as a result of movement, increase base index.
					}
				}
				// as a result ot this action, all elements to the left of base element
				// are less then base element. And elements to the right of base element
				// are greate then base element

			}
			#endregion
			// At the end of this reagens we define where in result sequence element
			// with base index should be
			
			#region work with left part
			int endIndexForLeftSide = baseIndex - 1;
			if (endIndexForLeftSide > startIndex)
			{
				//we do it only if at the left side from the base element we have some values
				Sort(source, startIndex, endIndexForLeftSide, elementShouldBeAfterBase);
			}
			#endregion

			#region work with right part
			int startIndexForRightSide = baseIndex + 1;
			if (startIndexForRightSide < endIndex)
			{
				//we do it only if at the right side from the base element we have some values
				Sort(source, startIndexForRightSide, endIndex, elementShouldBeAfterBase);
			}
			#endregion
		}
	}
}
