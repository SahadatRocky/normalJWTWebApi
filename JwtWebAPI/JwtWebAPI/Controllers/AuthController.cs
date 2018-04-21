using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JwtWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        [HttpPost("token")]
        public IActionResult Token()
        {
            // string tokenString = "test";

            var header = Request.Headers["Authorization"];
            if (header.ToString().StartsWith("Basic")) {

                var credvalue = header.ToString().Substring("Basic ".Length).Trim();
                var usernameAndpassenc = Encoding.UTF8.GetString(Convert.FromBase64String(credvalue)); //admin:pass
                var usernameAndpass = usernameAndpassenc.Split(":");

                //check in DB username and pass exist
                if (usernameAndpass[0]=="admin" && usernameAndpass[1]=="pass") {
                    var claimsData = new[] { new Claim(ClaimTypes.Name, usernameAndpass[0]) };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("assdfsdfnfghrgwxcvshtrytrwasddghfghdaasdasvdfnbnb"));
                    var signInCard = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
                    var token = new JwtSecurityToken(
                           issuer: "mysite.com",
                           audience: "mysite.com",
                           expires: DateTime.Now.AddMinutes(1),
                           claims: claimsData,
                           signingCredentials: signInCard

                        );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                    return Ok(tokenString);
                }
            }
                return BadRequest("Wrong Request");
            


        }

    }
}