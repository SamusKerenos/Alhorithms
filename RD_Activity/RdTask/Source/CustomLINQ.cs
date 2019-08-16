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

		private static List<Freelancer> _freelancers => new List<Freelancer>()
		{
			new Freelancer()
			{
				Name = "Dante",
				MonyPerHour = 4,
				Gender = Gender.Male,
				Experience = Experience.J
			},
			new Freelancer()
			{
				Name = "Virgil",
				MonyPerHour = 14,
				Gender = Gender.Male,
				Experience = Experience.Y5
			},
			new Freelancer()
			{
				Name = "Gwen",
				MonyPerHour = 10,
				Gender = Gender.Female,
				Experience = Experience.Y2
			},
			new Freelancer()
			{
				Name = "Juliya",
				MonyPerHour = 12,
				Gender = Gender.Female,
				Experience = Experience.Y2
			},
			new Freelancer()
			{
				Name = "Sparda",
				MonyPerHour = 31,
				Gender = Gender.Male,
				Experience = Experience.Y5
			},
			new Freelancer()
			{
				Name = "Mundus",
				MonyPerHour = 24,
				Gender = Gender.Male,
				Experience = Experience.Y5
			},
			new Freelancer()
			{
				Name = "Anna",
				MonyPerHour = 28,
				Gender = Gender.Female,
				Experience = Experience.Y5
			},
			new Freelancer()
			{
				Name = "Gordon",
				MonyPerHour = 12,
				Gender = Gender.Male,
				Experience = Experience.Y2
			},
			new Freelancer()
			{
				Name = "Maria",
				MonyPerHour = 7,
				Gender = Gender.Female,
				Experience = Experience.Y2
			},
			new Freelancer()
			{
				Name = "Mario",
				MonyPerHour = 3,
				Gender = Gender.Male,
				Experience = Experience.J
			},
		};

		public static Employee[] FemaleEmployeeSortedByMoney => _employees.Where(e => e.Gender == Gender.Female).OrderBy(e => e.MonyPerHour).ToArray();
		public static Employee[] MaleEmployeeSortedByMoney => _employees.Where(e => e.Gender == Gender.Male).OrderBy(e => e.MonyPerHour).ToArray();

		public static Employee[] EmployeesSortedByMoney => _employees.OrderBy(e => e.MonyPerHour).ToArray();
		public static Freelancer[] FrilancersSortedByMoney => _freelancers.OrderBy(e => e.MonyPerHour).ToArray();
	}
}
