using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SourceAndExtensions;

namespace Concept
{
	public class Covariance : IConcept
	{
		private readonly IEnumerable<Animal> _animals;
		private readonly Animal[] _animalsArray;
		private readonly IEnumerable<IHouseCovariant<Animal>> _houseWithAnimalCollection;
		
		private readonly Func<Animal, string> _doAction;

		private Animal _animal;

		public ConsoleColor Color => ConsoleColor.Cyan;

		public string Description => @"
===================================================================================
| Covariance - enables you to pass a derived type where a base type is expected.  |
| Covariance is the ability to convert data from a wider to a narrower data type. |
|---------------------------------------------------------------------------------|
| COVARIANCE WORK IN                         |
| Variable initialization                    |
| Delegates                                  |
| Methods                                    |
| Arrays                                     |
| Interfaces with out types ICustom<out T>   |
| Some native interfaces like IEnumerable<T> |
==============================================";

		public string Explanation { get; private set; }

		public Covariance()
		{
			IEnumerable<Animal> cats = new List<Cat>()
			{
				new Cat { Name = "John" },
				new Cat { Name = "Sarah" }
			};

			IEnumerable<Animal> dogs = new List<Dog>()
			{
				new Dog { Name = "Abram" },
				new Dog { Name = "Mariya" }
			};

			_houseWithAnimalCollection = new IHouseCovariant<Animal>[] 
			{
				new CityHouseCat("Murzic"),
				new CityHouseDog("Bobick")
			};

			_animals = cats.Union(dogs);

			_animalsArray = cats.ToArray().Union(dogs.ToArray()).ToArray();

			_doAction = a => $"\ndelegate invoked with: {a.Spice}: {a.Name} {a.Voice} |";
		}

		public void Actions()
		{
			StringBuilder result = new StringBuilder();
			result.Append(@"
=======================================================================================
| We have this items for work:                                                        |
| IEnumerable<Animal> collection which contain of List<Cat> and List<Dog> collections |
| Animal[] which contain of two arrays: Cat[] and Dog[] bouth of it use like Animal[] |
| IEnumerable<IHouseCovariant<Animal>> collection which consist of                    |
| CityHouseCat CityHouseDog items of IHouseCovariant<out T>                           |
=======================================================================================");

			result.Append(@"

We iterate over the IEnumerable<Animal>
");
			foreach (Animal item in _animals)
			{
				result.Append(_doAction(item));
				result.Append(AnimalActions.ShowFaceAnimal(item));
			}

			result.Append(@"

We iterate over the Animal[]
");
			foreach (Animal item in _animalsArray)
			{
				result.Append(_doAction(item));
				result.Append(AnimalActions.ShowFaceAnimal(item));
			}

			result.Append(@"

We iterate over the IEnumerable<IHouseCovariant<Animal>>
");
			foreach (IHouseCovariant<Animal> item in _houseWithAnimalCollection)
			{
				result.Append(_doAction(item.GetAnimal()));
				result.Append(AnimalActions.ShowFaceAnimal(item.GetAnimal()));
			}

			result.Append(@"

We initialize variable with type Animal by Cat object
");
			_animal = new Cat() { Name = "Behemoth" };
			result.Append(_doAction(_animal));
			result.Append(AnimalActions.ShowFaceAnimal(_animal));

			result.Append(@"

We initialize variable with type Animal by Dog object
");
			_animal = new Dog() { Name = "Cerber" };
			result.Append(_doAction(_animal));
			result.Append(AnimalActions.ShowFaceAnimal(_animal));

			result.Append(@"

-----------------------------------------------------------------------------
| We see the result of delegates and methods for bouth of type: Cat and Dog |
=============================================================================
");
			Explanation = result.ToString();
		}
	}
}
