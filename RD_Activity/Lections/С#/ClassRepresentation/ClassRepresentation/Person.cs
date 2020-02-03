using System;

namespace ClassRepresentation
{
	public class Person
	{
		private string _id = Guid.NewGuid().ToString();
		public DateTime Birthday { get; private set; }
		public string Name { get; private set; }

		public Person()
		{ }

		public Person(string name, DateTime birthday)
		{
			Name = name;
			Birthday = birthday;
		}

		public override string ToString()
		{
			return Name;
		}

		public override bool Equals(object obj)
		{
			Person anotherPerson = obj as Person;

			if (anotherPerson == null)
			{
				return false;
			}

			return Equals(anotherPerson);
		}

		public bool Equals(Person person)
		{
			return _id.Equals(person._id);
		}
	}
}
