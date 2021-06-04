using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public StudentsController(IDB db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult GetStudents()
        {
            if (_db.GetAllStudents().Count > 0)
                return Ok(_db.GetAllStudents());
            return BadRequest(" There is no students yet ");

        }
        [HttpPost]
        public IActionResult StudentRegistration(Student s)
        {
            if (s == null)
                return BadRequest("Check Student data please");

            if (_db.GetStudentByMail(s.Mail) != null)
                return BadRequest("Mail is Exists Try another one"); 

            if (ModelState.IsValid)
            {
                 return Ok(_db.AddStudent(s));
            }
            else
            {
                return BadRequest("Values Are not ok");

            }

        }
    }
}
