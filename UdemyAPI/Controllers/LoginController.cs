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
                //   var user = await userManager.FindByEmailAsync(model.Email);
                Student user = _db.GetStudentByMail(model.Mail);
                if (user != null) {
               // if (user != null && await userManager.CheckPasswordAsync(user, model.PasswordHash)) {
                //    var userRoles = await userManager.GetRolesAsync(user);
                //    var authClaims = new List<Claim>
                //    {
                //        new Claim (ClaimTypes.Sid,user.UserName),
                //        new Claim (JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                //    };
                //   foreach (var userRole in userRoles)
                //{
                //        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                //}
                    var authenticationKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
                    var token = new JwtSecurityToken(
                        issuer: null,
                        audience: null,
                        expires: DateTime.Now.AddHours(3),
                        claims: null,
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
        public async Task<IActionResult> Reg ([FromBody]Student Model)
        {
            //var userExists = await userManager.FindByEmailAsync(Model.Email);
            var userExists = _db.GetStudentByMail(Model.Mail);
            if (userExists != null)
                return BadRequest("Already Exists");

            ApplicationUser user = new ApplicationUser()
            {
     
                //Empty
            };

            //var result = await userManager.CreateAsync(user, Model.PasswordHash);
            var result = await userManager.CreateAsync(user, Model.Password);
            if(!result.Succeeded)
                return BadRequest("FaILD");


            return Ok("Success");

        }

        [HttpGet]
        public IActionResult GetToken() {

            return Ok(_db.GetToken());
        }

    }
}
