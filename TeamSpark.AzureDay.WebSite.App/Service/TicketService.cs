using System;
using System.Threading.Tasks;
using TeamSpark.AzureDay.WebSite.App.Entity;
using TeamSpark.AzureDay.WebSite.Config;
using TeamSpark.AzureDay.WebSite.Data;
using TeamSpark.AzureDay.WebSite.Data.Enum;

namespace TeamSpark.AzureDay.WebSite.App.Service
{
	public sealed class TicketService
	{
		public decimal GetTicketPrice(TicketType ticketType)
		{
			switch (ticketType)
			{
				case TicketType.Regular:
					return Configuration.TicketRegular;
				case TicketType.Workshop:
					return Configuration.TicketWorkshop;
				case TicketType.Regular | TicketType.Workshop:
					return Configuration.TicketRegular + Configuration.TicketWorkshop;
			}

			throw new ArgumentOutOfRangeException(nameof(ticketType));
		}

		public async Task AddTicketAsync(Ticket ticket)
		{
			var data = AppFactory.Mapper.Value.Map<Data.Entity.Table.Ticket>(ticket);

			await DataFactory.TicketService.Value.InsertAsync(data);
		}

		public async Task SetTicketPayedAsync(string email)
		{
			var data = await DataFactory.TicketService.Value.GetByKeysAsync(Configuration.Year, email);

			if (data == null)
			{
				return;
			}

			data.IsPayed = true;
			await DataFactory.TicketService.Value.ReplaceAsync(data);
		}

		public async Task DeleteTicketAsync(string email)
		{
			var data = await DataFactory.TicketService.Value.GetByKeysAsync(Configuration.Year, email);

			await DataFactory.TicketService.Value.DeleteAsync(data);
		}

		public async Task<Ticket> GetTicketByEmailAsync(string email)
		{
			var data = await DataFactory.TicketService.Value.GetByKeysAsync(Configuration.Year, email);

			if (data == null)
			{
				return null;
			}

			var ticket = AppFactory.Mapper.Value.Map<Ticket>(data);

			return ticket;
		}
	}
}
