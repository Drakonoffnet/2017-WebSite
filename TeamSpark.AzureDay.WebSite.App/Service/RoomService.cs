using System.Collections.Generic;
using System.Linq;
using TeamSpark.AzureDay.WebSite.App.Entity;
using TeamSpark.AzureDay.WebSite.Data.Enum;

namespace TeamSpark.AzureDay.WebSite.App.Service
{
	public sealed class RoomService
	{
		private readonly List<Room> _rooms = new List<Room>
		{
			new Room {Id = 1, ColorNumber = 1, RoomType = RoomType.LectureRoom, Title = Localization.App.Service.Room.WebDev },
			new Room {Id = 2, ColorNumber = 2, RoomType = RoomType.LectureRoom, Title = Localization.App.Service.Room.IoT },
			new Room {Id = 3, ColorNumber = 3, RoomType = RoomType.LectureRoom, Title = Localization.App.Service.Room.AInML },
			new Room {Id = 4, ColorNumber = 4, RoomType = RoomType.LectureRoom, Title = Localization.App.Service.Room.DevOps },
			new Room {Id = 5, ColorNumber = 5, RoomType = RoomType.LectureRoom, Title = Localization.App.Service.Room.ITPro },

			new Room {Id = 101, ColorNumber = 1, RoomType = RoomType.WorkshopRoom, Title = Localization.App.Service.Room.Workshop1 },
			new Room {Id = 102, ColorNumber = 2, RoomType = RoomType.WorkshopRoom, Title = Localization.App.Service.Room.Workshop2 },
			new Room {Id = 103, ColorNumber = 3, RoomType = RoomType.WorkshopRoom, Title = Localization.App.Service.Room.Workshop3 },
			new Room {Id = 104, ColorNumber = 4, RoomType = RoomType.WorkshopRoom, Title = Localization.App.Service.Room.Workshop4 },
			new Room {Id = 105, ColorNumber = 5, RoomType = RoomType.WorkshopRoom, Title = Localization.App.Service.Room.Workshop5 },
			new Room {Id = 106, ColorNumber = 6, RoomType = RoomType.WorkshopRoom, Title = Localization.App.Service.Room.Workshop6 },

			new Room {Id = 999, ColorNumber = 0, RoomType = RoomType.CoffeeRoom }
		};

		public IEnumerable<Room> GetRooms()
		{
			return _rooms;
		}

		public Room CoffeeBreak { get { return _rooms.Single(x => x.Id == 999); } }

		public Room Room1 { get { return _rooms.Single(x => x.Id == 1); } }
		public Room Room2 { get { return _rooms.Single(x => x.Id == 2); } }
		public Room Room3 { get { return _rooms.Single(x => x.Id == 3); } }
		public Room Room4 { get { return _rooms.Single(x => x.Id == 4); } }
		public Room Room5 { get { return _rooms.Single(x => x.Id == 5); } }

		public Room Workshop1 { get { return _rooms.Single(x => x.Id == 101); } }
		public Room Workshop2 { get { return _rooms.Single(x => x.Id == 102); } }
		public Room Workshop3 { get { return _rooms.Single(x => x.Id == 103); } }
		public Room Workshop4 { get { return _rooms.Single(x => x.Id == 104); } }
		public Room Workshop5 { get { return _rooms.Single(x => x.Id == 105); } }
		public Room Workshop6 { get { return _rooms.Single(x => x.Id == 106); } }
	}
}
