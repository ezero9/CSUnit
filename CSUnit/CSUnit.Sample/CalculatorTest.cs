using System;
namespace CSUnit
{
	public class CalculatorTest : UnitCase
	{
		[SetUp]
		public void SetUp()
		{
		}
		[TearDown]
		public void TearDown()
		{
		}
		[Before]
		public void Before()
		{
		}
		[After]
		public void After()
		{
		}
		[Test]
		public void SumTest()
		{
			Calculator calculator = new Calculator();
			AssertEquals(calculator.Sum(1, 1), 2);
		}
		[Test]
		public void MultiplyTest()
		{
			Calculator calculator = new Calculator();
			AssertEquals(calculator.Multiply(2, 2), 4);
		}
		[Test]
		public void DivideTest()
		{
			Calculator calculator = new Calculator();
			AssertEquals(calculator.Divide(10, 2), 10/2);
		}

	}
}
