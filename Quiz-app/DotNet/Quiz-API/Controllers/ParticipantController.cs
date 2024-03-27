using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz_API.Models;
using Quiz_API.Models.Data;

namespace Quiz_API.Controllers
{
	public class ParticipantController : ControllerBase
	{
		private readonly QuizDbcontext db;
        public ParticipantController(QuizDbcontext _db)
        {
            db = _db;
        }

        [Route("api/InsertParticipant")]
		[HttpPost]
		public async Task<Participant> Insert( [FromBody]Participant model)
		{
			await db.participant.AddAsync(model);
			await db.SaveChangesAsync();
			return model;

		}
		[HttpPost]
		[Route("api/UpdateOutput")]
		public void UpdateOutput([FromBody]Participant model)
		{
			db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			db.SaveChanges();
		}
	}
}
