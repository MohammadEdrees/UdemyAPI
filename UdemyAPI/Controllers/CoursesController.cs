using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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

            return Ok(_db.GetSortedCoursesRelatedToTopic(id));      
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

        [HttpPut("{CrsId}")]
        public IActionResult AddCourseSection(int CrsId, CourseSection courseSection)
        {
            if (CrsId > 0)
            {
                IEnumerable<CourseSection> CrsSections = _db.AddCourseSection(CrsId, courseSection);
                if(CrsSections != null)
                return Ok(CrsSections);

                return BadRequest("Error");
            }
            return BadRequest("Error");
        }

        [HttpPut("{insId}")]
        public IActionResult AddInstructorCourse(int insId,Course course)
        {
            if(_db.GetInstructorById(insId) != null)
            {
                Course newCourse = _db.AddCourse(insId, course);

                if (newCourse != null)
                    return Ok(newCourse);
              

                return BadRequest("Error Adding");
            }
            
            return BadRequest("Instructor Not Exist");
        }


        [HttpGet]
        public IActionResult GetCourseSections(int crsId)
        {
            if (crsId > 0)
            {
                IEnumerable<CourseSection> CrsSections = _db.GetCourseSections(crsId);
                if (CrsSections != null)
                    return Ok(CrsSections);

                return BadRequest("Error");
            }
            return BadRequest("Error");
        }


        [HttpPut("{SecId}")]
        public async Task<IActionResult> AddLecture(int SecId,Lecture lecture)
        {

            if(SecId >0)
            {
                if(_db.GetCourseSection(SecId)!=null)
                {
                    IEnumerable<Lecture> courseLecture = await _db.AddLecture(SecId,lecture);
                    if (courseLecture != null)
                        return Ok(courseLecture);
                }
                return BadRequest("Not Found");
            }
            return BadRequest("Error");
        }


        [HttpGet]
        public IActionResult GetCourseLectures(int crsId)
        {
            if (crsId > 0)
            {
                IEnumerable<Lecture> CrsLecture = _db.GetCourseLectures(crsId);
                if (CrsLecture != null)
                    return Ok(CrsLecture);

                return BadRequest("Error");
            }
            return BadRequest("Error");
        }



        [HttpPut("{LectId}"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadLectureVideo(int LectId, IFormFile Video)
        {
            var result = await _db.UploadLectureVideo(LectId, Video);
            return Ok(result);
        }


        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }


        [HttpGet]
        public IActionResult GetCourseSection(int SecID)
        {
            CourseSection courseSection = _db.GetCourseSection(SecID);
            if (courseSection == null)
                return BadRequest("Not Exist");
            return Ok(courseSection);
        }

        [HttpGet]
        public IActionResult GetLecture(int LecID)
        {
            Lecture lecture = _db.GetLecture(LecID);
            if (lecture == null)
                return BadRequest("Not Exist");
            return Ok(lecture);
        }

        [HttpGet]
        public IActionResult GetAllCourseSections(int courseId)
        {
            if (courseId > 0)
            {
                IEnumerable<CourseSection> sections = _db.AllCourseSectionsInSpecificCourse(courseId);
                if (sections !=null)
                {
                    return Ok(sections);

                }

            }
            return BadRequest("Something went wrong");
        }

        [HttpGet]
        public IActionResult LecuresInSection(int sectionId)
        {
            if (sectionId > 0)
            {
                IEnumerable<Lecture> lectures = _db.AllLecturesInSpecificSection(sectionId);
                if (lectures != null)
                {
                    return Ok(lectures);

                }

            }
            return BadRequest("Something went wrong");
        }

        [HttpGet]
        public IActionResult GetSortedInstructorCrs(int instId)
        {
            if (instId > 0)
            {
                return Ok(_db.SortedCourseForInstById(instId));
            }
            return BadRequest(" Not Valid Course Id");
        }

        [HttpGet]
        public IActionResult GetFirstLectue(int CrsID)
        {
            if (CrsID > 0)
            {
                Lecture lecture = _db.GetFirstLectue(CrsID);
                if (lecture != null)
                {
                    return Ok(lecture);

                }

            }
            return BadRequest("Something went wrong");
        }

        [HttpGet]
        public IActionResult GetStudentCourses(int StdId)
        {
            if (StdId > 0)
            {
                List<Course> courses = _db.GetStudentCourses(StdId);
                if (courses != null)
                {
                    return Ok(courses);
                }

            }
            return BadRequest("Something went wrong");
        }

        [HttpDelete]
        public IActionResult DeleteCourseEnrollment(int crsId,int stdId)
        {
            IEnumerable<Course> courses = _db.DeleteCourseEnrollment(crsId,stdId);
            if (courses != null)
            {
                return Ok(courses);
            }
            return BadRequest("Something went wrong");
        }

        [HttpDelete]
        public IActionResult DeleteCourseSection(int crsId, int secId)
        {
            IEnumerable<CourseSection> courseSections = _db.DeleteCourseSection(crsId, secId);
            if (courseSections != null)
            {
                return Ok(courseSections);
            }
            return BadRequest("Something went wrong");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSectionLecture(int crsId ,int lectId)
        {
            IEnumerable<Lecture> sectionLecture =await _db.DeleteSectionLecture(crsId, lectId);
            if(sectionLecture!=null)
            {
                return Ok(sectionLecture);
            }
            return BadRequest("Someting went wrong");

        }

    }
}
