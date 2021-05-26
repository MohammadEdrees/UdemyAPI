using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyAPI.Services;
using UdemyAPI.Models;

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
        public ActionResult<Instructor> InstructorRegistration(Instructor ins)
        {
            if (ModelState.IsValid)
            {
                _db.AddInstructor(ins);
                return (ins);

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
        
        //}
        //[HttpPost]
        //public ActionResult<Instructor> GetInstructorByName(string name) {
        //    if (name.Length > 0)
        //    {
        //        Instructor FoundInstructor = _db.GetInstructorByName(name);
        //        if (FoundInstructor != null)
        //        {
        //            return FoundInstructor;
        //        }
        //        else
        //        {
        //            return NotFound();
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }

        }
    }
}
