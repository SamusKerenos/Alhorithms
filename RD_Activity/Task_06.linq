<Query Kind="Program">
  <NuGetReference Version="3.7.1">NUnit</NuGetReference>
  <NuGetReference>NUnitLite.Out</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

public class Runner
{
	public static int Main(string[] args)
	{
		return new AutoRun(Assembly.GetExecutingAssembly())
					   .Execute(new String[] { });
	}

	[TestFixture]
	public class CheckingTask_06
	{
		#region task_01_test
		[Test]
		public void Test_06_01_Implement()
		{
			Assert.DoesNotThrow(new TestDelegate(ExceptionerTask_06_01));
		}

		[Test]
		[TestCaseSource(typeof(Test_06_01_Data), nameof(Test_06_01_Data.TestData))]
		public void Test_06_01_HaveValue(IEnumerable<Employee> first, IEnumerable<Employee> second)
		{
			Assert.IsNotNull(first.UnionSort(second));
		}

		[Test]
		[TestCaseSource(typeof(Test_06_01_Data), nameof(Test_06_01_Data.TestData))]
		public void Test_06_01_ReturnAnyEmployee(IEnumerable<Employee> first, IEnumerable<Employee> second)
		{
			Assert.IsTrue(first.UnionSort(second).Any());
		}
		
		[Test]
		[TestCaseSource(typeof(Test_06_01_Data), nameof(Test_06_01_Data.TestData))]
		public void Test_06_01_ResultBouthMaleAndFemale(IEnumerable<Employee> first, IEnumerable<Employee> second)
		{
			var actual = first.UnionSort(second);
			
			Assert.IsTrue(actual.Any(e => e.Gender == Gender.Male) && actual.Any(e => e.Gender == Gender.Female));
		}

		[Test]
		[TestCaseSource(typeof(Test_06_01_Data), nameof(Test_06_01_Data.TestData))]
		public void Test_06_01_ResultHasLengthOfBothSequence(IEnumerable<Employee> first, IEnumerable<Employee> second)
		{
			var expected = first.Count() + second.Count();
			var actual = first.UnionSort(second).Count();
			
			Assert.AreEqual(expected, actual);
		}

		[Test]
		[TestCaseSource(typeof(Test_06_01_Data), nameof(Test_06_01_Data.TestData))]
		public void Test_06_01_ResultContainBothSequence(IEnumerable<Employee> first, IEnumerable<Employee> second)
		{
			var actual = first.UnionSort(second);

			Assert.IsTrue(actual.All(ae => first.Any(fe => fe.Equals(ae)) || second.Any(se => se.Equals(ae))));
		}

		[Test]
		[TestCaseSource(typeof(Test_06_01_Data), nameof(Test_06_01_Data.TestData))]
		public void Test_06_01_Positive(IEnumerable<Employee> first, IEnumerable<Employee> second)
		{
			var expected = first.Union(second).OrderBy(e => e.MonyPerHour).ToList();
			var actual = first.UnionSort(second);

			Assert.IsTrue(expected.SequenceEqual(actual));
		}

		private void ExceptionerTask_06_01()
		{
			CustomLINQ.FemaleEmployeeSortedByMoney.UnionSort<Employee>(CustomLINQ.MaleEmployeeSortedByMoney);
		}
		#endregion

		#region task_02_test
		[Test]
		public void Test_06_02_Implement()
		{
			Assert.DoesNotThrow(new TestDelegate(ExceptionerTask_06_02));
		}

		[Test]
		public void Test_06_02_EmployeeFirst_HaveValue()
		{
			var result = CustomLINQ.EmployeesSortedByMoney.UnionSort(CustomLINQ.FrilancersSortedByMoney, Test_06_02_Data.EmployeeSelector, Test_06_02_Data.FreelancerSelector);

			Assert.IsTrue(result != null);
		}

		[Test]
		public void Test_06_02_FreelancerFirst_HaveValue()
		{
			var result = CustomLINQ.FrilancersSortedByMoney.UnionSort(CustomLINQ.EmployeesSortedByMoney, Test_06_02_Data.FreelancerSelector, Test_06_02_Data.EmployeeSelector);

			Assert.IsTrue(result != null);
		}

		[Test]
		public void Test_06_02_EmployeeFirst_ReturnAny()
		{
			var result = CustomLINQ.EmployeesSortedByMoney.UnionSort(CustomLINQ.FrilancersSortedByMoney, Test_06_02_Data.EmployeeSelector, Test_06_02_Data.FreelancerSelector);

			Assert.IsTrue(result.Any());
		}

		[Test]
		public void Test_06_02_FreelancerFirst_ReturnAny()
		{
			var result = CustomLINQ.FrilancersSortedByMoney.UnionSort(CustomLINQ.EmployeesSortedByMoney, Test_06_02_Data.FreelancerSelector, Test_06_02_Data.EmployeeSelector);

			Assert.IsTrue(result.Any());
		}

		[Test]
		public void Test_06_02_EmployeeFirst_ResultHasLengthOfBothSequence()
		{
			var expected = CustomLINQ.EmployeesSortedByMoney.Count() + CustomLINQ.FrilancersSortedByMoney.Count();
			var actual = CustomLINQ.EmployeesSortedByMoney.UnionSort(CustomLINQ.FrilancersSortedByMoney, Test_06_02_Data.EmployeeSelector, Test_06_02_Data.FreelancerSelector).Count();

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Test_06_02_FreelancerFirst_ResultHasLengthOfBothSequence()
		{
			var expected = CustomLINQ.EmployeesSortedByMoney.Count() + CustomLINQ.FrilancersSortedByMoney.Count();
			var actual = CustomLINQ.FrilancersSortedByMoney.UnionSort(CustomLINQ.EmployeesSortedByMoney, Test_06_02_Data.FreelancerSelector, Test_06_02_Data.EmployeeSelector).Count();

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Test_06_02_EmployeeFirst_ResultContainBothSequence()
		{
			var actual = CustomLINQ.EmployeesSortedByMoney.UnionSort(CustomLINQ.FrilancersSortedByMoney, Test_06_02_Data.EmployeeSelector, Test_06_02_Data.FreelancerSelector);

			Assert.IsTrue(actual.All(r => CustomLINQ.EmployeesSortedByMoney.Any(e => e.MonyPerHour == r.MonyPerHour) || CustomLINQ.FrilancersSortedByMoney.Any(f => f.MonyPerHour == r.MonyPerHour)));
		}

		[Test]
		public void Test_06_02_FreelancerFirst_ResultContainBothSequence()
		{
			var actual = CustomLINQ.FrilancersSortedByMoney.UnionSort(CustomLINQ.EmployeesSortedByMoney, Test_06_02_Data.FreelancerSelector, Test_06_02_Data.EmployeeSelector);

			Assert.IsTrue(actual.All(r => CustomLINQ.EmployeesSortedByMoney.Any(e => e.MonyPerHour == r.MonyPerHour) || CustomLINQ.FrilancersSortedByMoney.Any(f => f.MonyPerHour == r.MonyPerHour)));
		}

		[Test]
		public void Test_06_02_EmployeeFirst_Positive()
		{
			var expected = CustomLINQ.EmployeesSortedByMoney.Select(e => new MonyAnaliticalUnit()
			{
				WorkerType = WorkerType.Employee,
				MonyPerHour = e.MonyPerHour
			}).ToList();

			expected.AddRange(CustomLINQ.FrilancersSortedByMoney.Select(f => new MonyAnaliticalUnit()
			{
				WorkerType = WorkerType.Freelancer,
				MonyPerHour = f.MonyPerHour
			}));

			expected = expected.OrderBy(a => a.MonyPerHour).ToList();

			var actual = CustomLINQ.EmployeesSortedByMoney.UnionSort(CustomLINQ.FrilancersSortedByMoney, Test_06_02_Data.EmployeeSelector, Test_06_02_Data.FreelancerSelector);

			Assert.IsTrue(expected.SequenceEqual(actual));
		}

		[Test]
		public void Test_06_02_FreelancerFirst_Positive()
		{
			var expected = CustomLINQ.FrilancersSortedByMoney.Select(e => new MonyAnaliticalUnit()
			{
				WorkerType = WorkerType.Freelancer,
				MonyPerHour = e.MonyPerHour
			}).ToList();

			expected.AddRange(CustomLINQ.EmployeesSortedByMoney.Select(f => new MonyAnaliticalUnit()
			{
				WorkerType = WorkerType.Employee,
				MonyPerHour = f.MonyPerHour
			}));

			expected = expected.OrderBy(a => a.MonyPerHour).ToList();

			var actual = CustomLINQ.FrilancersSortedByMoney.UnionSort(CustomLINQ.EmployeesSortedByMoney, Test_06_02_Data.FreelancerSelector, Test_06_02_Data.EmployeeSelector);

			Assert.IsTrue(expected.SequenceEqual(actual));
		}

		private void ExceptionerTask_06_02()
		{
			CustomLINQ.EmployeesSortedByMoney.UnionSort(CustomLINQ.FrilancersSortedByMoney, Test_06_02_Data.EmployeeSelector, Test_06_02_Data.FreelancerSelector);
		}
		#endregion
	}

	public static class Test_06_01_Data
	{
		public static IEnumerable TestData
		{
			get
			{
				yield return new TestCaseData(CustomLINQ.FemaleEmployeeSortedByMoney, CustomLINQ.MaleEmployeeSortedByMoney);
				yield return new TestCaseData(CustomLINQ.MaleEmployeeSortedByMoney, CustomLINQ.FemaleEmployeeSortedByMoney);
			}
		}
	}

	public static class Test_06_02_Data
	{
		public static Func<Employee, MonyAnaliticalUnit> EmployeeSelector = e => new MonyAnaliticalUnit()
		{
			MonyPerHour = e.MonyPerHour,
			WorkerType = WorkerType.Employee
		};

		public static Func<Freelancer, MonyAnaliticalUnit> FreelancerSelector = e => new MonyAnaliticalUnit()
		{
			MonyPerHour = e.MonyPerHour,
			WorkerType = WorkerType.Freelancer
		};
	}
}

public static class Task_06
{
	#region Part01
	// необходимо написать реализацию новой LINQ операции которя будет объединять две 
	// отсортированных коллекции одинакового типа в новую коллекцию того же типа,
	// которя так же будет отсортировнна.
	// Готовые методы LINQ исопользовать запрещено.
	public static IEnumerable<T> UnionSort<T>(this IEnumerable<T> main, IEnumerable<T> second)
		where T : IComparable<T>
	{
		//throw new NotImplementedException();

		if (main == null || second == null)
		{
			throw new ArgumentNullException();
		}

		List<T> result = new List<T>();
		var mainIterator = main.GetEnumerator();
		var secondIterator = second.GetEnumerator();

		mainIterator.Reset();
		secondIterator.Reset();

		bool mainMovedNext = mainIterator.MoveNext();
		bool secondMovedNext = secondIterator.MoveNext();

		while (mainMovedNext || secondMovedNext)
		{
			if (mainMovedNext && secondMovedNext)
			{
				if (mainIterator.Current.CompareTo(secondIterator.Current) == 1)
				{
					result.Add(secondIterator.Current);
					secondMovedNext = secondIterator.MoveNext();
				}
				else
				{
					result.Add(mainIterator.Current);
					mainMovedNext = mainIterator.MoveNext();
				}
			}
			else if (mainMovedNext)
			{
				result.Add(mainIterator.Current);
				mainMovedNext = mainIterator.MoveNext();
			}
			else if (secondMovedNext)
			{
				result.Add(secondIterator.Current);
				secondMovedNext = secondIterator.MoveNext();
			}
		}

		return result;
	}
	#endregion

	#region Part02
	// необходимо написать новую LINQ операцию которя будет объединять две 
	// отсортированных коллекции разного типа в новую коллекцию итогового типа,
	// которя так же будет отсортировнна.
	// Готовые методы LINQ исопользовать запрещено.
	public static IEnumerable<R> UnionSort<T, H, R>(this IEnumerable<T> main, IEnumerable<H> second, Func<T, R> selectorMain, Func<H, R> selectorSecond)
		where R : IComparable<R>
	{
		//throw new NotImplementedException();


		if (main == null || second == null || selectorMain == null || selectorSecond == null)
		{
			throw new ArgumentNullException();
		}

		List<R> result = new List<R>();
		var mainIterator = main.GetEnumerator();
		var secondIterator = second.GetEnumerator();

		mainIterator.Reset();
		secondIterator.Reset();

		bool mainMovedNext = mainIterator.MoveNext();
		bool secondMovedNext = secondIterator.MoveNext();

		while (mainMovedNext || secondMovedNext)
		{
			if (mainMovedNext && secondMovedNext)
			{
				var resultMain = selectorMain(mainIterator.Current);
				var resultSecond = selectorSecond(secondIterator.Current);

				if (resultMain.CompareTo(resultSecond) == 1)
				{
					result.Add(resultSecond);
					secondMovedNext = secondIterator.MoveNext();
				}
				else
				{
					result.Add(resultMain);
					mainMovedNext = mainIterator.MoveNext();
				}
			}
			else if (mainMovedNext)
			{
				result.Add(selectorMain(mainIterator.Current));
				mainMovedNext = mainIterator.MoveNext();
			}
			else if (secondMovedNext)
			{
				result.Add(selectorSecond(secondIterator.Current));
				secondMovedNext = secondIterator.MoveNext();
			}
		}

		return result;
	}
	#endregion
}

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

public class MonyAnaliticalUnit : IComparable<MonyAnaliticalUnit>
{
	public WorkerType WorkerType { get; set; }
	public int MonyPerHour { get; set; }

	public override bool Equals(object obj)
	{
		if (obj == null || obj as MonyAnaliticalUnit == null)
		{
			return false;
		}

		return Equals((MonyAnaliticalUnit)obj);
	}

	public override int GetHashCode()
	{
		return MonyPerHour.GetHashCode();
	}

	public bool Equals(MonyAnaliticalUnit other)
	{
		return WorkerType == other.WorkerType
			&& MonyPerHour == other.MonyPerHour;
	}

	public int CompareTo(MonyAnaliticalUnit other)
	{
		if (other == null)
		{
			return 1;
		}

		return MonyPerHour.CompareTo(other.MonyPerHour);
	}
}

public class Employee : IComparable<Employee>
{
	public string Name { get; set; }
	public int MonyPerHour { get; set; }
	public Level Level { get; set; }
	public Gender Gender { get; set; }

	public override bool Equals(object obj)
	{
		if (obj == null || obj as Employee == null)
		{
			return false;
		}

		return Equals((Employee)obj);
	}

	public override int GetHashCode()
	{
		return Name.GetHashCode();
	}

	public bool Equals(Employee another)
	{
		return Name.Equals(another.Name)
			&& MonyPerHour.Equals(another.MonyPerHour)
			&& Level.Equals(another.Level)
			&& Gender.Equals(another.Gender);
	}

	public int CompareTo(Employee other)
	{
		if (other == null)
		{
			return 1;
		}

		return MonyPerHour.CompareTo(other.MonyPerHour);
	}
}

public class Freelancer
{
	public string Name { get; set; }
	public int MonyPerHour { get; set; }
	public Experience Experience { get; set; }
	public Gender Gender { get; set; }

	public override bool Equals(object obj)
	{
		if (obj == null || obj as Freelancer == null)
		{
			return false;
		}

		return Equals((Freelancer)obj);
	}

	public override int GetHashCode()
	{
		return Name.GetHashCode();
	}

	public bool Equals(Freelancer another)
	{
		return Name.Equals(another.Name)
			&& MonyPerHour.Equals(another.MonyPerHour)
			&& Experience.Equals(another.Experience)
			&& Gender.Equals(another.Gender);
	}
}

public enum Experience
{
	J,
	Y2,
	Y5,
}

public enum Gender
{
	Female,
	Male
}

public enum Level
{
	K1,
	K2,
	K3
}

public enum WorkerType
{
	Employee,
	Freelancer
}