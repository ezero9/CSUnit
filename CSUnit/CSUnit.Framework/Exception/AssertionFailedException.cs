﻿using System;
namespace CSUnit
{
	public class AssertionFailedException : Exception
	{
		public AssertionFailedException(string message) : base(message)
		{
		}
	}
}
