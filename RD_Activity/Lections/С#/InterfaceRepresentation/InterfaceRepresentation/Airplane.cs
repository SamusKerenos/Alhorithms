using System;

namespace InterfaceRepresentation
{
	public class Airplane : IRespondable, IManageble
	{
		public void Respond()
		{
			Console.WriteLine("Ответ диспетчеру");
		}

		public void ChangeDirection()
		{
			Console.WriteLine("смена пункта прибытия");
		}

		public void ChangeSpeed()
		{
			Console.WriteLine("меняем скорость");
		}
	}
}
