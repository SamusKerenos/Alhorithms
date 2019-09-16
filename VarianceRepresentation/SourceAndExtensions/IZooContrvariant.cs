namespace SourceAndExtensions
{
	public interface IZooContrvariant<in T>
		where T : Cat
	{
		string SetAnimal(T cat);
	}
}
