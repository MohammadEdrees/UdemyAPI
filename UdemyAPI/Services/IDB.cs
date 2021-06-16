using Microsoft.AspNetCore.Http;
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

         Course GetCourseById(int id);
    
         Course GetCourseByTitle(string title);
         List<Category> GetSomeCategoriesByTitle(string title);
         List<SupCateg> GetSomeSupCategsByTitle(string title);
         List<Topic> GetSomeTopicsByTitle(string title);
         List<Instructor> GetSomeInstructorsByTitle(string title);
         List<Course> GetSomeCoursesByTitle(string title);

         Instructor GetInstructorById(int id);
         Instructor GetInstructorByName(string name);
         Category GetCategoryById(int id);
         List<StdCr> GetAllStudentCourses();
         List<Course> getSortedCoursesUsingLazy(int topic);
         Instructor GetInstructorByMail(string mail);
         Student GetStudentByMail(string mail);
         Student GetStudentById(int id);
         void RemoveStudent(Student s);
         Student EditStudent(Student s1,Student s2);

        object Login(UserModel user);
        //object Logout(object user);
        IEnumerable<Course> GetAllCoursesInOneCategory(int categId);
        List<Category> GetTop8Categories();
        string GetToken();

        Task<string> UploadImage(IFormFile img) ;
        Task<Student> UploadStudentImg(IFormFile stdImg,int id) ;
        Task<Instructor> UploadInstructorImg(IFormFile InsImg,int id) ;
        Task<Course> UploadCourseImg(IFormFile InsImg,int id) ;
        Task<Category> UploadCategoryImg(IFormFile InsImg,int id) ;

        public List<Course> GetOrderedCoursesInCategory(int catId);
        public List<Course> GetOrderedCoursesInSupCategory(int supcatId);
        public List<Topic> GetTopicsInCategory(int catId);
        public List<Instructor> GetInstructorsInCategory(int catId);

        CourseSection AddCourseSection(int CrsId, CourseSection courseSection);
        Lecture AddLecture(int SecId, Lecture lecture);
        Task<Lecture> UploadLectureVideo(int LectId, IFormFile Video);
        CourseSection GetCourseSection(int SecID);
        Lecture GetLecture(int LecID);



    }
}
