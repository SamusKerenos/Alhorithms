using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MultithreadingRepresentation
{
	public class Worker
	{
		private bool _canceled = false;

		public void Cancel()
		{
			_canceled = true;
		}

		public void Work(object maxCounterObject)
		{
			if (maxCounterObject != null && maxCounterObject is int)
			{
				int counter = 1;
				int maxCounter = (int)maxCounterObject;

				while (!_canceled && counter < maxCounter)
				{
					Thread.Sleep(1000);
					ProgressChanged("-work|");
					counter++;
				}

				WorkComplete(_canceled, counter);
			}
		}

		public event Action<string> ProgressChanged;

		public event Action<bool, int> WorkComplete;
	}
}
