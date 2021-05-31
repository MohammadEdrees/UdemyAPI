﻿using Microsoft.AspNetCore.Http;
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
        public ActionResult<int>  GetSortedCoursesRelatedToTopic(int id)
        {
           List<StdCr>studentsCourses = _db.GetAllStudentCouses();
           var GroupedByCourseId = studentsCourses.GroupBy(e => e.CrsId).ToList();
           List<StdCr> studentsByCourseId =studentsCourses.Where(e => e.StdId == id).ToList();
            
            
            
            return _db.GetSortedCoursesRelatedToTopic(id);
            
        }


    }
}
