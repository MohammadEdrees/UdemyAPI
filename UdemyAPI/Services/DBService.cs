﻿using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UdemyAPI.Models;



namespace UdemyAPI.Services
{
    public class DBService : IDB
    {
        UdemyContext _db;
        private static string ApiKey = "AIzaSyD0MQz8q3CFW16JRY11lHctKPSShXxhs7Q";
        private static string Bucket = "udemy-3c633.appspot.com";
        private static string AuthMail = "medoenoch@gmail.com";
        private static string Password = "newstart2020";
        
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
        public  Student AddStudent(Student s)
        {
            // s.Password=>Hash
           // s.ImagePath = await UploadImage(stdImg);
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
           //  OldStd.ShoppingCard = newS.ShoppingCard;
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


        public List<Category> GetTop8Categories()
        {
            //get all students in one categoy sorted by count std
           //   _db.Students.Where(obj=>obj.)

            List<Category> categories = new List<Category>();

            List<Course> courses = _db.Courses.OrderByDescending(o => o.studentCourses.Count).ToList();

            IEnumerable<IGrouping<int,Course>> StudentInCourse = courses.AsEnumerable().GroupBy(obj => obj.Top.supCateg.Category.CategoryId);

            foreach(var item in StudentInCourse)
            {
                Category category = _db.Categories.FirstOrDefault(obj => obj.CategoryId == item.Key);
                categories.Add(category);
            }

            return categories;
        }

        public IEnumerable<Course> GetAllCoursesInOneCategory(int categId)
        {
            //-------------------------------------------------
            //
            List<Course> CollectionOfcrss = new List<Course>();
            List<Topic> CollectionOfTopicsinSupCateg = new List<Topic>();
            List  < SupCateg> supCategs =   _db.SupCategs.Where(obj=>obj.CategoryId==categId).ToList();
            foreach (SupCateg item in supCategs)
            {
                List<Topic> topicsInSupCateg =  _db.Topics.Where(obj => obj.SupCatId == item.SupCatId).ToList();
                CollectionOfTopicsinSupCateg.AddRange(topicsInSupCateg);    
            }
            foreach (Topic item in CollectionOfTopicsinSupCateg)
            {
                List<Course> crsz = _db.Courses.Where(obj=>obj.TopId==item.TopId).ToList();
                CollectionOfcrss.AddRange(crsz);
            }   
            return CollectionOfcrss; 
        }

        public object GetToken()
        {
            //string key = "secret_Key";
            //var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            //var Credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
            //var token = new JwtSecurityToken(null,null,null,expires:DateTime.Now.AddDays(2),signingCredentials:Credentials);
            //var Jwt_token = new JwtSecurityTokenHandler().WriteToken(token);

            //return new { data=Jwt_token };
            return null;
        
        }

     
        public async Task<string> UploadImage(IFormFile img)
        {
            // Firebase Auth
            var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
            var a = await auth.SignInWithEmailAndPasswordAsync(AuthMail, Password);
            var cancellation = new CancellationTokenSource();
            //Stream
            using (var fileStream = new FileStream(Path.Combine("Images/", img.FileName), FileMode.Create))
            {
                await img.CopyToAsync(fileStream);
            }
            FileStream fs;
            fs = new FileStream(Path.Combine("Images/" + img.FileName), FileMode.Open);

            // Firebase Upload

            var upload = new FirebaseStorage(Bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken)
                    ,
                    ThrowOnCancel = true
                }).Child("data")
                .Child($"{img.FileName}")
                .PutAsync(fs, cancellation.Token);
                var downloadUrl = await upload;
                string str = downloadUrl;
             //  var url = new Uri(str);
             return str;
        }
    }
}

