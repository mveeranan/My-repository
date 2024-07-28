using JWT_Authentication_Web_Api.Data;
using JWT_Authentication_Web_Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace JWT_Authentication_Web_Api.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
        {
        private readonly ApplicationDbContext _db;
        Response response = new Response();
        public UsersController(ApplicationDbContext context)
            {
            _db = context;
            }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
            {
            try
                {
                var data = await _db.users.ToListAsync();
                if (data != null)
                    {
                    response.StatusCode = 200;
                    response.Message = "Success";
                    response.Result = data;
                    return Ok(response);
                    }
                else
                    {
                    response.StatusCode = 404;
                    response.Message = "Success";
                    return NotFound(response);
                    }
                }
            catch
                {
                response.StatusCode = 500;
                response.Message = "Internal Server Error";
                return Ok(response);
                }
            }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
            {
            try
                {
                var data = await _db.users.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (data != null)
                    {
                    response.StatusCode = 200;
                    response.Message = "Success";
                    response.Result = data;
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
                response.Message = "Internal Server Error";
                return Ok(response);
                }
            }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Users model)
            {
            try
                {
                if (model == null)
                    {
                    response.StatusCode = 400;
                    response.Message = "Bad Request";
                    return BadRequest(response);
                    }
                else
                    {
                    await _db.users.AddAsync(model);
                    await _db.SaveChangesAsync();
                    response.StatusCode = 201;
                    response.Message = "Success";
                    return Ok(response);
                    }
                }
            catch
                {
                response.StatusCode = 500;
                response.Message = "Internal Server Error";
                return Ok(response);
                }
            }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]Users model)
            {
            try
                {
                var data = await _db.users.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (data != null)
                    {
                    model.Name = data.Name;
                    model.Email = data.Email;
                    model.Phone = data.Phone;
                    model.Address = data.Address;
                    await _db.SaveChangesAsync();
                    response.StatusCode = 201;
                    response.Message = "Success";
                    return Ok(response);
                    }
                else
                    {
                    response.StatusCode = 400;
                    response.Message = "Bad Request";
                    return BadRequest(response);
                    }
                }
            catch
                {
                response.StatusCode = 500;
                response.Message = "Internal Server Error";
                return Ok(response);
                }
            }
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromHeader] int id)
            {
            try
                {
                var data = await _db.users.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (data != null)
                    {
                    _db.users.Remove(data);
                    await _db.SaveChangesAsync();
                    response.StatusCode = 200;
                    response.Message = "Success";
                    return Ok();
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
                response.Message = "Internal Server Error";
                return Ok(response);
                }
            }
        }
    }
