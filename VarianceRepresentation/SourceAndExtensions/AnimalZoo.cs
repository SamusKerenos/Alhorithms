namespace SourceAndExtensions
{
	public class AnimalZoo<T> : IZooContrvariant<T>
		where T : Cat
	{
		public string SetAnimal(T cat)
		{
			return $"Successful set in zoo: {cat.Spice} {cat.Name} {cat.Voice} |";
		}
	}
}
