namespace Source.Entities
{
	public class MonyAnaliticalUnit
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
	}
}
