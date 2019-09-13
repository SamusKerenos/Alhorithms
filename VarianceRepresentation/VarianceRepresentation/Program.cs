using Concept;
using SourceAndExtensions;
using System;

namespace VarianceRepresentation
{
	class Program
	{
		static void Main(string[] args)
		{
			int choise;

			Console.SetWindowSize(200, 50);

			do
			{
				Console.WriteLine(@"
==============================
| Available Representations: |
| 1. Covariance              |
| 2. Contrvariance           |
| 3. Invariance              |
|----------------------------|
| 4. Clear Console           |
| 5. Exit                    |
==============================
");
				choise = ConsoleExtensions.GetIntNumber(5, 1);

				switch (choise)
				{
					case 1:
						VarianceConsoleRepresetnetion.Represent(new Covariance());
						break;
					case 2:
						VarianceConsoleRepresetnetion.Represent(new Contrvariance());
						break;
					case 3:
						VarianceConsoleRepresetnetion.Represent(new Invariance());
						break;
					case 4:
						Console.Clear();
						break;
					default:
						break;
				}
			} while (choise != 5);
		}
	}
}
