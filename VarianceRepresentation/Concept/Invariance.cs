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

		public void Actions()
		{
			StringBuilder result = new StringBuilder();
			result.Append(@"
=====================================================================
| Invariance - 
=====================================================================
");
			Description = result.ToString();
		}
	}
}
