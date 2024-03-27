using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement_API.Models;
using StudentManagement_API.Models.Data;

namespace StudentManagement_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TeachersController : ControllerBase
	{
		private readonly ApplicationDbcontext db;
		Response response = new Response();
		public TeachersController(ApplicationDbcontext _db)
		{
			db = _db;
		}
		[HttpGet]
		public async Task<IActionResult> GetTeachers()
		{
			try
			{
				var result = await db.teachers.ToListAsync();
				if (result != null)
				{
					response.StatusCode = 200;
					response.Message = "Success";
					response.Data = result;
					return Ok(response);
				}
				else
				{
					response.StatusCode = 404;
					response.Message = "Not Found";
					return NotFound(response);
				}
			}
			catch
			{
				response.StatusCode = 500;
				response.Message = "Something Went Worng";
				return Ok(response);
			}
		}
		[HttpPost]
		public async Task<IActionResult> CreateTeacher([FromBody] Teachers o)
		{
			try
			{
				await db.teachers.AddRangeAsync(o);
				await db.SaveChangesAsync();
				response.StatusCode = 201;
				response.Message = "Success";
				return Ok(response);
			}
			catch
			{
				response.StatusCode = 400;
				response.Message = "Bad Request";
				return BadRequest(response);
			}
		}
		[HttpPut("{Id}")]
		public async Task<IActionResult> UpdtaeTeacher([FromRoute] int Id, [FromBody] Teachers o)
		{
			try
			{
				var result = await db.teachers.Where(x => x.Id == Id).FirstOrDefaultAsync();
				if (result != null)
				{
					result.Name = o.Name;
					result.Email = o.Email;
					result.Phone = o.Phone;
					result.Subject = o.Subject;
					await db.SaveChangesAsync();
					response.StatusCode = 200;
					response.Message = "Success";
					return Ok(response);
				}
				else
				{
					response.StatusCode = 404;
					response.Message = "Not Found";
					return NotFound(response);
				}
			}
			catch
			{
				response.StatusCode = 500;
				response.Message = "Something Went Worng";
				return Ok(response);

			}
		}
		[HttpDelete("{Id}")]
		public async Task<IActionResult> DeleteTeacher([FromRoute] int Id)
		{
			try
			{
				var result = await db.teachers.Where(x => x.Id == Id).FirstOrDefaultAsync();
				if (result != null)
				{
					db.teachers.Remove(result);
					await db.SaveChangesAsync();
					response.StatusCode = 200;
					response.Message = "Success";
					return Ok(response);
				}
				else
				{
					response.StatusCode = 404;
					response.Message = "Not Found";
					return NotFound(response);
				}
			}
			catch
			{
				response.StatusCode = 500;
				response.Message = "Something Went Worng";
				return Ok(response);
			}
		}
		[HttpGet("{Id}")]
		public async Task<IActionResult> GetTeacherById([FromRoute] int Id)
		{
			try
			{
				var result = await db.teachers.Where(x => x.Id == Id).FirstOrDefaultAsync();
				if (result != null)
				{
					response.StatusCode = 200;
					response.Message = "Success";
					response.Data = result;
					return Ok(response);
				}
				else
				{
					response.StatusCode = 404;
					response.Message = "Not Found";
					return NotFound(response);
				}
			}
			catch
			{
				response.StatusCode = 500;
				response.Message = "Something Went Worng";
				return Ok(response);
			}
		}
	}
}
