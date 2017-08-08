using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace TeamSpark.AzureDay.WebSite.Host.Controllers.Api
{
	public class ScheduleController : ApiController
	{
		[HttpPut]
		[Route("api/schedule/my/{topicId}")]
		public async Task<bool> SetTimeslot(
			[FromUri] int topicId)
		{
			throw new NotImplementedException();
		}
	}
}
