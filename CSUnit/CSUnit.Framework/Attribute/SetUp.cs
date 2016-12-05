using System;
namespace CSUnit
{
	[AttributeUsage(AttributeTargets.Method)]
	public class SetUp : Attribute
	{
		public SetUp()
		{
		}
	}
}
