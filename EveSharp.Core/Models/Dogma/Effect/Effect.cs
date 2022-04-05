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
}