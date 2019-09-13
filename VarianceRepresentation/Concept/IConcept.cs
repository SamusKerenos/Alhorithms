using System;

namespace Concept
{
	public interface IConcept
	{
		ConsoleColor Color { get; }
		string Description { get; }
		void Actions();
	}
}
