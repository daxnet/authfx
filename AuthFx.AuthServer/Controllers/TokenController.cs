using System;
using System.Linq;
using AuthFx.AuthServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AuthFx.AuthServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _config;

        public TokenController(IConfiguration config)
            => _config = config;

        [HttpGet("{userName}")]
        public IActionResult GetToken(string userName)
        {
            var user = AppUser.MockUsers.FirstOrDefault(u => u.UserName == userName);
            if (user == null)
            {
                return Forbid();
            }

            var securityKey = _config["jwt:secret"];
            var exp = TimeSpan.Parse(_config["jwt:exp"]);
            var token = Utils.GenerateToken(user, securityKey, exp);
            return Ok(token);
        }
    }
}