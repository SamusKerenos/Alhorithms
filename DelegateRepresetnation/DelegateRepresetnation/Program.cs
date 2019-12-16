using System;

namespace DelegateRepresetnation
{
	class Program
	{
		private static Action<string> _showCondition = condition =>
		{
			Console.WriteLine($"это фильтрация для {condition}");
		};

		static void Main()
		{
			// вот тут мы инициализируем переменную делегата методом
			Func<string, bool> _conditionResolver = ConditionalResolver;

			string userInput = Console.ReadLine();

			ShowResult(_conditionResolver, userInput);

			userInput = Console.ReadLine();
			// вот тут мы инициализируем переменную делегата лямбдой
			// которая так же как и метод выше полностью удовлетворяет 
			// делегату типа Func<string, bool>
			_conditionResolver = input =>
			{
				string _condition = "Мышь";
				_showCondition(_condition);
				return input.Equals(_condition);
			};

			ShowResult(_conditionResolver, userInput);
		}

		// метод полностью удовлетворяет делегату типа Func<string, bool>
		// по этому его можно использовать для инициализации переменных
		// делегата типа Func<string, bool>
		private static bool ConditionalResolver(string input)
		{
			string _condition = "жаба";
			_showCondition(_condition);
			return input.Equals(_condition);
		}

		private static void ShowResult(Func<string, bool> filter, string input)
		{
			if (filter(input))
			{
				Console.WriteLine("Мы нашли");
			}
			else
			{
				Console.WriteLine("Здесь такого нет");
			}
		}
	}
}
