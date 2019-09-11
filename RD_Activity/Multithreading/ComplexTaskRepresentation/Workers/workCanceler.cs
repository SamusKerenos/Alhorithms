using System;
using System.Threading;

namespace Workers
{
	public class WorkCanceler
	{
		private Random _engin = new Random(DateTime.Now.Millisecond);
		private readonly Worker _worker;

		public WorkCanceler(Worker worker)
		{
			_worker = worker;
		}

		public void CancelWork()
		{
			while (!_worker.Canceled)
			{
				int dice = _engin.Next(1, 21);
				DiceRoll(dice);

				int delay = 500 * dice;
				ShowDelay(delay);

				Thread.Sleep(delay);
				_worker.Canceled = dice == 20;
			}

			WorkCanceled();
		}

		public event Action<int> ShowDelay;

		public event Action<int> DiceRoll;

		public event Action WorkCanceled;
	}
}
