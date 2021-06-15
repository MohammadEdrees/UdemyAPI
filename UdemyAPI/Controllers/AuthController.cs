using Castle.Core.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UdemyAPI.Authentication;
using UdemyAPI.Models;
using UdemyAPI.Services;
using Microsoft.Extensions.Configuration;

namespace UdemyAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private Microsoft.Extensions.Configuration.IConfiguration _configuration;

        private IDB _db;

        public AuthController(SignInManager<ApplicationUser> signInManager
            ,UserManager<ApplicationUser> userManager,IDB db, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _db = db;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<ActionResult<ResponseWithData<CheckMail.Response>>>
            CheckEmailExists(CheckMail.Request request)
        {
            var response = new ResponseWithData<CheckMail.Response>();
            response.Data = new CheckMail.Response();
            response.Data.Exists = await CheckMail(request.Email);
            return Ok(response);

        } 
        [HttpPost]
        public async Task<ActionResult<ResponseWithData<SignUp.response>>> SignUp(SignUp.request request)
        {
            var response = new ResponseWithData<SignUp.response>();
            if(await CheckMail(request.Email))
            {
                response.AddError(1);
                return response;
            }
            var user = new ApplicationUser()
            {
                Email = request.Email,
                UserName=request.Email

            };
            var result = await _userManager.CreateAsync(user,request.Password);

            if (result.Succeeded == false)
            {
                return BadRequest("Some thing went wrong");
            }

            response.Data = new SignUp.response()
            {
                Email = request.Email,
                Token=_db.GetToken(),
                Password=request.Password
            };

            return Ok(response);

        }
        [HttpPost]
        public async Task<ActionResult<ResponseWithData<Student>>> SignUpStd(Student s)
        {
           // var response = new ResponseWithData<SignUp.response>();
            if (await CheckMail(s.Mail))
            {
                return Ok(s.Mail);
            }
            var user = new ApplicationUser()
            {
                Email = s.Mail,
                UserName = s.Fname+s.Lname

            };
            var result = await _userManager.CreateAsync(user, s.Password);
            s.Token=_db.GetToken();
            _db.AddStudent(s);

            if (result.Succeeded == false)
            {
                return BadRequest("Some thing went wrong");
            }

            return Ok(s);

        }


        [HttpPost]
        public async Task<ActionResult<ResponseWithData<SignIn.response>>>SignIn(SignIn.request request)
        {
            var response = new ResponseWithData<SignIn.response>();
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return BadRequest("Email Not Exists");
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, true);

            if (result.Succeeded == false)
            {
                return BadRequest("Email And Password Doesnot Match");

            }
            response.Data = new SignIn.response();
            response.Data.Token = generateToken(new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.Email),
                new Claim(ClaimTypes.Role,"student")

            });
          

            return Ok(response);
        }
        private string generateToken(List<Claim>Claims)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
           
            var tokeOptions = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: Claims,
                expires: DateTime.Now.AddHours(5),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;

        }

        //Helper Method For Work 
        private async Task<bool> CheckMail(string email)
        {
            if (await _userManager.FindByEmailAsync(email) == null)
            {
                return false;
            }
            else
            {
                return true;

            }
        }

    }
}
