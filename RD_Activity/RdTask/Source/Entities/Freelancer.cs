namespace Source.Entities
{
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
}
