using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyAPI.Models;

namespace UdemyAPI.Services
{
    public interface IDB
    {
        List<Category> GetAllCategories();

        List<Topic> GetAllTopics();

        List<Course> GetAllCourses();

        List<Instructor> GetAllInstructors();

        List<Student> GetAllStudents();

        List<Admin> GetAllAdmins();

        IEnumerable<IGrouping<int, StdCr>> GetSortedCoursesRelatedToTopic(int topId);

        List<SupCateg> GetSupCategoriesById(int id);

        List<Topic> GetTopicsBySupCategId(int id);

        List<Course> GetCoursesByTopicId(int id);
        
        Instructor AddInstructor(Instructor s);

        Student AddStudent(Student s);

        public Course GetCourseById(int id);
    
        public Course GetCourseByTitle(string title);
        public List<Category> GetSomeCategoriesByTitle(string title);
        public List<SupCateg> GetSomeSupCategsByTitle(string title);
        public List<Topic> GetSomeTopicsByTitle(string title);
        public List<Instructor> GetSomeInstructorsByTitle(string title);
        public List<Course> GetSomeCoursesByTitle(string title);

        public Instructor GetInstructorById(int id);
  
        public Instructor GetInstructorByName(string name);

        public Category GetCategoryById(int id);

        public List<StdCr> GetAllStudentCourses();

        public List<Course> getSortedCoursesUsingLazy(int topic);

        public Instructor GetInstructorByMail(string mail);
        public Student GetStudentByMail(string mail);
        
    

    }
}
