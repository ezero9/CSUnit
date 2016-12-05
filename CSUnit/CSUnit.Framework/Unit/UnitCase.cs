using System;
using System.Reflection;
using System.Collections.Generic;
using CSUnit.CSUnitExtension;

namespace CSUnit
{
	public class UnitCase : Unit
	{
		private List<MethodInfo> testList = new List<MethodInfo>();
		private MethodInfo setUp = null;
		private MethodInfo tearDwon = null;
		private MethodInfo before = null;
		private MethodInfo after = null;

		public UnitCase() : base()
		{
			this.ExtractInformation();
		}

		public UnitCase(string name) : base(name)
		{
			this.ExtractInformation();
		}

		private void ExtractInformation()
		{
			foreach (MethodInfo method in this.GetType().GetMethods())
			{
				this.ExtractTest(method);
				this.ExtractSetUp(method);
				this.ExtractTearDown(method);
				this.ExtractBefore(method);
				this.ExtractAfter(method);
			}
		}

		public override void Run(ResultCollector collector)
		{
			this.setUp.ProtectedInvoke(this);
			this.RunsEachTest(collector);
			this.tearDwon.ProtectedInvoke(this);
		}

		private void RunsEachTest(ResultCollector collector)
		{
			foreach (MethodInfo test in testList)
			{
				try
				{
					this.before.ProtectedInvoke(this);
					collector.Start(test);
					test.Invoke(this, null);
					collector.AddSuccess(test);
					this.after.ProtectedInvoke(this);
				}
				catch (TargetInvocationException e)
				{
					if (e.InnerException is AssertionFailedException)
					{
						collector.AddFailure(test, e);
					}
					else
					{
						collector.AddError(test, e);
					}
				}
			}
		}

		public override int GetCounts()
		{
			return this.testList.Count;
		}

		public static void Assert(bool condition)
		{
			Assert(condition, "");
		}

		public static void Assert(bool condition, string message)
		{
			if (!condition)
				throw new AssertionFailedException(message);
		}

		public static void AssertEquals(int a, int b)
		{
			if (a != b)
				Assert(false);
		}

		public static void AssertEquals(string a, string b)
		{
			if (!a.Equals(b))
				Assert(false);
		}

		public static void AssertEquals(object a, object b)
		{
			if (!a.Equals(b))
				Assert(false);
		}

		public static void AssertSame(object a, object b)
		{
			if (a != b)
				Assert(false);
		}

		public static void AssertNotNull(object a, object b)
		{
			if (a != b)
				Assert(false);
		}

		private void ExtractTest(MethodInfo method)
		{
			if (method.HasCustomAttribute(typeof(Test)))
				this.testList.Add(method);
		}

		private void ExtractSetUp(MethodInfo method)
		{
			if (method.HasCustomAttribute(typeof(SetUp)))
				this.setUp = method;
		}

		private void ExtractTearDown(MethodInfo method)
		{
			if (method.HasCustomAttribute(typeof(TearDown)))
				this.tearDwon = method;
		}

		private void ExtractBefore(MethodInfo method)
		{
			if (method.HasCustomAttribute(typeof(Before)))
				this.before = method;
		}

		private void ExtractAfter(MethodInfo method)
		{
			if (method.HasCustomAttribute(typeof(After)))
				this.after = method;
		}
	}

	namespace CSUnitExtension
	{
		public static class MethodInfoExtension
		{
			public static bool HasCustomAttribute(this MethodInfo method, Type type)
			{
				return method.GetCustomAttribute(type, true) != null;
			}
			public static void ProtectedInvoke(this MethodInfo method, object obj)
			{
				if (method != null)
					method.Invoke(obj, null);
			}
		}
	}
}