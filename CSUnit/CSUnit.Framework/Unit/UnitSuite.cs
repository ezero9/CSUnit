using System;
using System.Collections.Generic;
namespace CSUnit
{
	public class UnitSuite : Unit
	{
		private List<Unit> unitChildren = new List<Unit>();

		public UnitSuite() : base()
		{
		}

		public UnitSuite(string name) : base(name)
		{
		}

		public override void Run(ResultCollector collector)
		{
			foreach (Unit unit in unitChildren)
			{
				unit.Run(collector);
			}
		}

		public override int GetCounts()
		{
			int cnt = 0;
			foreach (Unit unit in unitChildren)
			{
				cnt += unit.GetCounts();
			}
			return cnt;
		}

		public void Add(Unit unit)
		{
			unitChildren.Add(unit);
		}
	}
}
