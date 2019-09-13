using System;
using System.Collections.Generic;
using System.Text;
using SourceAndExtensions;

namespace Concept
{
	public class Invariance : IConcept
	{
		public ConsoleColor Color => ConsoleColor.Red;

		public string Description { get; private set; }

		public string Explanation { get; private set; }

		public void Actions()
		{
			StringBuilder result = new StringBuilder();
			result.Append(@"
============================================================================
| Invariance - prevent you to pass different type in strong typed variable |
| Invariance is the inability to do conversion between data types          |
----------------------------------------------------------------------------
| INVARIANCE WORK IN          |
| Generic types               |
| Type variable intialization |
| Specific interfaces         |
===============================
");
			#region Initialize objects
			List<Cat> catList = new List<Cat>()
			{
				new Cat
				{
					Name = "John"
				},
				new Cat
				{
					Name = "Sarah"
				}
			};

			result.Append(@"
When ininialize collection of cats we should use Cat type we can't use Animal type
List<Cat> catList = new List<Cat>() { ... };
");

			//List<Animal> animalList = new List<Cat>()
			//{
			//	new Cat
			//	{
			//		Name = "John"
			//	},
			//	new Cat
			//	{
			//		Name = "Sarah"
			//	}
			//};

			result.Append(@"
Create collection of Animals and try to initialize it with Cat collection
List<Animal> animalList = new List<Cat>() { ... };
And we see compilation error: Cannot implicity convert type Cat to Animal!
Because generic list is invariance
");
			VillageHouse houseWithDog = new VillageHouse("Bobick");
			result.Append("\nWe create variable houseWithDog which is VillageHouse type\nVillageHouse houseWithDog = new VillageHouse(\"Bobick\")\n");

			IHouse<Dog> houseWithAnimalDog = houseWithDog;
			result.Append(@"
We create variable houseWithAnimalDog which is interface IHouse<Dog> generic interface
And initialize it with houseWithDog variable because all of it have Dog type inside
IHouse<Dog> houseWithAnimalDog = houseWithDog;
");

			//IHouse<Animal> houseWithAnimal = houseWithDog;
			result.Append(@"
But we can't use variable houseWithDog to initialize variable houseWithAnimal
because it have interface IHouse<Animal> but houseWithDog realize more specific
interface IHouse<Dog> here we have compilar error:
IHouse<Animal> houseWithAnimal = houseWithDog;
");
			#endregion

			Description = result.ToString();
		}
	}
}
