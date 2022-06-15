using Ardalis.SmartEnum;

namespace EveSharp.Infrastructure.Enums
{
	public class Permissions : SmartEnum<Permissions, string>
	{
		public static readonly Permissions READ_ALLIANCES_CONTACTS = new("Read Alliance Contacts", "esi-alliances.read_contacts.v1");
		public static readonly Permissions READ_CHARACTER_ASSETS = new("Read Character Assets", "esi-assets.read_assets.v1");
		public static readonly Permissions READ_CORPORATION_ASSETS = new("Read Corporation Assets", "esi-assets.read_corporation_assets.v1");
		public static readonly Permissions READ_CHARACTER_BOOKMARKS = new("Read Character Bookmarks", "esi-bookmarks.read_character_bookmarks.v1");
		public static readonly Permissions READ_CORPORATION_BOOKMARKS = new("Read Corporation Bookmarks", "esi-bookmarks.read_corporation_bookmarks.v1");
		public static readonly Permissions READ_CALENDAR_EVENTS = new("Read Calendar Events", "esi-calendar.read_calendar_events.v1");
		public static readonly Permissions RESPOND_CALENDAR_EVENTS = new("Respond Calendar Events", "esi-calendar.respond_calendar_events.v1");
		public static readonly Permissions READ_CHARACTER_AGENTS = new("Read Agents Research", "esi-characters.read_agents_research.v1");
		public static readonly Permissions READ_CHARACTER_BLUEPRINTS = new("Read Character Blueprints", "esi-characters.read_blueprints.v1");
		public static readonly Permissions READ_CHARACTER_CONTACTS = new("Read Character Contacts", "esi-characters.read_contacts.v1");
		public static readonly Permissions READ_CHARACTER_CORPORATION_ROLES = new("Read Corporation Roles", "esi-characters.read_corporation_roles.v1");
		public static readonly Permissions READ_CHARACTER_FATIGUE = new("Read Character Jump Fatigue", "esi-characters.read_fatigue.v1");
		public static readonly Permissions READ_CHARACTER_FW_STATS = new("Read Character Faction Warfare Stats", "esi-characters.read_fw_stats.v1");
		public static readonly Permissions READ_LOYALTY_POINTS = new("Read Character Loyalty Points", "esi-characters.read_loyalty.v1");
		public static readonly Permissions READ_CHARACTER_MEDALS = new("Read Character Medals", "esi-characters.read_medals.v1");
		public static readonly Permissions READ_CHARACTER_NOTIFICATIONS = new("Read Character Notifications", "esi-characters.read_notifications.v1");
		public static readonly Permissions READ_CHARACTER_OPPORTUNITIES = new("Read Character Opportunities", "esi-characters.read_opportunities.v1");
		public static readonly Permissions READ_CHARACTER_STANDINGS = new("Read Character Standings", "esi-characters.read_standings.v1");
		public static readonly Permissions READ_CHARACTER_TITLES = new("Read Character Titles", "esi-characters.read_titles.v1");
		public static readonly Permissions WRITE_CHARACTER_CONTACTS = new("Write Character Contacts", "esi-characters.write_contacts.v1");
		public static readonly Permissions READ_CHARACTER_CLONES = new("Read Character Clones", "esi-clones.read_clones.v1");
		public static readonly Permissions READ_CHARACTER_IMPLANTS = new("Read Character Implants", "esi-clones.read_implants.v1");
		public static readonly Permissions READ_CHARACTER_CONTRACTS = new("Read Character Contracts", "esi-contracts.read_character_contracts.v1");
		public static readonly Permissions READ_CORPORATION_CONTRACTS = new("Read Corporation Contracts", "esi-contracts.read_corporation_contracts.v1");
		public static readonly Permissions READ_CORPORATION_BLUEPRINTS = new("Read Corporation Blueprints", "esi-corporations.read_blueprints.v1");
		public static readonly Permissions READ_CORPORATION_CONTACTS = new("Read Corporation Contacts", "esi-corporations.read_contacts.v1");
		public static readonly Permissions READ_CORPORATION_CONTAINER_LOGS = new("Read Corporation Container Logs", "esi-corporations.read_container_logs.v1");
		public static readonly Permissions READ_CORPORATION_MEMBERSHIP = new("Read Corporation Membership", "esi-corporations.read_corporation_membership.v1");
		public static readonly Permissions READ_CORPORATION_DIVISIONS = new("Read Corporation Divisions", "esi-corporations.read_divisions.v1");
		public static readonly Permissions READ_CORPORATION_FACILITIES = new("Read Corporation Facilities", "esi-corporations.read_facilities.v1");
		public static readonly Permissions READ_CORPORATION_FW_STATS = new("Read Corporation Faction Warfare Stats", "esi-corporations.read_fw_stats.v1");
		public static readonly Permissions READ_CORPORATION_MEDALS = new("Read Corporation Medals", "esi-corporations.read_medals.v1");
		public static readonly Permissions READ_CORPORATION_STANDINGS = new("Read Corporation Standings", "esi-corporations.read_standings.v1");
		public static readonly Permissions READ_CORPORATION_STARBASES = new("Read Corporation Starbases", "esi-corporations.read_starbases.v1");
		public static readonly Permissions READ_CORPORATION_STRUCTURES = new("Read Corporation Structures", "esi-corporations.read_structures.v1");
		public static readonly Permissions READ_CORPORATION_TITLES = new("Read Corporation Titles", "esi-corporations.read_titles.v1");
		public static readonly Permissions READ_CORPORATION_TRACK_MEMBERS = new("Read Corporation Track Members", "esi-corporations.track_members.v1");
		public static readonly Permissions READ_FITTINGS = new("Read fittings", "esi-fittings.read_fittings.v1");
		public static readonly Permissions WRITE_FITTINGS = new("Write fittings", "esi-fittings.write_fittings.v1");
		public static readonly Permissions READ_FLEET = new("Read fleet", "esi-fleets.read_fleet.v1");
		public static readonly Permissions WRITE_FLEET = new("Write fleet", "esi-fleets.write_fleet.v1");
		public static readonly Permissions READ_CHARACTER_INDUSTRY_JOBS = new("Character Industry Jobs", "esi-industry.read_character_jobs.v1");
		public static readonly Permissions READ_CHARACTER_INDUSTRY_MINING = new("Character Industry Mining", "esi-industry.read_character_mining.v1");
		public static readonly Permissions READ_CORPORATION_INDUSTRY_JOBS = new("Corporation Industry Jobs", "esi-industry.read_corporation_jobs.v1");
		public static readonly Permissions READ_CORPORATION_INDUSTRY_MINING = new("Corporation Industry Mining", "esi-industry.read_corporation_mining.v1");
		public static readonly Permissions READ_CHARACTER_KILLMAILS = new("Read Character Killmails", "esi-killmails.read_killmails.v1");
		public static readonly Permissions READ_CORPORATION_KILLMAILS = new("Read Corporation Killmails", "esi-killmails.read_corporation_killmails.v1");
		public static readonly Permissions READ_LOCATION = new("Read Location", "esi-location.read_location.v1");
		public static readonly Permissions READ_ONLINE = new("Read Online", "esi-location.read_online.v1");
		public static readonly Permissions READ_SHIP_TYPE = new("Read Ship Type", "esi-location.read_ship_type.v1");
		public static readonly Permissions ORGANIZE_MAIL = new("Organize Mail", "esi-mail.organize_mail.v1");
		public static readonly Permissions READ_MAIL = new("Read Mail", "esi-mail.read_mail.v1");
		public static readonly Permissions SEND_MAIL = new("Send Mail", "esi-mail.send_mail.v1");
		public static readonly Permissions READ_CHARACTER_ORDERS = new("Read Character Orders", "esi-markets.read_character_orders.v1");
		public static readonly Permissions READ_CORPORATION_ORDERS = new("Read Corporation Orders", "esi-markets.read_corporation_orders.v1");
		public static readonly Permissions READ_STRUCTURE_MARKETS = new("Read Structure Markets", "esi-markets.structure_markets.v1");
		public static readonly Permissions MANAGE_PLANETS = new("Manage Planets", "esi-planets.manage_planets.v1");
		public static readonly Permissions READ_CUSTOMS_OFFICES = new("Read Customs Offices", "esi-planets.read_customs_offices.v1");
		public static readonly Permissions SEARCH_STRUCTURES = new("Search Structures", "esi-search.search_structures.v1");
		public static readonly Permissions READ_SKILLQUEUE = new("Read Skillqueue", "esi-skills.read_skillqueue.v1");
		public static readonly Permissions READ_SKILLS = new("Read Skills", "esi-skills.read_skills.v1");
		public static readonly Permissions UI_OPEN_WINDOW = new("Open Window", "esi-ui.open_window.v1");
		public static readonly Permissions UI_WRITE_WAYPOINT = new("Write Waypoint", "esi-ui.write_waypoint.v1");
		public static readonly Permissions READ_STRUCTURES = new("Read Structures", "esi-universe.read_structures.v1");
		public static readonly Permissions READ_CHARACTER_WALLET = new("Read Character Wallet", "esi-wallet.read_character_wallet.v1");
		public static readonly Permissions READ_CORPORATION_WALLET = new("Read Corporation Wallet", "esi-wallet.read_corporation_wallets.v1");
		
		private Permissions(string name, string value) : base(name, value)
		{
			
		}
		
		private Permissions(string name) : base(name, name)
		{
			
		}
	}
	
	public struct PermissionsSOA
	{
		public readonly string[] names;
		public readonly string[] values;
		
		public PermissionsSOA(Permissions[] permissions)
		{
			names = new string[permissions.Length];
			values = new string[permissions.Length];
			
			for (int i = 0; i < permissions.Length; i++)
			{
				names[i] = permissions[i].Name;
				values[i] = permissions[i].Value;
			}
		}
	}
}