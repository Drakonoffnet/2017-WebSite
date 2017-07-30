using System.Linq;

namespace TeamSpark.AzureDay.WebSite.App.Entity
{
	public class Topic
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public Language Language { get; set; }

		public Speaker Speaker { get; set; }

		private Timetable _timetable;

		public Timetable Timetable
		{
			get
			{
				if (_timetable == null)
				{
					_timetable = AppFactory.TimetableService.Value.GetTimetable()
						.Where(x => x.Topic != null)
						.SingleOrDefault(x => x.Topic.Id == Id);
				}
				return _timetable;
			}
		}

		public Topic()
		{
			Language = new Language();
			Speaker = new Speaker();
		}
	}
}
