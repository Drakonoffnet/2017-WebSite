namespace TeamSpark.AzureDay.WebSite.App.Entity
{
	public class Workshop
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public Language Language { get; set; }
		public Room Room { get; set; }

		public Speaker Speaker { get; set; }

		public Workshop()
		{
			Language = new Language();
			Room = new Room();
			Speaker = new Speaker();
		}
	}
}
