using System;
using System.Reflection;

/*
 * Lightweight Unit Test.
 * 
 */
namespace CSUnit
{
	
	class MainClass
	{
		public static void Main(string[] args)
		{
			UnitSuite suite = new UnitSuite("ezero9");
			suite.Add(new CalculatorTest());
			ConsoleRunner runner = new ConsoleRunner(suite);
			runner.Run();
		}

	}
}