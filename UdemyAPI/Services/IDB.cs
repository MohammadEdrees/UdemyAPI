using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyAPI.Models;

namespace UdemyAPI.Services
{
    public interface IDB
    {
        //-------------ListsArea-------------

        //1
        List<Category> GetAllCategories();
        //2
        List<Topic> GetAllTopics();
        //3
        List<Course> GetAllCourses();
        //4
        List<Instructor> GetAllInstructors();
        //5
        List<Student> GetAllStudents();
        //6
        List<Admin> GetAllAdmins();

        //---------------Add-----------------
        //7
        Instructor AddInstructor(Instructor s);
        //8
        Student AddStudent(Student s);
        //---GetBy--------------------------
        //9
        public Course GetCourseById(int id);
        //10
        public Course GetCourseByTitle(string title);
        //11
        public Instructor GetInstructorById(int id);
        //12
        public Instructor GetInstructorByName(string name);
        

    }
}
