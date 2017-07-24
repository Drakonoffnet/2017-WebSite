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

	public static class TicketTypeExtension
	{
		public static string ToDisplayString(this TicketType ticketType)
		{
			switch (ticketType)
			{
				case TicketType.Regular:
					return "Regular";
				case TicketType.Workshop:
					return "Workshop";
			}

			return string.Empty;
		}
	}
}
