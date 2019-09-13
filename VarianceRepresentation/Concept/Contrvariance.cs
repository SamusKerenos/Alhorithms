using System;
using System.Collections.Generic;
using System.Text;
using SourceAndExtensions;

namespace Concept
{
	public class Contrvariance : IConcept
	{
		public ConsoleColor Color => ConsoleColor.Yellow;

		public string Description { get; private set; }

		public string Explanation { get; private set; }

		public void Actions()
		{
			StringBuilder result = new StringBuilder();
			result.Append(@"
======================================================================================
| Contrvariance - 
| Contrvariance  is the ability to convert data from a narrower to wider data types. |
| We can convert Cat to Animal natively
======================================================================
");

			Description = result.ToString();
		}
	}
}
