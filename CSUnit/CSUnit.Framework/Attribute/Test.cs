using System;
namespace CSUnit
{
	[AttributeUsage(AttributeTargets.Method)]
	public class Test : Attribute
	{
		public Test()
		{
		}
	}
}
