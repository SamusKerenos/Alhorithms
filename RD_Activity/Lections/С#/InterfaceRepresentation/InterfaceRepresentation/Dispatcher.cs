namespace InterfaceRepresentation
{
	public class Dispatcher
	{
		public void Message(IRespondable item)
		{
			item.Respond();
		}

		public void Manage(IManageble item)
		{
			item.ChangeDirection();
			item.ChangeSpeed();
		}
	}
}
