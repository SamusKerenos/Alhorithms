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

		public void Actions()
		{
			StringBuilder result = new StringBuilder();
			result.Append(@"
======================================================================
| Contrvariance - 
======================================================================
");
			Description = result.ToString();
		}
	}
}
