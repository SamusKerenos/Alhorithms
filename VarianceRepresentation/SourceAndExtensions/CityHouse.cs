namespace SourceAndExtensions
{
	public class CityHouseCat : IHouseCovariant<Cat>
	{
		private readonly Cat _cat;

		public CityHouseCat(string name)
		{
			_cat = new Cat() { Name = name };
		}

		public Cat GetAnimal()
		{
			return _cat;
		}
	}

	public class CityHouseDog : IHouseCovariant<Dog>
	{
		private readonly Dog _dog;

		public CityHouseDog(string name)
		{
			_dog = new Dog() { Name = name };
		}

		public Dog GetAnimal()
		{
			return _dog;
		}
	}
}
