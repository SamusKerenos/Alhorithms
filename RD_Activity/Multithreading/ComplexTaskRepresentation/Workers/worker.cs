using System;
using System.Threading;

namespace Workers
{
	public class Worker
	{
		private int _maxWorkCounter;
		
		public bool Canceled { get; set; }

		public Worker(int maxWorkCounter)
		{
			_maxWorkCounter = maxWorkCounter;
		}

		public void Work()
		{
			WorkStarted(_maxWorkCounter);

			int counter = 0;
			while (!Canceled && counter < _maxWorkCounter)
			{
				Thread.Sleep(1000);
				ProgressChanged("-work|");
				counter++;
			}

			Canceled = true;
			WorkComplete(counter);
		}

		public event Action<int> WorkStarted;

		public event Action<string> ProgressChanged;

		public event Action<int> WorkComplete;
	}
}
