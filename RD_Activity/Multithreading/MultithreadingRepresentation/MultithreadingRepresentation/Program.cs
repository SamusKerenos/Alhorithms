using System;
using System.Threading;

namespace MultithreadingRepresentation
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("=== Simple representation of multithreading ===");
			var worker = new Worker();
			worker.ProgressChanged += OnProgressChanged;
			worker.WorkComplete += OnWorkComplete;

			Thread sideThred = new Thread(worker.Work);
			sideThred.Start(50 as object);

			if (StopWork())
			{
				worker.Cancel();
			}
		}

		static void OnWorkComplete(bool canceled, int counter)
		{
			if (canceled)
			{
				Console.WriteLine($" work canceled at {counter} count");
			}
			else
			{
				Console.WriteLine($" work complete");
			}
		}

		static void OnProgressChanged(string partialResult)
		{
			Console.Write(partialResult);
		}

		static bool StopWork()
		{
			Console.WriteLine("To stop work enter 'S' ");
			string stop = string.Empty;
			while (stop != "S")
			{
				stop = Console.ReadLine();
			}
			return true;
		}
	}
}
