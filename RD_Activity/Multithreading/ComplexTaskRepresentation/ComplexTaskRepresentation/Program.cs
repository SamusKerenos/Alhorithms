using System;
using System.Threading;
using Workers;

namespace ComplexTaskRepresentation
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("=== Representation of multithreading work with one object ===");
			
			var worker = new Worker(1000);
			worker.WorkStarted += ConsoleWorkEvents.OnWorkStart;
			worker.ProgressChanged += ConsoleWorkEvents.OnProgressChanged;
			worker.WorkComplete += ConsoleWorkEvents.OnWorkComplete;
			Thread sideThredWithWork = new Thread(worker.Work);


			var workCancelator = new WorkCanceler(worker);
			workCancelator.ShowDelay += ConsoleWorkEvents.OnShowDelay;
			workCancelator.DiceRoll += ConsoleWorkEvents.OnDiceRoll;
			workCancelator.WorkCanceled += ConsoleWorkEvents.OnWorkCanceled;
			Thread sideThreadWithWorkCancelation = new Thread(workCancelator.CancelWork);

			sideThredWithWork.Start();
			sideThreadWithWorkCancelation.Start();
		}
	}
}
