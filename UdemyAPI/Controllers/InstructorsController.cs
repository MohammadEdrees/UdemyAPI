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
            if (_db.GetInstructorByMail(ins.Mail) != null && _db.GetStudentByMail(ins.Mail) != null)
                return BadRequest("Mail is Exists Try another one ");//400

            if (ModelState.IsValid)
            {

                return Ok(_db.AddInstructor(ins));
            }
            else {
                return BadRequest("Values Are not ok");
            }

        }

        [HttpGet]
        public ActionResult<Instructor> GetInstructorById(int id) {
            if (id > 0) {
                Instructor FoundInstructor = _db.GetInstructorById(id);
                if (FoundInstructor != null)
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

        [HttpGet]
        public IActionResult GetInstructorsInSubCategory(int subCatId)
        {
            return Ok(_db.GetInstructorsInSubCategory(subCatId));
        }

        [HttpGet]
        public IActionResult GetInstructorsInTopic(int topId)
        {
            return Ok(_db.GetInstructorsInTopic(topId));
        }

        [HttpPut]
        public IActionResult EditInstructor(int id, Instructor ins)
        {
            Instructor OldIns = _db.GetInstructorById(id);
            if (OldIns == null)
                return NotFound($"Instructor Not Found you id is {id}");

            if (OldIns.InstId != ins.InstId)
                return BadRequest($"OldID is{OldIns.InstId}:NEWID is {OldIns.InstId}");
            else
            {
                Instructor EditedIns = _db.EditInstructor(OldIns, ins);
                return Ok(EditedIns);

            }

        }

        [HttpGet]
        public ActionResult<Instructor> GetStudnetNumbersWithInst(int id)
        {
            if (id > 0)
            {
                int NumberOfStudents = _db.GetStudnetNumbersWithInst(id);
                if (NumberOfStudents != 0)
                {
                    return Ok(NumberOfStudents);
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

    }
       
}
