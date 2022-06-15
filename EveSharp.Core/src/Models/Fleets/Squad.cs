namespace EveSharp.Core.Models.Fleets
{
	public struct Squad
	{
		public long id;
		public string name;
	}
	
	public struct SoASquad
	{
		public readonly long[] ids;
		public readonly string[] names;
		
		public SoASquad(params Squad[] squads)
		{
			int count = squads.Length;
			ids = new long[count];
			names = new string[count];
			
			for (int i = 0;i < count; i++)
			{
				ids[i] = squads[i].id;
				names[i] = squads[i].name;
			}
		}
	}
}