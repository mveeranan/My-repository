using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz_API.Models.Data;
using System.Net;

namespace Quiz_API.Controllers
{

	public class QuizController : ControllerBase
	{
		private readonly QuizDbcontext db;
		public QuizController(QuizDbcontext _db)
		{
			db = _db;
		}
		[Route("api/Questions")]
		[HttpGet]
		public IActionResult GetQuestions()
		{
			var Qns = db.question.Select(x => new { QnID = x.QnID, Qn = x.Qn, ImageName = x.ImageName, x.Option1, x.Option2, x.Option3, x.Option4 })
				.OrderBy(y => Guid.NewGuid())
				.Take(10)
				.ToArray();
			var updated = Qns.AsEnumerable()
					.Select(x => new
					{
						QnID = x.QnID,
						Qn = x.Qn,
						ImageName = x.ImageName,
						Options = new string[] { x.Option1, x.Option2, x.Option3, x.Option4 }
					}).ToList();
				return Ok(updated);
		}
		[Route("api/Answers")]
		[HttpPost]
		public IActionResult GetAnswers([FromBody]int[] qIDs)
		{
			var result = db.question
				   .AsEnumerable()
				   .Where(y => qIDs.Contains(y.QnID))
				   .OrderBy(x => { return Array.IndexOf(qIDs, x.QnID); })
				   .Select(z => z.Answer)
				   .ToArray();
			return Ok(result);
		}
	}
}
