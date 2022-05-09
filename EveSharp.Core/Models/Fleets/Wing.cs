namespace EveSharp.Core.Models.Fleets
{
	public struct Wing
	{
		public long id;
		public string name;
		public Squad[] squads;
	}
	
	public struct SoAWing
	{
		public readonly long[] ids;
		public readonly string[] names;
		public readonly SoASquad[] squads;
		
		public SoAWing(params Wing[] wings)
		{
			int count = wings.Length;
			ids = new long[count];
			names = new string[count];
			squads = new SoASquad[count];
			
			for (int i = 0; i < count; i++)
			{
				ids[i] = wings[i].id;
				names[i] = wings[i].name;
				squads[i] = new(wings[i].squads);
			}
		}
	}
}