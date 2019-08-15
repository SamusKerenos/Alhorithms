using Source.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Source
{
	public static class CustomLINQ
	{
		private static List<Employee> _employees => new List<Employee>()
		{
			new Employee()
			{
				Name = "Nikolay",
				MonyPerHour = 6,
				Gender = Gender.Male,
				Level = Level.K1
			},
			new Employee()
			{
				Name = "Vasiliy",
				MonyPerHour = 5,
				Gender = Gender.Male,
				Level = Level.K1
			},
			new Employee()
			{
				Name = "Mariya",
				MonyPerHour = 10,
				Gender = Gender.Female,
				Level = Level.K2
			},
			new Employee()
			{
				Name = "Dmitriy",
				MonyPerHour = 12,
				Gender = Gender.Male,
				Level = Level.K2
			},
			new Employee()
			{
				Name = "Vlad",
				MonyPerHour = 21,
				Gender = Gender.Male,
				Level = Level.K3
			},
			new Employee()
			{
				Name = "Boris",
				MonyPerHour = 25,
				Gender = Gender.Male,
				Level = Level.K3
			},
			new Employee()
			{
				Name = "Elizabet",
				MonyPerHour = 24,
				Gender = Gender.Female,
				Level = Level.K3
			},
			new Employee()
			{
				Name = "Georgiy",
				MonyPerHour = 12,
				Gender = Gender.Male,
				Level = Level.K2
			},
			new Employee()
			{
				Name = "Margo",
				MonyPerHour = 8,
				Gender = Gender.Female,
				Level = Level.K1
			},
			new Employee()
			{
				Name = "Vialiy",
				MonyPerHour = 16,
				Gender = Gender.Male,
				Level = Level.K2
			},
			new Employee()
			{
				Name = "Otto",
				MonyPerHour = 17,
				Gender = Gender.Male,
				Level = Level.K2
			},
		};

		public static Employee[] FemaleEmployeeSortedByMoney => _employees.Where(e => e.Gender == Gender.Female).OrderBy(e => e.MonyPerHour).ToArray();
		public static Employee[] MaleEmployeeSortedByMoney => _employees.Where(e => e.Gender == Gender.Male).OrderBy(e => e.MonyPerHour).ToArray();
	}
}
