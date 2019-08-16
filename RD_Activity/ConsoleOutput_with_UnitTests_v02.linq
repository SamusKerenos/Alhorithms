<Query Kind="Program">
  <NuGetReference Version="3.7.1">NUnit</NuGetReference>
  <NuGetReference>NUnitLite.Out</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

public class Runner
{
	public static int Main(string[] args)
	{
		return new AutoRun(Assembly.GetExecutingAssembly())
					   .Execute(new String[] { });
	}

	[TestFixture]
	public class ConsoleUtilsTests
	{

		[Test]
		public void TestIsTrue_False_Fail()
		{
			Assert.IsTrue(false);
		}

		[Test]
		public void TestIsTrue_True_Success()
		{
			Assert.IsTrue(true);
		}

		[Test]
		public void TestWriteToConsole_OneWord_Success()
		{
			const string greeting = "Hello";
			TextWriter currentConsoleOut = Console.Out;
			ConsoleUtils target = new ConsoleUtils();

			using (ConsoleOutput consoleOutput = new ConsoleOutput())
			{
				target.WriteToConsole(greeting);
				Assert.AreEqual(greeting, consoleOutput.GetOuput());
			}

			Assert.AreEqual(currentConsoleOut, Console.Out);
		}

		[Test]
		public void TestWriteLineToConsole_OneLine_Success()
		{
			const string greeting = "Hello";
			TextWriter currentConsoleOut = Console.Out;
			ConsoleUtils target = new ConsoleUtils();
			const string expected = 
@"Hello
";

			using (ConsoleOutput consoleOutput = new ConsoleOutput())
			{
				target.WriteLineToConsole(greeting);
				Assert.AreEqual(expected, consoleOutput.GetOuput());
			}

			Assert.AreEqual(currentConsoleOut, Console.Out);
		}

		[Test]
		public void TestWriteLineToConsole_TwoLines_Success()
		{
			const string greeting = "Hello";
			const string toWhom = "world!";
			TextWriter currentConsoleOut = Console.Out;
			ConsoleUtils target = new ConsoleUtils();
			const string expected =
@"Hello
world!
";

			using (ConsoleOutput consoleOutput = new ConsoleOutput())
			{
				target.WriteLineToConsole(greeting);
				target.WriteLineToConsole(toWhom);
				Assert.AreEqual(expected, consoleOutput.GetOuput());
			}

			Assert.AreEqual(currentConsoleOut, Console.Out);
		}
	}
}

public class ConsoleUtils
{
	public void WriteToConsole(string text)
	{
		Console.Write(text);
	}

	public void WriteLineToConsole(string text)
	{
		Console.WriteLine(text);
	}
}

public class ConsoleOutput : IDisposable
{
	private StringWriter stringWriter;
	private TextWriter originalOutput;

	public ConsoleOutput()
	{
		stringWriter = new StringWriter();
		originalOutput = Console.Out;
		Console.SetOut(stringWriter);
	}

	public string GetOuput()
	{
		return stringWriter.ToString();
	}

	public void Dispose()
	{
		Console.SetOut(originalOutput);
		stringWriter.Dispose();
	}
}