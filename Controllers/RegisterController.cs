using E_ComMIniProj.Model;
using E_ComMIniProj.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace E_ComMIniProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService service;
        private readonly IConfiguration _config;

        public RegisterController(IRegisterService service, IConfiguration _config)
        {
            this.service = service;
            this._config = _config;
        }

        [HttpPost]
        [Route("Login")]

        public async Task<Hashtable> Post(Register r)
        {
            Hashtable hashtable = new Hashtable();
            try
            {

               var Register  = await service.GetLogin(r);
                if (Register != null)
                {
                    var token = GenerateToken(Register);
                    hashtable.Add("Token",token);
                    hashtable.Add("Object", Register);
                    return hashtable;
                    //return StatusCode(StatusCodes.Status200OK);
                }
                /*else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }*/
            }
            catch (Exception ex)
            {
                //return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                await Console.Out.WriteLineAsync(ex.Message);
            }
            return hashtable;
        }

        [HttpPost]
        [Route("Registration")]

        public async Task<IActionResult> Post1([FromBody][Bind(include: "username,email,password")] Register user)
        {
            try
            {
                var result = await service.Registration(user);
                if (result >= 1)
                    return StatusCode(StatusCodes.Status201Created);
                else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        private string GenerateToken(Register reg)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,reg.username),
                new Claim(ClaimTypes.Role,reg.roleid.ToString()),
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }

       /* private string GenerateToken(Register reg)
        {
            // Creating a symmetric security key from the configured JWT key
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            // Creating signing credentials using the security key and HMACSHA256 algorithm
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Defining claims for the JWT payload
            var claims = new[]
            {
        new Claim(ClaimTypes.NameIdentifier, reg.username),
        new Claim(ClaimTypes.Role, reg.roleid.ToString()),
    };

            // Creating a new JWT with specified parameters
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],               // Issuer
                _config["Jwt:Audience"],             // Audience
                claims,                              // Claims (payload)
                expires: DateTime.Now.AddMinutes(15),// Expiration time
                signingCredentials: credentials      // Signing credentials
            );

            // Writing the JWT token as a string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }*/




    }
}
