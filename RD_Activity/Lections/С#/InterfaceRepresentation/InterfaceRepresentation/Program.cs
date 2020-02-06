namespace InterfaceRepresentation
{
	class Program
	{
		static void Main()
		{
			Dispatcher dispatcher = new Dispatcher();

			Airplane airplane = new Airplane();
			Rocket rocket = new Rocket();
			Sheep sheep = new Sheep();
			Fly fly = new Fly();
			
			dispatcher.Message(airplane);
			dispatcher.Manage(airplane);

			dispatcher.Message(rocket);
			dispatcher.Manage(rocket);

			dispatcher.Message(sheep);
			dispatcher.Manage(sheep);
		}
	}
}
