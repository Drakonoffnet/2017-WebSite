using System;
using AutoMapper;
using TeamSpark.AzureDay.WebSite.App.Entity;
using TeamSpark.AzureDay.WebSite.App.Service;

namespace TeamSpark.AzureDay.WebSite.App
{
	public static class AppFactory
	{
		public static readonly Lazy<IMapper> Mapper = new Lazy<IMapper>(() =>
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<Attendee, Data.Entity.Table.Attendee>();
				cfg.CreateMap<Data.Entity.Table.Attendee, Attendee>();

				cfg.CreateMap<QuickAuthToken, Data.Entity.Table.QuickAuthToken>();
				cfg.CreateMap<Data.Entity.Table.QuickAuthToken, QuickAuthToken>();

				cfg.CreateMap<Coupon, Data.Entity.Table.Coupon>();
				cfg.CreateMap<Data.Entity.Table.Coupon, Coupon>();

				cfg.CreateMap<Ticket, Data.Entity.Table.Ticket>();
				cfg.CreateMap<Data.Entity.Table.Ticket, Ticket>();
			});

			var mapper = config.CreateMapper();

			return mapper;
		});

		public static readonly Lazy<AttendeeService> AttendeeService = new Lazy<AttendeeService>(() => new AttendeeService());
		public static readonly Lazy<QuickAuthTokenService> QuickAuthTokenService = new Lazy<QuickAuthTokenService>(() => new QuickAuthTokenService());
		public static readonly Lazy<CouponService> CouponService = new Lazy<CouponService>(() => new CouponService());
		public static readonly Lazy<TicketService> TicketService = new Lazy<TicketService>(() => new TicketService());
	}
}
