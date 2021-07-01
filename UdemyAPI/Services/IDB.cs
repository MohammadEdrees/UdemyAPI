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

        List<SupCateg> GetSupCategoriesByCateogryId(int id);
        List<SupCateg> GetSupCategsById(int id);


        List<Topic> GetTopicsBySupCategId(int id);

        List<Course> GetCoursesByTopicId(int id);
        
        Instructor AddInstructor(Instructor s);

        Student AddStudent(Student s);
        Course AddCourse(int instId, Course course);


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
         Instructor EditInstructor(Instructor oldIns, Instructor newIns);

        object Login(UserModel user);
        //object Logout(object user);
        IEnumerable<Course> GetAllCoursesInOneCategory(int categId);
        List<Category> GetTop8Categories();  //Get Only 8
        string GetToken();

        Task<string> UploadImage(IFormFile img) ;
        Task<Student> UploadStudentImg(IFormFile stdImg,int id) ;
        Task<Instructor> UploadInstructorImg(IFormFile InsImg,int id) ;
        Task<Course> UploadCourseImg(IFormFile InsImg,int id) ;
        Task<Category> UploadCategoryImg(IFormFile InsImg,int id) ;

        List<Course> GetOrderedCoursesInCategory(int catId);
        List<Course> GetOrderedCoursesInSupCategory(int supcatId);
        List<Topic> GetTopicsInCategory(int catId);
        List<Instructor> GetInstructorsInCategory(int catId);
        IEnumerable<Instructor> GetInstructorsInSubCategory(int subCatId);
        IEnumerable<Instructor> GetInstructorsInTopic(int topId);

        IEnumerable<CourseSection> AddCourseSection(int CrsId, CourseSection courseSection);
        IEnumerable<CourseSection> GetCourseSections(int CrsId);

        Task<IEnumerable<Lecture>> AddLecture(int SecId, Lecture lecture);
        IEnumerable<Lecture> GetCourseLectures(int crsId);

        Task<IEnumerable<Lecture>> UploadLectureVideo(int LectId, string dpPath);
        Task<string> UploadVideo(string dpPath);


        CourseSection GetCourseSection(int SecID);
        Lecture GetLecture(int LecID);

        IEnumerable<Lecture> AllLecturesInSpecificSection(int SecId);
        IEnumerable<CourseSection> AllCourseSectionsInSpecificCourse(int SecId);

        IEnumerable<SupCateg> supCategoriesByName(string catName);

        IEnumerable<Course> SortedCourseForInstById(int instId);

        Lecture GetFirstLectue(int CrsId);
        List<Course> GetStudentCourses(int StdId);
        Course AddCourseEnrollment(int crsId,int stdId);
        IEnumerable<Course> DeleteCourseEnrollment(int crsId, int stdId);
        IEnumerable<CourseSection> DeleteCourseSection(int crsId, int sectionId);
        Task<IEnumerable<Lecture>> DeleteSectionLecture(int crsId, int lectureId);
        int GetStudnetNumbersWithInst(int instId);

        Topic GetTopicByTopicId(int TopicId);

        IEnumerable<Student> DeleteStudent(Student Student);

    }
}
