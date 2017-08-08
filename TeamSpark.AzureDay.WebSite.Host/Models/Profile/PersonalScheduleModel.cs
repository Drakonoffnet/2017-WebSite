using System.Collections.Generic;
using TeamSpark.AzureDay.WebSite.App.Entity;
using TeamSpark.AzureDay.WebSite.Host.Models.Home;

namespace TeamSpark.AzureDay.WebSite.Host.Models.Profile
{
	public sealed class PersonalScheduleModel : ScheduleModel
	{
		public List<KeyValuePair<int, bool>> PersonalSchedule;
	}
}