namespace SourceAndExtensions
{
	public interface IHouseCovariant<out T>
		where T : Animal
	{
		T GetAnimal();
	}
}
