using System;
namespace CSUnit
{
	[AttributeUsage(AttributeTargets.Method)]
	public class Before : Attribute
	{
		public Before()
		{
		}
	}
}
