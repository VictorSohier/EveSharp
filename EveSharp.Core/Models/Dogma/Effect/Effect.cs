namespace EveSharp.Core.Models.Dogma.Effect
{
	public struct Effect
	{
		public string description;
		public bool? disallowAutoRepeat;
		public int? dischargeAttributeId;
		public string displayName;
		public int? durationAttributeId;
		public int? effectCategory;
		public int effectId;
		public bool? electronicChance;
		public int? falloffAttributeId;
		public int? iconId;
		public bool? isAssistance;
		public bool? isOffensive;
		public bool? isWarpSafe;
		public Modifier[] modifiers;
		public string name;
		public int? postExpression;
		public int? preExpression;
		public bool? published;
		public int? rangeAttributeId;
		public bool? rangeChance;
		public int? trackingSpeedAttributeId;
	}
	
	public struct SoAEffect
	{
		public readonly string[] descriptions;
		public readonly bool?[] disallowAutoRepeats;
		public readonly int?[] dischargeAttributeIds;
		public readonly string[] displayNames;
		public readonly int?[] durationAttributeIds;
		public readonly int?[] effectCategorys;
		public readonly int[] effectIds;
		public readonly bool?[] electronicChances;
		public readonly int?[] falloffAttributeIds;
		public readonly int?[] iconIds;
		public readonly bool?[] isAssistances;
		public readonly bool?[] isOffensives;
		public readonly bool?[] isWarpSafes;
		public readonly SoAModifier[] modifiers;
		public readonly string[] names;
		public readonly int?[] postExpressions;
		public readonly int?[] preExpressions;
		public readonly bool?[] publisheds;
		public readonly int?[] rangeAttributeIds;
		public readonly bool?[] rangeChances;
		public readonly int?[] trackingSpeedAttributeIds;
		
		public SoAEffect(params Effect[] effects)
		{
			int count = effects.Length;
			descriptions = new string[count];
			disallowAutoRepeats = new bool?[count];
			dischargeAttributeIds = new int?[count];
			displayNames = new string[count];
			durationAttributeIds = new int?[count];
			effectCategorys = new int?[count];
			effectIds = new int[count];
			electronicChances = new bool?[count];
			falloffAttributeIds = new int?[count];
			iconIds = new int?[count];
			isAssistances = new bool?[count];
			isOffensives = new bool?[count];
			isWarpSafes = new bool?[count];
			modifiers = new SoAModifier[count];
			names = new string[count];
			postExpressions = new int?[count];
			preExpressions = new int?[count];
			publisheds = new bool?[count];
			rangeAttributeIds = new int?[count];
			rangeChances = new bool?[count];
			trackingSpeedAttributeIds = new int?[count];
			
			for (int i = 0; i < count; i++)
			{
				descriptions[i] = effects[i].description;
				disallowAutoRepeats[i] = effects[i].disallowAutoRepeat;
				dischargeAttributeIds[i] = effects[i].dischargeAttributeId;
				displayNames[i] = effects[i].displayName;
				durationAttributeIds[i] = effects[i].durationAttributeId;
				effectCategorys[i] = effects[i].effectCategory;
				effectIds[i] = effects[i].effectId;
				electronicChances[i] = effects[i].electronicChance;
				falloffAttributeIds[i] = effects[i].falloffAttributeId;
				iconIds[i] = effects[i].iconId;
				isAssistances[i] = effects[i].isAssistance;
				isOffensives[i] = effects[i].isOffensive;
				isWarpSafes[i] = effects[i].isWarpSafe;
				modifiers[i] = new SoAModifier(effects[i].modifiers);
				names[i] = effects[i].name;
				postExpressions[i] = effects[i].postExpression;
				preExpressions[i] = effects[i].preExpression;
				publisheds[i] = effects[i].published;
				rangeAttributeIds[i] = effects[i].rangeAttributeId;
				rangeChances[i] = effects[i].rangeChance;
				trackingSpeedAttributeIds[i] = effects[i].trackingSpeedAttributeId;
			}
		}
	}
}