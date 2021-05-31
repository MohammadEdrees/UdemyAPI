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
    public class SearchController : ControllerBase
    {
        IDB _db;

        public SearchController(IDB db)
        {
            _db = db;
        }
      
        [HttpGet]
        public ActionResult getAny(string s)
        {
            List<Course> crss =_db.GetSomeCoursesByTitle(s);
            if(crss.Count>0)
            return Ok(crss);
            else
            {
                List<Topic> topics = _db.GetSomeTopicsByTitle(s);
                if (topics.Count > 0)
                    return Ok(topics);
                else
                {
                    List<SupCateg> supCategs = _db.GetSomeSupCategsByTitle(s);
                    if (supCategs.Count > 0)
                        return Ok(supCategs);
                    else
                    {
                        List<Category> categories = _db.GetSomeCategoriesByTitle(s);
                        if (categories.Count > 0)
                            return Ok(categories);
                        else
                        {
                            List<Instructor> instructors = _db.GetSomeInstructorsByTitle(s);
                            if (instructors.Count > 0)
                                return Ok(instructors);
                            else
                            {
                                return NotFound();

                            }
                        }
                    }
                }
            }
        }






    }
}
