using System;

namespace InterfaceRepresentation
{
	public class Rocket : IRespondable, IManageble
	{
		public void Respond()
		{
			Console.WriteLine("Ответ центру управления");
		}

		public void ChangeDirection()
		{
			Console.WriteLine("корректирую направление взлета");
		}

		public void ChangeSpeed()
		{
			Console.WriteLine("коррекция скорости");
		}
	}
}
