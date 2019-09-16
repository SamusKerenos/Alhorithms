using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SourceAndExtensions;

namespace Concept
{
	public class Covariance : IConcept
	{
		private readonly IEnumerable<Cat> _cats;
		private readonly IEnumerable<Dog> _dogs;
		private readonly CityHouseCat _houseWithCat;
		private readonly CityHouseDog _houseWithDog;

		private readonly IEnumerable<Animal> _animals;
		private readonly Animal[] _animalsArray;
		private readonly IEnumerable<IHouseCovariant<Animal>> _houseWithAnimalCollection;
		
		private readonly Func<Animal, string> _doAction;

		public ConsoleColor Color => ConsoleColor.Cyan;

		public string Description => @"
===================================================================================
| Covariance - enables you to pass a derived type where a base type is expected.  |
| Covariance is the ability to convert data from a wider to a narrower data type. |
|---------------------------------------------------------------------------------|
| COVARIANCE WORK IN                         |
| Delegates                                  |
| Methods                                    |
| Arrays                                     |
| Interfaces with out types ICustom<out T>   |
| Some native interfaces like IEnumerable<T> |
==============================================";

		public string Explanation { get; private set; }

		public Covariance()
		{
			_cats = new List<Cat>()
			{
				new Cat { Name = "John" },
				new Cat { Name = "Sarah" }
			};
			
			_dogs = new List<Dog>()
			{
				new Dog { Name = "Abram" },
				new Dog { Name = "Mariya" }
			};

			_houseWithCat = new CityHouseCat("Murzic");
			_houseWithDog = new CityHouseDog("Bobick");

			IEnumerable<Animal> animalsCat = _cats.ToArray();
			IEnumerable<Animal> animalsDogs = _dogs.ToArray();
			_animals = animalsCat.Union(animalsDogs);
			
			Animal[] animalsArrayCat = _cats.ToArray();
			Animal[] animalsArrayDogs = _dogs.ToArray();
			_animalsArray = animalsArrayCat.Union(animalsArrayDogs).ToArray();

			_houseWithAnimalCollection = new IHouseCovariant<Animal>[] 
			{ 
				_houseWithCat,
				_houseWithDog 
			};

			_doAction = a => $" {a.Spice}: {a.Name} {a.Voice} |";
		}

		public void Actions()
		{
			StringBuilder result = new StringBuilder();
			result.Append(@"
==============================================================================================================================
| We have this items for work:                                                                                               |
| IEnumerable<Cat> collection which inintialized by new List<Cat>() { ... }                                                  |
| IEnumerable<Dog> collection which inintialized by new List<Dog>() { ... }                                                  |
| IEnumerable<Animal> collection which contain bouth of IEnumerable<Cat> and IEnumerable<Dog> collections                    |
| Animal[] which initialize by Cat[]                                                                                         |
| Animal[] which initialize by Dog[]                                                                                         |
| Animal[] which contain bouth of previous arrays                                                                            |
| IEnumerable<IHouseCovariant<Animal>> collection which consist of CityHouseCat CityHouseDog items of IHouseCovariant<out T> |
==============================================================================================================================");

			result.Append(@"

We iterate over the IEnumerable<Animal> and invoce the delegate with signature Func<Animal, string>
");
			foreach (Animal item in _animals)
			{
				result.Append(_doAction(item));
			}

			result.Append(@"

We iterate over the Animal[] and invoce the delegate with signature Func<Animal, string>
");
			foreach (Animal item in _animalsArray)
			{
				result.Append(_doAction(item));
			}

			result.Append(@"

We iterate over the IEnumerable<IHouseCovariant<Animal>> and invoce the delegate with signature Func<Animal, string>
");
			foreach (IHouseCovariant<Animal> item in _houseWithAnimalCollection)
			{
				result.Append(_doAction(item.GetAnimal()));
			}

			result.Append(@"

We iterate over the IEnumerable<Animal> and transfer item in the AnimalActions.ShowFace(Animal animal) method
");
			foreach (Animal item in _animals)
			{
				result.Append(AnimalActions.ShowFace(item));
			}

			result.Append(@"

We iterate over the Animal[] and transfer item in the AnimalActions.ShowFace(Animal animal) method
");
			foreach (Animal item in _animalsArray)
			{
				result.Append(AnimalActions.ShowFace(item));
			}

			result.Append(@"

We iterate over the IEnumerable<IHouseCovariant<Animal>> and transfer item in the AnimalActions.ShowFace(Animal animal) method
");
			foreach (IHouseCovariant<Animal> item in _houseWithAnimalCollection)
			{
				result.Append(AnimalActions.ShowFace(item.GetAnimal()));
			}

			result.Append(@"

---------------------------------------------
| We see the result which contain all items |
=============================================
");
			Explanation = result.ToString();
		}
	}
}
