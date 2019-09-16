using System;
using System.Text;
using SourceAndExtensions;

namespace Concept
{
	public class Contrvariance : IConcept
	{
		private IZooContrvariant<Leopard> _zooLeopard;

		public ConsoleColor Color => ConsoleColor.Yellow;

		public string Description => @"
======================================================================================
| Contrvariance - enables you to pass a base type where a derived type expected      |
| Contrvariance  is the ability to convert data from a narrower to wider data types. |
======================================================================================
| CONTRVARIANCE WORK IN                  |
| Interfaces with in types ICustom<in T> |
==========================================";

		public string Explanation { get; private set; }

		public Contrvariance()
		{
			_zooLeopard = new AnimalZoo<Cat>();
		}

		public void Actions()
		{
			StringBuilder result = new StringBuilder();
			result.Append(@"
=======================================================================
| We have item for work:                                              |
| IZooContrvariant<Leopard> which initialized by new AnimalZoo<Cat>() |
=======================================================================
");
			result.Append(_zooLeopard.SetAnimal(new Leopard() { Name = "Mamba" }));

			Explanation = result.ToString();
		}
	}
}
