namespace Sort
{
	public interface ISort
	{
		string Title { get; }
		void Descending(int[] source);
		void Ascending(int[] source);
	}
}
