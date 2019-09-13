using Concept;
using System;

namespace VarianceRepresentation
{
	class VarianceConsoleRepresetnetion
	{
		public static void Represent(IConcept concept)
		{
			Console.ForegroundColor = concept.Color;
			
			concept.Actions();
			Console.WriteLine(concept.Description);
			
			Console.ForegroundColor = ConsoleColor.Green;
		}
	}
}
