using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyAPI.Services;
using UdemyAPI.Models;
using UdemyAPI.Authentication;


namespace UdemyAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        IDB _db;
       
        public InstructorsController(IDB db)
        {
            _db = db;
            
        }

        //GetInstructors
        [HttpGet]
        public ActionResult<IEnumerable<Instructor>> GetAllInstructors()
        {
            if (_db.GetAllInstructors().Count > 0)
            {
                return (_db.GetAllInstructors());

            }
            else {
                return NotFound();
            }

        }
        [HttpPost]
        public ActionResult InstructorRegistration(Instructor ins)
        {
            //if mail exists error
            //getInstructorby Mail
            if (ins == null)
                return BadRequest();
            //GeInsBy mail 
            if (_db.GetInstructorByMail(ins.Mail) != null)
                return BadRequest("Mail is Exists Try another one ");//400

            if (ModelState.IsValid)
            {
                
                return Ok(_db.AddInstructor(ins));
            }
            else {
                return BadRequest();
            }

        }

        [HttpGet]
        public ActionResult<Instructor> GetInstructorById(int id) {
            if (id > 0) {
             Instructor FoundInstructor = _db.GetInstructorById(id);
            if(FoundInstructor != null)
                {
                    return FoundInstructor;
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("{id}"), DisableRequestSizeLimit]
        public async Task<IActionResult> InsttImg(IFormFile file, int id)
        {
            var result = await _db.UploadInstructorImg(file, id);
            return Ok(result);

        }

        [HttpGet]
        public IActionResult GetInstructorsInCategory(int id)
        {
            return Ok(_db.GetInstructorsInCategory(id));
        }

    }
}
