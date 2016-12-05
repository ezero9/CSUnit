using System;
namespace CSUnit
{
	public class StopWatch
	{
		private long _startTime = 0;
		private long _elapsedTime = 0;

		public StopWatch()
		{
		}

		public void Start()
		{
			_startTime = GetCurrentTime();
		}

		public void Stop()
		{
			_elapsedTime = GetCurrentTime() - _startTime;
		}

		public long Elapsed
		{
			get
			{
				return _elapsedTime;
			}
		}

		private long GetCurrentTime()
		{
			return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
		}

		public override string ToString()
		{
			return string.Format("[{0}ms]", Elapsed);
		}
	}
}
