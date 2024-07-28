using Azure;
using JWT_Authentication_Web_Api.Data;
using JWT_Authentication_Web_Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Response = JWT_Authentication_Web_Api.Models.Response;

namespace JWT_Authentication_Web_Api.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
        {

        private readonly ApplicationDbContext _db;
        Response res = new Response();
        private readonly IConfiguration _config;
        public LoginController(ApplicationDbContext dbContext, IConfiguration configuration)
            {
            _db = dbContext;
            _config = configuration;
            }
        [HttpPost]
        public async Task<IActionResult> Login (Login model)
            {
            try
                {
                var data = await _db.users.Where(x => x.Email == model.email && x.Password == model.password).FirstOrDefaultAsync();
                if (data == null)
                    {
                    res.StatusCode = 404;
                    res.Message = "Invalid Credential";
                    return NotFound(res);
                    }
                else
                    {
                    var Claims = new[]
                        {
                        new Claim(JwtRegisteredClaimNames.Sub,_config["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim("Email", data.Email),
                        new Claim("UserId",data.Id.ToString()),
                        new Claim("Name",data.Name),
                        };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                    var signIn = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _config["Jwt:Issuer"],
                        _config["Jwt:Audience"],
                        Claims,
                        expires: DateTime.UtcNow.AddMinutes(2),
                        signingCredentials: signIn
                        );
                    string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
                    res.StatusCode = 200;
                    res.Message = "Success";
                    res.Result = tokenValue;
                    return Ok(res);
                    }
                }
            catch
                {
                res.StatusCode = 500;
                res.Message = "Internal Server Error";
                return Ok(res);
                }
            }


        }
    }
