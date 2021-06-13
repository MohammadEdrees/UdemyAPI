using BrunoZell.ModelBinding;
using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using UdemyAPI.Models;
using UdemyAPI.Services;


namespace UdemyAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        IDB _db;
        private static string ApiKey = "AIzaSyD0MQz8q3CFW16JRY11lHctKPSShXxhs7Q";
        private static string Bucket = "udemy-3c633.appspot.com";
        private static string AuthMail = "medoenoch@gmail.com";
        private static string Password = "newstart2020";
        IWebHostEnvironment hostingEnvironment;
        public StudentsController(IDB db, IWebHostEnvironment _hostingEnvironment)
        {
            _db = db;
            hostingEnvironment = _hostingEnvironment;
        }
        [HttpGet]
        public IActionResult GetStudents()
        {
            if (_db.GetAllStudents().Count > 0)
                return Ok(_db.GetAllStudents());
            return BadRequest(" There is no students yet ");

        }
        [HttpPost, DisableRequestSizeLimit]
        [RequestFormLimits(MultipartBodyLengthLimit = 204857600)]
        public async Task<IActionResult> StudentRegistration(IFormFile stdImg, Student s)
        {
            if (s == null)
                return BadRequest("Check Student data please");

            if (_db.GetStudentByMail(s.Mail) != null)
                return BadRequest("Mail is Exists Try another one");

            if (ModelState.IsValid)

            {
                s.ImagePath = await _db.UploadImage(stdImg);
                Student Std = _db.AddStudent(s);
                return Ok(Std);
            }
            else
            {
                return BadRequest("Values Are not ok");

            }

        }
        [HttpDelete]
        public IActionResult Remove(int id)
        {
            Student foundStd = _db.GetStudentById(id);
            if (foundStd != null)
            {
                _db.RemoveStudent(foundStd);
                return Ok("Deleted Successful");
            }
            else
            {

                return BadRequest("Invalid Id");
            }
        }
        [HttpPut("{id}")]
        public IActionResult testEdit(int id, Student newS)
        {
            //DataBinding ["","",""]
            //Images

            if (id > 0)
            {
                Student OldStd = _db.GetStudentById(id);
                if (OldStd == null)
                    return NotFound($"Student Not Found you id is {id}");

                if (OldStd.StdId != newS.StdId)
                    return BadRequest($"OldID is{OldStd.StdId}:NEWID is {newS.StdId}");
                else
                {
                    Student EditedStd = _db.EditStudent(OldStd, newS);
                    return Ok(EditedStd);

                }

            }
            else
            {
                return BadRequest("Some thing went wrong");
            }
        }

        //[HttpPost("UploadFile")]
        //public async Task<IActionResult> UploadFile( IFormFile file)
        //{
        //    string fName = file.FileName;
        //    string path = Path.Combine(_environment.ContentRootPath, "Images/" + file.FileName);
        //    using (var stream = new FileStream(path, FileMode.Create))
        //    {
        //        await file.CopyToAsync(stream);
        //    }
        //    return Ok(file.FileName);
        //}
        [HttpPost, DisableRequestSizeLimit]
        [RequestFormLimits(MultipartBodyLengthLimit = 204857600)]
        // public async Task<IActionResult> Upload(IFormFile _file)
        public async Task<IActionResult> Upload()
        {
            string r = await _db.UploadImage(Request.Form.Files[0]);
            return Ok(r);

        }



        [HttpPost("{id}"), DisableRequestSizeLimit]
        public async Task<IActionResult>StudentImg( IFormFile file , int id)
        {
            var result = await _db.UploadStudentImg(file,id);
            return Ok(result);

        }

       

    }
}
