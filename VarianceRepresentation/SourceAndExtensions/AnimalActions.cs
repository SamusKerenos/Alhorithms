namespace SourceAndExtensions
{
	public static class AnimalActions
	{
		public static string ShowFace(Animal animal)
		{
			if (animal is Cat)
			{
				return $"{animal.Name} =^.^= |";
			}

			if (animal is Dog)
			{
				return $"{animal.Name} (0.0) |";
			}

			return "no face for generic animal";
		}
	}
}
