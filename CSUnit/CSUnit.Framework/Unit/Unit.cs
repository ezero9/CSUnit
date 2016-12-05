/*
 * composite 
 */
namespace CSUnit
{
	public abstract class Unit
	{
		private readonly string name;

		public Unit() 
		{
			this.name = GetType().Name;
		}
		public Unit(string name)
		{
			this.name = name;
		}
		public string Name
		{
			get { return this.name; }
		}
		public abstract void Run(ResultCollector collector);
		public abstract int GetCounts();
	}
}
