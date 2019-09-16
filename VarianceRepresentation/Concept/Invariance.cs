using System;
using System.Text;
using SourceAndExtensions;

namespace Concept
{
	public class Invariance : IConcept
	{
		private readonly VillageHouseDog _houseWithDog;
		private readonly VillageHouseCat _houseWithCat;

		public ConsoleColor Color => ConsoleColor.Red;

		public string Description => @"
============================================================================
| Invariance - prevent you to pass different type in strong typed variable |
| Invariance is the inability to do conversion between data types          |
|--------------------------------------------------------------------------|
| INVARIANCE WORK IN           |
| Generic types and interfaces |
================================";

		public string Explanation { get; private set; }

		public Invariance()
		{
			_houseWithDog = new VillageHouseDog(new Dog { Name = "Tuzick" });
			_houseWithCat = new VillageHouseCat(new Cat { Name = "Murzick" });
		}

		public void Actions()
		{
			StringBuilder result = new StringBuilder();
			result.Append(@"
================================================================
| We have this items for work:                                 |
| VillageHouseDog object  which realize interface: IHouse<Dog> |
| VillageHouseCat object  which realize interface: IHouse<Cat> |
| And IHouse<T> interface where T : Animal                     |
| -------------------------------------------------------------|
| And we can't do this:                 |
| IHouse<Animal> house = _houseWithCat; |
| IHouse<Animal> house = _houseWithDog; |
| Because generic invariance            |
=========================================
");
			//IHouse<Animal> house = _houseWithCat;
			//IHouse<Animal> house = _houseWithDog;
			
			Explanation = result.ToString();
		}
	}
}
