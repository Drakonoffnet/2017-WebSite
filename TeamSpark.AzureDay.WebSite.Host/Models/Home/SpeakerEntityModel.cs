using System.Collections.Generic;
using TeamSpark.AzureDay.WebSite.App.Entity;

namespace TeamSpark.AzureDay.WebSite.Host.Models.Home
{
	public sealed class SpeakerEntityModel
	{
		public Speaker Speaker { get; set; }
		public List<Workshop> Workshops { get; set; }
		public List<Topic> Topics { get; set; }
	}
}