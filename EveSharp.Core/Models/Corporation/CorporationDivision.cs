namespace EveSharp.Core.Models.Corporation
{
	public struct CorporationDivision
	{
		public int? division;
		public string name;
	}
	
	public struct SoACorporationDivision
	{
		public int?[] divisions;
		public string[] names;
		
		public SoACorporationDivision(params CorporationDivision[] corporationDivisions)
		{
			int count = corporationDivisions.Length;
			divisions = new int?[count];
			names = new string[count];
			
			for (int i = 0; i < count; i++)
			{
				divisions[i] = corporationDivisions[i].division;
				names[i] = corporationDivisions[i].name;
			}
		}
	}
}