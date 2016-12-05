using System;
namespace CSUnit
{
	public class ResultCollector
	{
		private int runCnt = 0;
		private int successCnt = 0;
		private int failureCnt = 0;
		private int errorCnt = 0;
		protected StopWatch stopWatch = new StopWatch();

		public ResultCollector()
		{
		}

		public virtual void Start(Object test)
		{
			this.runCnt++;
			stopWatch.Start();
		}

		public virtual void AddSuccess(Object test)
		{
			this.successCnt++;
			stopWatch.Stop();
		}

		public virtual void AddFailure(Object test, Exception e)
		{
			this.failureCnt++;
			stopWatch.Stop();
		}

		public virtual void AddError(Object test, Exception e)
		{
			this.errorCnt++;
			stopWatch.Stop();
		}

		public int RunCnt
		{
			get { return runCnt;}
		}
		public int SuccessCnt
		{
			get { return successCnt; }
		}
		public int FailureCnt
		{
			get { return failureCnt; }
		}
		public int ErrorCnt
		{
			get { return errorCnt; }
		}

		public bool WasSuccessful()
		{
			return failureCnt == 0 && errorCnt == 0;
		}
	}
}
