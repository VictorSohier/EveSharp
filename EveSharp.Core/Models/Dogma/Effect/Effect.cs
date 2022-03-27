namespace EveSharp.Core.Models.Dogma.Effect
{
	public struct Effect
	{
		public string Description;
		public bool? DisallowAutoRepeat;
		public int? DischargeAttributeId;
		public string DisplayName;
		public int? DurationAttributeId;
		public int? EffectCategory;
		public int EffectId;
		public bool? ElectronicChance;
		public int? FalloffAttributeId;
		public int? IconId;
		public bool? IsAssistance;
		public bool? IsOffensive;
		public bool? IsWarpSafe;
		public Modifier[] Modifiers;
		public string Name;
		public int? PostExpression;
		public int? PreExpression;
		public bool? Published;
		public int? RangeAttributeId;
		public bool? RangeChance;
		public int? TrackingSpeedAttributeId;
	}
}