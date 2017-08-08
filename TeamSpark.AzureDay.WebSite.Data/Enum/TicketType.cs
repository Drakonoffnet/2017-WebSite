using System;

namespace TeamSpark.AzureDay.WebSite.Data.Enum
{
	[Flags]
	public enum TicketType
	{
		None = 0,
		Regular = 2,
		Workshop = 4
	}
}
