using System;

namespace ClassRepresentation
{
	class Program
	{
		static void Main(string[] args)
		{
			Person bill = new Person("Bill", new DateTime(1990, 04, 16));

			Employee sam = new Employee("Sam", new DateTime(1990, 04, 16));

			if (!bill.Equals(sam))
			{
				Console.WriteLine("Экземпляры неравны друг другу");
			}
			else
			{
				Console.WriteLine("Экземпляры равны друг другу");
			}
		}
	}
}
