using System;
using System.Collections.Generic;
using System.Text;
using SourceAndExtensions;

namespace Concept
{
	public class Covariance : IConcept
	{
		public ConsoleColor Color => ConsoleColor.Cyan;

		public string Description { get; private set; }

		public void Actions()
		{
			StringBuilder result = new StringBuilder();
			result.Append(@"
===================================================================================
| Covariance - enables you to pass a derived type where a base type is expected.  |
| Covariance is the ability to convert data from a wider to a narrower data type. |
| We can convert Animal to Cat natively, in interfaces and delegates              |
===================================================================================
");

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
Create collection of cats
List<Cat> catList = new List<Cat>() { ... };
");

			IEnumerable<Cat> cats = catList;
			result.Append(@"
Initialize IEnumerable generic Cat object by collection of cats
IEnumerable<Cat> cats = catList;
");

			IEnumerable<Animal> animals = cats;
			result.Append(@"
Initialize IEnumerable generic Animal object by IEnumerable generic Cat object 
IEnumerable<Animal> animals = cats;
");

			Func<Animal, string> doAction = a => $" {a.Name} say: {a.Voice} |";
			result.Append("\nCreate delegate which recive animal and do action with it \nFunc<Animal, string> doAction = a => $\" {a.Name} say: {a.Voice} |\";\n");

			result.Append(@"
We iterate over the List<Cat> and invoce this delegate: ");
			foreach (Cat item in catList)
			{
				result.Append(doAction(item));
			}

			result.Append(@"
We iterate over the IEnumerable<Cat> and invoce this delegate: ");
			foreach (Cat item in cats)
			{
				result.Append(doAction(item));
			}

			result.Append(@"
We iterate over the IEnumerable<Animal> and invoce this delegate: ");
			foreach (Animal item in animals)
			{
				result.Append(doAction(item));
			}
			result.Append(@"
We see the same result
");

			Description = result.ToString();
		}
	}
}
