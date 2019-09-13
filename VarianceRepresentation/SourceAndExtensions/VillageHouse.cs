namespace SourceAndExtensions
{
	public class VillageHouse : IHouse<Dog>
	{
		private readonly Dog _dog;

		public VillageHouse(string name)
		{
			_dog = new Dog() { Name = name };
		}

		public Dog GetAnimal()
		{
			return _dog;
		}
	}
}
