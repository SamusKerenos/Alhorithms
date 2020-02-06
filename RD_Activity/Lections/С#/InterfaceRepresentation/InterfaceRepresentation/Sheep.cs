using System;

namespace InterfaceRepresentation
{
	public class Sheep : IManageble, IRespondable
	{
		public void ChangeDirection()
		{
			Console.WriteLine("Смена порта прибытия");
		}

		public void ChangeSpeed()
		{
			Console.WriteLine("Машинное отделение меняет скорость");
		}

		void IRespondable.Respond()
		{
			Console.WriteLine("Ответ порту");
		}
	}
}
