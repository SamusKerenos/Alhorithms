﻿namespace SourceAndExtensions
{
	public interface IHouse<T>
		where T : Animal
	{
		T GetAnimal();
	}
}
