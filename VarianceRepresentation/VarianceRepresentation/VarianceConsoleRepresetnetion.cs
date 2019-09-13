using Concept;
using System;

namespace VarianceRepresentation
{
	class VarianceConsoleRepresetnetion
	{
		public static void Represent(IConcept concept)
		{
			Console.ForegroundColor = concept.Color;
			
			Console.WriteLine(concept.Description);
			concept.Actions();
			Console.WriteLine(concept.Explanation);


			Console.ForegroundColor = ConsoleColor.Green;
		}
	}
}
