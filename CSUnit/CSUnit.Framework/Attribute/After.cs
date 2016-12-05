using System;
namespace CSUnit
{
	[AttributeUsage(AttributeTargets.Method)]
	public class After : Attribute
	{
		public After()
		{
		}
	}
}
