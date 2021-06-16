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
    public class CoursesController : ControllerBase
    {
        IDB _db;

        public CoursesController(IDB db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Course>> GetAllCourses()
        {
            if (_db.GetAllInstructors().Count > 0) return _db.GetAllCourses();
            else return NotFound();
        }

        [HttpGet]
        public ActionResult<List<Course>> GetCoursesByTopicId(int id)
        {
            List<Course> courses = _db.GetCoursesByTopicId(id);
            if (courses.Count > 0)
            {
                return courses;
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public ActionResult GetSortedCoursesRelatedToTopic(int id)
        {
            //List<StdCr> studentsCourses = _db.GetAllStudentCourses();
            //var GroupedByCourseId = studentsCourses.GroupBy(e => e.CrsId).ToList();
            //List<StdCr> studentsByCourseId =studentsCourses.Where(e => e.StdId == id).ToList();
            //
            return Ok(_db.GetSortedCoursesRelatedToTopic(id));
            ///return _db.GetSortedCoursesRelatedToTopic(id);           
        }
        [HttpGet]
        public IActionResult GetTopCoursesbyStudents(int topicId)
        {
            List<Course> data = _db.getSortedCoursesUsingLazy(topicId);
            if (data.Count <= 0)
                return BadRequest();
            return Ok(data);
        }
        [HttpGet]
        public IActionResult GetAllCoursesInOneCateg(int id)
        {
            List<Course> data = (List<Course>)_db.GetAllCoursesInOneCategory(id);
            if (data.Count <= 0)
                return BadRequest();
            return Ok(data);

        }

        [HttpPut("{id}"), DisableRequestSizeLimit]
        public async Task<IActionResult> CousreImageUpload(IFormFile file, int id)
        {
            var result = await _db.UploadCourseImg(file, id);
            return Ok(result);

        }
        [HttpGet]
        public IActionResult GetOrderedCoursesInCategory(int id) 
            { 
            return Ok(_db.GetOrderedCoursesInCategory(id));
           }
        [HttpGet]
        public IActionResult GetOrderedCoursesInSupCategory(int id)
        {
            return Ok(_db.GetOrderedCoursesInSupCategory(id));
        }
        [HttpGet]
        public IActionResult GetCourseById(int id)
        {
            return Ok(_db.GetCourseById(id));
        }

        [HttpPost("{CrsId}")]
        public IActionResult AddCourseSection(int CrsId, CourseSection courseSection)
        {
            CourseSection CrsSec = _db.AddCourseSection(CrsId, courseSection);
            return Ok(CrsSec);
        }

        [HttpPost("{SecId}")]
        public IActionResult AddLecture(int SecId, Lecture lecture)
        {
            Lecture Lec = _db.AddLecture(SecId, lecture);
            return Ok(Lec);
        }

        [HttpPut("{LectId}"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadLectureVideo(int LectId, IFormFile Video)
        {
            var result = await _db.UploadLectureVideo(LectId, Video);
            return Ok(result);
        }

        [HttpGet("{SecID}")]
        public IActionResult GetCourseSection(int SecID)
        {
            CourseSection courseSection = _db.GetCourseSection(SecID);
            if (courseSection == null)
                return BadRequest("Not Exist");
            return Ok(courseSection);
        }

        [HttpGet("{LecID}")]
        public IActionResult GetLecture(int LecID)
        {
            Lecture lecture = _db.GetLecture(LecID);
            if (lecture == null)
                return BadRequest("Not Exist");
            return Ok(lecture);
        }
    }
}
