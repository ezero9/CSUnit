using System;
using System.Reflection;
namespace CSUnit
{
	public class ConsoleResultCollector : ResultCollector
	{
		public ConsoleResultCollector() : base()
		{
		}

		public override void Start(Object test) 
		{
			base.Start(test);
			Console.Write("Run {0}", ((MethodInfo)test).Name);
		}

		public override void AddSuccess(Object test)
		{
			base.AddSuccess(test);
			Console.WriteLine(" {0} - SUCCESS", stopWatch);
		}

		public override void AddFailure(Object test, Exception e)
		{
			base.AddFailure(test, e);
			Console.WriteLine(" {0} - FAIL", stopWatch);
			Console.WriteLine("{0}", e.StackTrace);
		}

		public override void AddError(Object test, Exception e)
		{
			base.AddError(test, e);
			Console.WriteLine(" {0} - ERROR", stopWatch);
			Console.WriteLine("{0}", e.StackTrace);
		}
	}
}
