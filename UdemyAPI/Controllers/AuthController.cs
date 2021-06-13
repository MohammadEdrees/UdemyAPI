using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyAPI.Authentication;
using UdemyAPI.Models;
using UdemyAPI.Services;

namespace UdemyAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private  IDB _db;

        public AuthController(SignInManager<ApplicationUser> signInManager
            ,UserManager<ApplicationUser> userManager,IDB db)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _db = db;
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
            _db.AddStudent(s);

            if (result.Succeeded == false)
            {
                return BadRequest("Some thing went wrong");
            }

            return Ok(s);

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
