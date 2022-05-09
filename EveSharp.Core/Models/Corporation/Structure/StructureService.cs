using EveSharp.Core.Enums.Corporation.Structure;

namespace EveSharp.Core.Models.Corporation.Structure
{
	public struct StructureService
	{
		public string name;
		public StructureServiceState state;
	}
	
	public struct SoAStructureService
	{
		public readonly string[] names;
		public readonly StructureServiceState[] states;
		
		public SoAStructureService(params StructureService[] structureServices)
		{
			int count = structureServices.Length;
			names = new string[count];
			states = new StructureServiceState[count];
			
			for (int i = 0; i < count; i++)
			{
				names[i] = structureServices[i].name;
				states[i] = structureServices[i].state;
			}
		}
	}
}