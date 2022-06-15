using EveSharp.Core.Models.Dogma.Dynamic;

namespace EveSharp.Core.Models.Universe
{
	public struct TypeDetails
	{
		public float? capacity;
		public string description;
		public Dogma.Dynamic.Attribute[] dogmaAttributes;
		public Effect[] dogmaEffects;
		public int? graphicId;
		public int groupId;
		public int? iconId;
		public int? marketGroupId;
		public float? mass;
		public string name;
		public float? packagedVolume;
		public int? portionSize;
		public bool published;
		public float? radius;
		public int typeId;
		public float? volume;
	}
	
	public struct SoATypeDetails
	{
		public readonly float?[] capacities;
		public readonly string[] descriptions;
		public readonly SoAAttribute[] dogmaAttributes;
		public readonly SoAEffect[] dogmaEffects;
		public readonly int?[] graphicIds;
		public readonly int[] groupIds;
		public readonly int?[] iconIds;
		public readonly int?[] marketGroupIds;
		public readonly float?[] masses;
		public readonly string[] names;
		public readonly float?[] packagedVolumes;
		public readonly int?[] portionSizes;
		public readonly bool[] publisheds;
		public readonly float?[] radii;
		public readonly int[] typeIds;
		public readonly float?[] volumes;
		
		public SoATypeDetails(params TypeDetails[] typeDetails)
		{
			int count = typeDetails.Length;
			capacities = new float?[count];
			descriptions = new string[count];
			dogmaAttributes = new SoAAttribute[count];
			dogmaEffects = new SoAEffect[count];
			graphicIds = new int?[count];
			groupIds = new int[count];
			iconIds = new int?[count];
			marketGroupIds = new int?[count];
			masses = new float?[count];
			names = new string[count];
			packagedVolumes = new float?[count];
			portionSizes = new int?[count];
			publisheds = new bool[count];
			radii = new float?[count];
			typeIds = new int[count];
			volumes = new float?[count];
			
			for (int i = 0; i < count; i++)
			{
				capacities[i] = typeDetails[i].capacity;
				descriptions[i] = typeDetails[i].description;
				dogmaAttributes[i] = new (typeDetails[i].dogmaAttributes);
				dogmaEffects[i] = new (typeDetails[i].dogmaEffects);
				graphicIds[i] = typeDetails[i].graphicId;
				groupIds[i] = typeDetails[i].groupId;
				iconIds[i] = typeDetails[i].iconId;
				marketGroupIds[i] = typeDetails[i].marketGroupId;
				masses[i] = typeDetails[i].mass;
				names[i] = typeDetails[i].name;
				packagedVolumes[i] = typeDetails[i].packagedVolume;
				portionSizes[i] = typeDetails[i].portionSize;
				publisheds[i] = typeDetails[i].published;
				radii[i] = typeDetails[i].radius;
				typeIds[i] = typeDetails[i].typeId;
				volumes[i] = typeDetails[i].volume;
			}
		}
	}
}