using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSpark.AzureDay.WebSite.App.Entity;
using TeamSpark.AzureDay.WebSite.Config;
using TeamSpark.AzureDay.WebSite.Data;
using TeamSpark.AzureDay.WebSite.Data.Enum;

namespace TeamSpark.AzureDay.WebSite.App.Service
{
	public sealed class TimetableService
	{
		private Dictionary<int, List<Timetable>> _timetables = new Dictionary<int, List<Timetable>>
		{
			{ 999, new List<Timetable>
				{
					new Timetable { TimeStart = "8:15", TimeEnd = "9:00" },
					new Timetable { TimeStart = "10:15", TimeEnd = "10:30" },
					new Timetable { TimeStart = "11:30", TimeEnd = "12:00" },
					new Timetable { TimeStart = "13:00", TimeEnd = "13:15" },
					new Timetable { TimeStart = "14:15", TimeEnd = "14:45" },
					new Timetable { TimeStart = "15:45", TimeEnd = "16:00" },
					new Timetable { TimeStart = "17:00", TimeEnd = "17:30" }
				}
			},
			{ 1, new List<Timetable>
				{
					new Timetable { TimeStart = "9:00", TimeEnd = "10:15" },
					new Timetable { TimeStart = "10:30", TimeEnd = "11:30" },
					new Timetable { TimeStart = "12:00", TimeEnd = "13:00" },
					new Timetable { TimeStart = "13:15", TimeEnd = "14:15" },
					new Timetable { TimeStart = "14:45", TimeEnd = "15:45" },
					new Timetable { TimeStart = "16:00", TimeEnd = "17:00" },
					new Timetable { TimeStart = "17:30", TimeEnd = "18:30" }
				}
			},
			{ 2, new List<Timetable>
				{
					new Timetable { TimeStart = "10:30", TimeEnd = "11:30" },
					new Timetable { TimeStart = "12:00", TimeEnd = "13:00" },
					new Timetable { TimeStart = "13:15", TimeEnd = "14:15" },
					new Timetable { TimeStart = "14:45", TimeEnd = "15:45" },
					new Timetable { TimeStart = "16:00", TimeEnd = "17:00" },
					new Timetable { TimeStart = "17:30", TimeEnd = "18:30" }
				}
			},
			{ 3, new List<Timetable>
				{
					new Timetable { TimeStart = "10:30", TimeEnd = "11:30" },
					new Timetable { TimeStart = "12:00", TimeEnd = "13:00" },
					new Timetable { TimeStart = "13:15", TimeEnd = "14:15" },
					new Timetable { TimeStart = "14:45", TimeEnd = "15:45" },
					new Timetable { TimeStart = "16:00", TimeEnd = "17:00" },
					new Timetable { TimeStart = "17:30", TimeEnd = "18:30" }
				}
			},
			{ 4, new List<Timetable>
				{
					new Timetable { TimeStart = "10:30", TimeEnd = "11:30" },
					new Timetable { TimeStart = "12:00", TimeEnd = "13:00" },
					new Timetable { TimeStart = "13:15", TimeEnd = "14:15" },
					new Timetable { TimeStart = "14:45", TimeEnd = "15:45" },
					new Timetable { TimeStart = "16:00", TimeEnd = "17:00" },
					new Timetable { TimeStart = "17:30", TimeEnd = "18:30" }
				}
			},
			{ 5, new List<Timetable>
				{
					new Timetable { TimeStart = "10:30", TimeEnd = "11:30" },
					new Timetable { TimeStart = "12:00", TimeEnd = "13:00" },
					new Timetable { TimeStart = "13:15", TimeEnd = "14:15" },
					new Timetable { TimeStart = "14:45", TimeEnd = "15:45" },
					new Timetable { TimeStart = "16:00", TimeEnd = "17:00" },
					new Timetable { TimeStart = "17:30", TimeEnd = "18:30" }
				}
			}
		};

		public async Task<List<Timetable>> GetTimetableAsync()
		{
			var rooms = new RoomService().GetRooms();
			var languages = new LanguageService().GetLanguages();

			var topicsTask = DataFactory.TopicService.Value.GetByPartitionKeyAsync(Configuration.Year);

			await Task.WhenAll(
				topicsTask);

			var topics = topicsTask.Result
				.ToList();

			var speakers = new SpeakerService().GetSpeakers();

			var timetables = new List<Timetable>();

			foreach (var room in rooms)
			{
				var timetablesRoom = _timetables[room.Id];

				foreach (var timetableRoom in timetablesRoom)
				{
					var timetable = AppFactory.Mapper.Value.Map<Timetable>(timetableRoom);
					var topic = timetableRoom.Topic;
					var language = topic.Language;

					timetable.Room = room;
					timetable.Topic = AppFactory.Mapper.Value.Map<Topic>(topic);
					timetable.Topic.Language = AppFactory.Mapper.Value.Map<Language>(language);
					//timetable.Topic.Speaker = speakers.SingleOrDefault(s => s.Id == topic.SpeakerId);

					timetables.Add(timetable);
				}
			}

			return timetables
				.OrderBy(t => t.TimeStartHours)
				.ThenBy(t => t.TimeStartMinutes)
				.ThenBy(t => t.Room.RoomType.ToString())
				.ThenBy(t => t.Room.Title)
				.ToList();
		}
	}
}
