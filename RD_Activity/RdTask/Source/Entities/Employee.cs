namespace Source.Entities
{
	public class Employee
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
	}
}
