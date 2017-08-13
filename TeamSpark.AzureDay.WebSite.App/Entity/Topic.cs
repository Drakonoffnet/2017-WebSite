using System;
using System.Collections.Generic;
using System.Linq;
using TeamSpark.AzureDay.WebSite.App.Service;

namespace TeamSpark.AzureDay.WebSite.App.Entity
{
	public class Topic
	{
		private readonly Lazy<TimetableService> _timetableService = new Lazy<TimetableService>(() => new TimetableService());

		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public Language Language { get; set; }

		public List<Speaker> Speakers { get; set; }

		private Timetable _timetable;

		public Timetable Timetable
		{
			get
			{
				if (_timetable == null)
				{
					_timetable = _timetableService.Value.GetTimetable()
						.Where(x => x.Topic != null)
						.SingleOrDefault(x => x.Topic.Id == Id);
				}
				return _timetable;
			}
		}

		public Topic()
		{
			Language = new Language();
			Speakers = new List<Speaker>();
		}
	}
}
