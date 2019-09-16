namespace SourceAndExtensions
{
	public static class AnimalActions
	{
		public static string ShowFaceAnimal(Animal animal)
		{
			if (animal is Cat)
			{
				return $"\nInvoke method for {animal.Spice} {animal.Name} =^.^= |";
			}

			if (animal is Dog)
			{
				return $"\nInvoke method for {animal.Spice} {animal.Name} (0.0) |";
			}

			return "no face for generic animal";
		}

		public static string ShowFaceCat(Cat animal)
		{
			return $"\nInvoke method for Cat only {animal.Name} =^.^= |";
		}

		public static string ShowFaceCat(Dog animal)
		{
				return $"\nInvoke method for Dog only {animal.Name} (0.0) |";
		}
	}
}
