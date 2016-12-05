using System;
namespace CSUnit
{
	public class ConsoleRunner
	{
		UnitSuite suite;
		public ConsoleRunner(UnitSuite suite)
		{
			this.suite = suite;
		}

		public void Run()
		{
			Console.WriteLine("[START {0}]", suite.Name);
			ConsoleResultCollector collector = new ConsoleResultCollector();
			suite.Run(collector);
			Console.WriteLine("[RESULT {0} : {1}]", suite.Name, collector.WasSuccessful());
			Console.WriteLine("|-- Runs: {0}/{1}", suite.GetCounts(), collector.RunCnt);
			Console.WriteLine("|-- Errors: {0}", collector.ErrorCnt);
			Console.WriteLine("|-- Failures: {0}", collector.FailureCnt);
			Console.WriteLine("|_______________");
		}
	}
}
