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
        public List<Category> GetAllCategories()
        {
            return _db.Categories.ToList();
        }
        public List<Topic> GetAllTopics()
        {
            
           return _db.Topics.ToList();
        }
      
        public List<Course> GetAllCourses()
        {
            return _db.Courses.ToList();
        }
        public List<Instructor> GetAllInstructors()
        {
            return _db.Instructors.ToList();
        }
        public List<Student> GetAllStudents()
        {
            return _db.Students.ToList();
        }
        public List<Admin> GetAllAdmins()
        {
            return _db.Admins.ToList();
        }
        public List<SupCateg> GetSupCategoriesById(int id)
        {
            return _db.SupCategs.Where(obj => obj.CategoryId == id).ToList();
        }

        public Instructor AddInstructor(Instructor s)
        {    // s.Password=>Hash
            _db.Instructors.Add(s);
            _db.SaveChanges();
            return s;
        }
        public Student AddStudent(Student s)
        {
            // s.Password=>Hash
            _db.Students.Add(s);
            _db.SaveChanges();
            return s;
        }
        public Course GetCourseById(int id)
        {
           return _db.Courses.FirstOrDefault(obj => obj.CrsId == id);
        }
        public Course GetCourseByTitle(string title)
        {
           
             return   _db.Courses.FirstOrDefault(obj => obj.Title == title);
        }
        public Instructor GetInstructorById(int id)
        {
            return _db.Instructors.FirstOrDefault(obj => obj.InstId == id);
        }
        public Instructor GetInstructorByName(string name)
        {
            return _db.Instructors.FirstOrDefault(obj => obj.Fname == name || obj.Lname == name);
        }
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
        
        public IEnumerable<IGrouping<int, StdCr>> GetSortedCoursesRelatedToTopic(int topId)
        {

            //List<StdCr> foundStdCrs = _db.StdCrs.Where(obj => obj.CrsId == courseId).ToList();

            IEnumerable<IGrouping<int, StdCr>> StudentInCourse =
                _db.StdCrs.Where(obj => obj.Course.TopId == topId).
                OrderByDescending(o => o.Course.studentCourses.Count()).
                AsEnumerable().GroupBy(obj => obj.CrsId);



            //IEnumerable<IGrouping<int,StdCr>> StudentInCourse = _db.StdCrs.AsEnumerable().GroupBy(obj => obj.CrsId);

            //var StudentInCourse = (IEnumerable<StdCr>)_db.StdCrs.GroupBy(obj => obj.CrsId).Select(obj => obj);

           return StudentInCourse;
          

        }

        public List<StdCr> GetAllStudentCourses()
        {
            return _db.StdCrs.ToList();
        }

        public List<Category> GetSomeCategoriesByTitle(string title)
        {
            return _db.Categories.Where(e => e.CategoryName.Contains(title)).ToList();
        }

        public List<SupCateg> GetSomeSupCategsByTitle(string title)
        {
            return _db.SupCategs.Where(e => e.SupCatTitle.Contains(title)).ToList();
        }

        public List<Topic> GetSomeTopicsByTitle(string title)
        {
            return _db.Topics.Where(e => e.TopName.Contains(title)).ToList();
        }

        public List<Instructor> GetSomeInstructorsByTitle(string title)
        {
            return _db.Instructors.Where(e => e.Fname.Contains(title)).ToList();

        }
        public List<Course> GetSomeCoursesByTitle(string title)
        {
            List<Course> courses = _db.Courses.Where(obj => obj.Title.Contains(title)).ToList();
            return courses;

        }

        public List<Course> getSortedCoursesUsingLazy(int topic)
        {
            return _db.Courses.Where(obj => obj.TopId == topic).OrderByDescending(o => o.studentCourses.Count).ToList();
           
        }

        public Instructor GetInstructorByMail(string mail)
        {
            return _db.Instructors.FirstOrDefault(i => i.Mail == mail);
        }

        public Student GetStudentByMail(string mail)
        {
            return _db.Students.FirstOrDefault(s => s.Mail == mail);
        }

        public void RemoveStudent(Student s)
        {
            if (s != null)
                _db.Students.Remove(s);
                _db.SaveChanges();
        }

        public Student GetStudentById(int id)
        {
            return _db.Students.FirstOrDefault(s => s.StdId == id);

        }

        public Student EditStudent(Student OldStd, Student newS)
        {
            
          //  _db.Entry(newS).State = EntityState.Modified;
             OldStd.Fname = newS.Fname;
             OldStd.Lname = newS.Lname;
             OldStd.Mail = newS.Mail;
             OldStd.Password = newS.Password;
             OldStd.Phone = newS.Phone;
             OldStd.ShoppingCard = newS.ShoppingCard;
             OldStd.StudentCourses = newS.StudentCourses;
             OldStd.Address = newS.Address;
            _db.SaveChanges();
            return OldStd;
        }

        public async Task<object> Login(UserModel user)
        {
           Student student = await _db.Students.FirstOrDefaultAsync(obj => obj.Mail == user.Mail &&
           obj.Password==user.Password 
                     );
            
            if (student == null)
            {
                Instructor instructor = await _db.Instructors.FirstOrDefaultAsync(obj => obj.Mail == user.Mail &&
                obj.Password == user.Password
                    );
                return instructor;
            }
            else
            {
                return student;
            }

        }
    }
}
