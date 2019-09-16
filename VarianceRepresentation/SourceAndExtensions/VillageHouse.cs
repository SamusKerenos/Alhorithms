namespace SourceAndExtensions
{
	public class VillageHouseDog : IHouse<Dog>
	{
		public Dog Animal { get; }

		public VillageHouseDog(Dog dog)
		{
			Animal = dog;
		}
	}

	public class VillageHouseCat : IHouse<Cat>
	{
		public Cat Animal { get; }

		public VillageHouseCat(Cat cat)
		{
		 	Animal = cat;
		}
	}
}
