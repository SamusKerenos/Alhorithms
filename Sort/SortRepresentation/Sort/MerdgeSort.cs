namespace Sort
{
	public class MerdgeSort : ISort
	{
		public string Title => "Merdge Sort";

		public void Descending(int[] source)
		{
			Sort(source, false);
		}

		public void Ascending(int[] source)
		{
			Sort(source, true);
		}

		private void Sort(int[] source, bool isAscending)
		{
			
		}
	}
}
