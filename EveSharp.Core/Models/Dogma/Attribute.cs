using System.Runtime.InteropServices;

namespace EveSharp.Core.Models.Dogma
{
	public struct Attribute
	{
		public int AttributeId;
		public float? DefaultValue;
		public string Description;
		public string DisplayName;
		public bool? HighIsGood;
		public int? IconId;
		public string Name;
		public bool? Published;
		public bool? Stackable;
		public int? UnitId;
	}
}