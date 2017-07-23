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
	}
}
