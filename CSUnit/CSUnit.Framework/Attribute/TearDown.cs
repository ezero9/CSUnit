using System;
namespace CSUnit
{
	[AttributeUsage(AttributeTargets.Method)]
	public class TearDown : Attribute
	{
		public TearDown()
		{
		}
	}
}
