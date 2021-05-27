using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyAPI.Models;

namespace UdemyAPI.Services
{
    public class DBService : IDB
    {
        UdemyContext _db;
        public DBService(UdemyContext db)
        {
            _db = db;
        }

      
        //-------------Get(List)Area-----------------
        //1
        public List<Category> GetAllCategories()
        {
            return _db.Categories.ToList();
        }
        //2
        public List<Topic> GetAllTopics()
        {
            
           return _db.Topics.ToList();
        }
      
        //3
        public List<Course> GetAllCourses()
        {
            return _db.Courses.ToList();
        }
        //4
        public List<Instructor> GetAllInstructors()
        {
            return _db.Instructors.ToList();
        }
        //5
        public List<Student> GetAllStudents()
        {
            return _db.Students.ToList();
        }
        //6
        public List<Admin> GetAllAdmins()
        {
            return _db.Admins.ToList();
        }
        //13
        public List<SupCateg> GetSupCategoriesById(int id)
        {
            return _db.SupCategs.Where(obj=>obj.CategoryId==id).ToList(); 
        }


        //-------------------PostArea----------
        //7
        public Instructor AddInstructor(Instructor s)
        {    // s.Password=>Hash
            _db.Instructors.Add(s);
            _db.SaveChanges();
            return s;
        }

        //8
        public Student AddStudent(Student s)
        {
            // s.Password=>Hash
            _db.Students.Add(s);
            _db.SaveChanges();
            return s;
        }

        //---------Get(By:Searching)Area------------------
        //9
        public Course GetCourseById(int id)
        {
            return _db.Courses.FirstOrDefault(obj => obj.CrsId == id);
        }
        //10
        public Course GetCourseByTitle(string title)
        {
            return _db.Courses.FirstOrDefault(obj => obj.Title == title);
        }
        //11
        public Instructor GetInstructorById(int id)
        {
            return _db.Instructors.FirstOrDefault(obj => obj.InstId == id);
        }
        //12
        public Instructor GetInstructorByName(string name)
        {
            return _db.Instructors.FirstOrDefault(obj => obj.Fname == name || obj.Lname == name);
        }

        //14 
        public Category GetCategoryById(int id)
        {
            return _db.Categories.Find(id);

        }

        public List<Topic> GetTopicsBySupCategId(int id)
        {
            return _db.Topics.Where(col => col.SupCatId == id).ToList();
        }

        public List<Course> GetCoursesByTopicId(int id)
        {
            return _db.Courses.Where(col => col.TopId == id).ToList();
        }

        //--------------CustomCases------------------------


    }
}
