using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyAPI.Models;
using UdemyAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using UdemyAPI.Authentication;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace UdemyAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IDB _db;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;

        public LoginController(IDB db, UserManager<ApplicationUser> _userManager, IConfiguration _configuration)
        {
            _db = db;
            userManager = _userManager;
            configuration = _configuration;
        }

        [HttpPost]
        public async Task<IActionResult> login([FromBody]UserModel model)
        {
            
            if (ModelState.IsValid)
            {

                //  var result = await _db.Login(user);
                var user = await userManager.FindByEmailAsync(model.Mail);
                if (user != null && await userManager.CheckPasswordAsync(user, model.Password)) {
                    var userRoles = await userManager.GetRolesAsync(user);
                    var authClaims = new List<Claim>
                    {
                        new Claim (ClaimTypes.Name,user.UserName),
                        new Claim (JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                    };
                   foreach (var userRole in userRoles)
                {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                    var authenticationKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
                    var token = new JwtSecurityToken(
                        issuer: null,
                        audience: null,
                        expires: DateTime.Now.AddHours(3),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authenticationKey, SecurityAlgorithms.HmacSha256)


                        );

                    return Ok(new { 
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration=token.ValidTo
                    });
                }
               
            }
                return Unauthorized();
        }
        [HttpPost]
        public async Task<IActionResult> Reg ([FromBody]UserModel InsModel)
        {
            var userExists = await userManager.FindByEmailAsync(InsModel.Mail);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    new Response { Message = "User Already Exists",Statues="Error" });

            ApplicationUser user = new ApplicationUser()
            {
                Email = InsModel.Mail,
                SecurityStamp = Guid.NewGuid().ToString()
                //UserName = $"{InsModel.Fname + InsModel.Lname}"
                

            };
            var result = await userManager.CreateAsync(user, InsModel.Password);
            if(!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError,
                     new Response { Message = "Faild To Create", Statues = "Error" });


            return Ok(new Response() { Message = "User Created Successfully", Statues = "Success" });

        }




        //[HttpGet("Stream/Url/{*videoUrl}")]
        //public async Task<FileStreamResult> GetStreamFromUrlAsync(string videoUrl)
        //{
        //    var stream = await _streamingService.GetVideoByUrlAsync(videoUrl).ConfigureAwait(false);
        //    return new FileStreamResult(stream, "video/mp4");
        //}

    }
}
