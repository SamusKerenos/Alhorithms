using System;

namespace Concept
{
	public interface IConcept
	{
		ConsoleColor Color { get; }
		string Description { get; }
		string Explanation { get; }
		void Actions();
	}
}
