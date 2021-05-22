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
    [Route("api/[controller]")]
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
                _db.addInstructor(ins);
                return (ins);

            }
            else {
                return BadRequest();
            }

        }
    }
}
