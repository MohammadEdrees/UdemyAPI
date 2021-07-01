using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UdemyAPI.Models;



namespace UdemyAPI.Services
{
    public class DBService : IDB
    {
        UdemyContext _db;
        private readonly IConfiguration _configuration;
        private static string ApiKey = "AIzaSyD0MQz8q3CFW16JRY11lHctKPSShXxhs7Q";
        private static string Bucket = "udemy-3c633.appspot.com";
        private static string AuthMail = "medoenoch@gmail.com";
        private static string Password = "newstart2020";
        
        public DBService(UdemyContext db,IConfiguration configuration )
        {
            _db = db;
            _configuration = configuration;
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

        public List<SupCateg> GetSupCategoriesByCateogryId(int id)
        {
            return _db.SupCategs.Where(obj => obj.CategoryId == id).ToList();
        }

        public List<SupCateg> GetSupCategsById(int id)
        {
            return _db.SupCategs.Where(obj => obj.SupCatId == id).ToList();
        }


        public Instructor AddInstructor(Instructor s)
        {   
            //s.Password=>Hash
            //s.Password = CommonMethods.ConvertToEncrypt(s.Password);
            _db.Instructors.Add(s);
            _db.SaveChanges();
            return s;
        }

        public  Student AddStudent(Student s)
        {
            //s.Password=>Hash
            //s.Password = CommonMethods.ConvertToEncrypt(s.Password);
            //s.ImagePath = await UploadImage(stdImg);
            _db.Students.Add(s);
            _db.SaveChanges();
            return s;
        }

        public Course AddCourse(int instId,Course course)
        {
            course.InstId = instId;
            course.Instructor = _db.Instructors.FirstOrDefault(obj => obj.InstId == instId);
            _db.Courses.Add(course);
            _db.SaveChanges();
            return course;
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
           //  OldStd.ImagePath = newS.ImagePath;
             OldStd.Phone = newS.Phone;
             OldStd.Card = newS.Card;
             OldStd.StudentCourses = newS.StudentCourses;
             OldStd.Address = newS.Address;
            _db.SaveChanges();
            return OldStd;
        }

        public object Login(UserModel user)
        {
           //user.Password = CommonMethods.ConvertToDecrypt(user.Password);
           Student student =  _db.Students.FirstOrDefault(obj => obj.Mail == user.Mail &&
           obj.Password==user.Password 
                     );
            
            if (student == null)
            {
                Instructor instructor = 
                     _db.Instructors.FirstOrDefault(obj => obj.Mail == user.Mail &&
                obj.Password == user.Password
                    );
                if (instructor == null)
                    return null;
                instructor.Token = GetToken();
                _db.SaveChanges();
                return instructor;
            }
            else
            {
                student.Token = GetToken();
                _db.SaveChanges();
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

            return categories.Take(8).ToList();
        }

        public IEnumerable<Course> GetAllCoursesInOneCategory(int categId)
        {
            
  
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
        //GengerateToken
        public string GetToken()
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: new List<Claim>(),
                expires: DateTime.Now.AddDays(5),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        
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

            CleanServer(fs, img.FileName);

             //  var url = new Uri(str);
            return str;
        }

        public void CleanServer(FileStream fileStream,string path)
        {
            fileStream.Close();
            File.Delete(Path.Combine("Images/" + path));
        }

        public async Task<Student> UploadStudentImg(IFormFile stdImg,int id)
        {
            Student old = GetStudentById(id);
            Student newS = new Student();
            string Imglink = await UploadImage(stdImg);
            old.ImagePath = Imglink;
            newS = old;
            EditStudent(old, newS); 
            return newS;
        }

        public async Task<Instructor> UploadInstructorImg(IFormFile insImg, int id)
        {
            Instructor ins = GetInstructorById(id);
            string Imglink = await UploadImage(insImg);
            ins.ImagPath = Imglink;
            _db.SaveChanges();
            return ins;
        }

        public async Task<Course> UploadCourseImg(IFormFile crsImg, int id)
        {
            Course crs = GetCourseById(id);
            string Imglink = await UploadImage(crsImg);
            crs.ImagePath = Imglink;
            _db.SaveChanges();
            return crs;
        }

        public async Task<Category> UploadCategoryImg(IFormFile CategoryImg, int id)
        {
            Category category = GetCategoryById(id);
            string Imglink = await UploadImage(CategoryImg);
             category.imgPath = Imglink;
            _db.SaveChanges();
            return category;

        }

        //All courses in one category ordered by students count
        public List<Course> GetOrderedCoursesInCategory(int catId)
        {
            return _db.Courses.Where(obj => obj.Top.supCateg.CategoryId == catId).OrderByDescending(obj => obj.studentCourses.Count).ToList();
        }

        //All topics in one category
        public List<Topic> GetTopicsInCategory(int catId)
        {
            return _db.Topics.Where(obj => obj.supCateg.CategoryId == catId).ToList();
        }

        //All courses in one SupCategory ordered by students count
        public List<Course> GetOrderedCoursesInSupCategory(int supcatId)
        {
            return _db.Courses.Where(obj => obj.Top.SupCatId == supcatId).OrderByDescending(obj => obj.studentCourses.Count).ToList();
        }

        //All instructors in one category
        public List<Instructor> GetInstructorsInCategory(int catId)
        {
            IEnumerable<Course> courses = GetAllCoursesInOneCategory(catId);
            List<Instructor> instructors = new List<Instructor>();
            foreach (var item in courses)
            {
                Instructor instructor = _db.Instructors.FirstOrDefault(obj => obj.InstId == item.InstId);
                instructors.Add(instructor);
            }
            return instructors;
        }

        //All instructors in sub category
        public IEnumerable<Instructor> GetInstructorsInSubCategory(int subCatId)
        {
            IEnumerable<Course> courses = _db.Courses.Where(obj => obj.Top.SupCatId == subCatId).ToList();
            List<Instructor> instructors = new List<Instructor>();
            foreach (var item in courses)
            {
                Instructor instructor = _db.Instructors.FirstOrDefault(obj => obj.InstId == item.InstId);
                instructors.Add(instructor);
            }
            return instructors;
        }

        //All instructors by topic
        public IEnumerable<Instructor> GetInstructorsInTopic(int topId)
        {
            IEnumerable<Course> courses = _db.Courses.Where(obj => obj.TopId == topId).ToList();
            List<Instructor> instructors = new List<Instructor>();
            foreach (var item in courses)
            {
                Instructor instructor = _db.Instructors.FirstOrDefault(obj => obj.InstId == item.InstId);
                instructors.Add(instructor);
            }
            return instructors;
        }


        public async Task<IEnumerable<Lecture>> UploadLectureVideo(int LectId, string dpPath)
        {
            Lecture lecture = _db.Lectures.FirstOrDefault(obj => obj.LectureId == LectId);
            string Vidlink = await UploadVideo(dpPath);
            lecture.Title = Path.GetFileNameWithoutExtension(dpPath);
            lecture.Link = Vidlink;
            await _db.SaveChangesAsync();
            return GetCourseLectures(lecture.CourseSection.CrsId);
        }


        public async Task<string> UploadVideo(string dpPath)
        {
            // Firebase Auth
            var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
            var a = await auth.SignInWithEmailAndPasswordAsync(AuthMail, Password);
            var cancellation = new CancellationTokenSource();
            //Stream0
            //await using (var fileStream =  new FileStream(Path.Combine("Images/", vid.FileName), FileMode.Create))
            //{
            //    await vid.CopyToAsync(fileStream);
            //}

            FileStream fs;
            fs = new FileStream(Path.Combine("Images/",dpPath), FileMode.Open);

            // Firebase Upload

            var upload = new FirebaseStorage(Bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken)
                    ,
                    ThrowOnCancel = true
                }).Child("Videos")
                  .Child($"{dpPath}") 
                .PutAsync(fs, cancellation.Token);
            var downloadUrl = await upload;
            string str = downloadUrl;

            CleanServer(fs, dpPath);

            //  var url = new Uri(str);
            return str;
        }



        public IEnumerable<CourseSection> GetCourseSections(int CrsId)
        {
            return _db.CourseSections.Where(obj => obj.CrsId == CrsId).ToList();
        }

        public IEnumerable<CourseSection> AddCourseSection(int CrsId, CourseSection courseSection)
        {
            courseSection.CrsId = CrsId;
            _db.CourseSections.Add(courseSection);
            _db.SaveChanges();
            return GetCourseSections(CrsId);
        }

        public IEnumerable<CourseSection> DeleteCourseSection(int crsId, int sectionId)
        {
            CourseSection courseSection = _db.CourseSections.FirstOrDefault(obj => obj.CrsId == crsId && obj.SectionId == sectionId);
            _db.CourseSections.Remove(courseSection);
            _db.SaveChanges();
            return GetCourseSections(crsId);
        }

        public async Task<IEnumerable<Lecture>> DeleteSectionLecture(int crsId,int lectureId)
        {
            Lecture lecture = _db.Lectures.FirstOrDefault(obj => obj.CourseSection.CrsId == crsId && obj.LectureId == lectureId);
            _db.Lectures.Remove(lecture);
            await _db.SaveChangesAsync();
            return GetCourseLectures(crsId);
        }

        public CourseSection GetCourseSection(int SecID)
        {
            return _db.CourseSections.FirstOrDefault(obj => obj.SectionId == SecID);
        }

        public IEnumerable<Lecture> GetCourseLectures(int crsId)
        {
            return _db.Lectures.Where(obj => obj.CourseSection.CrsId == crsId).ToList();
        }

        public async Task<IEnumerable<Lecture>> AddLecture(int SecId, Lecture lecture)
        {
            
            lecture.SectionId = SecId;
            lecture.CourseSection = _db.CourseSections.FirstOrDefault(obj => obj.SectionId == SecId);
            _db.Lectures.Add(lecture);
            await _db.SaveChangesAsync();
            return GetCourseLectures(lecture.CourseSection.CrsId);
            //return _db.Lectures.Where(obj => obj.CourseSection.CrsId == lecture.CourseSection.CrsId).ToList();
        }



        public Lecture GetLecture(int LecID)
        {
            return _db.Lectures.FirstOrDefault(obj => obj.LectureId == LecID);
        }



        public Instructor EditInstructor(Instructor oldIns, Instructor newIns)
        {
            oldIns.Fname = newIns.Fname;
            oldIns.Lname = newIns.Lname;
            oldIns.Address = newIns.Address;
            oldIns.Biography = newIns.Biography;
            oldIns.Communication = newIns.Communication;
            oldIns.Phone = newIns.Phone;
            oldIns.Password = newIns.Password;
            oldIns.Mail= newIns.Mail;
            oldIns.ImagPath = newIns.ImagPath;
            oldIns.Card = newIns.Card;
            oldIns.CId = newIns.CId;
            oldIns.courses = newIns.courses;
            _db.SaveChanges();
            return oldIns;

        }

        public IEnumerable<Lecture> AllLecturesInSpecificSection(int SecId)
        {
         
           return  _db.Lectures.Where(obj => obj.SectionId == SecId).ToList();   
            
        }

        public IEnumerable<CourseSection> AllCourseSectionsInSpecificCourse(int CourseId)
        {
            return _db.CourseSections.Where(obj => obj.CrsId == CourseId).ToList();
        }

        public IEnumerable<SupCateg> supCategoriesByName(string catName)
        {

            return _db.SupCategs.Where(col => col.Category.CategoryName == catName).ToList();
        }

        public IEnumerable<Course> SortedCourseForInstById(int instId)
        {
           return _db.Courses.
                Where(obj => obj.InstId == instId).
                OrderByDescending(obj => obj.studentCourses.Count).ToList();
        }

        //
        public int GetStudnetNumbersWithInst(int instId)
        {
            int count = 0;
            IEnumerable<Course>  courses= SortedCourseForInstById(instId);
            foreach(Course item in courses)
            {
                count += item.studentCourses.Count; 
            }
            return count;
            
        }

        public Lecture GetFirstLectue(int CrsId)
        {
            return _db.Lectures.FirstOrDefault(obj => obj.CourseSection.CrsId == CrsId);
        }

        public Student GetStudentByID(int stdId)
        {
            return _db.Students.FirstOrDefault(obj => obj.StdId == stdId);
        }

        public List<Course> GetStudentCourses(int StdId)
        {
            List<Course> courses = new List<Course>();
            List<StdCr> stdCrs = _db.StdCrs.Where(obj => obj.StdId == StdId).ToList();
            foreach(StdCr item in stdCrs)
            {
                Course course = _db.Courses.FirstOrDefault( obj => obj.CrsId == item.CrsId);
                courses.Add(course);
            }
            return courses;
        }

        public IEnumerable<Course> DeleteCourseEnrollment(int crsId,int stdId)
        {
             StdCr stdCr = _db.StdCrs.FirstOrDefault(obj => obj.CrsId == crsId && obj.StdId == stdId);
            _db.StdCrs.Remove(stdCr);
            _db.SaveChanges();
            return (GetStudentCourses(stdId));
        }

        public Course AddCourseEnrollment(int crsId, int stdId)
        {
            StdCr newStdCr = new StdCr
                {
                    CrsId = crsId,
                    StdId = stdId
                };
            _db.StdCrs.Add(newStdCr);
            _db.SaveChanges();
            return GetCourseById(crsId);
        }

        public Topic GetTopicByTopicId(int TopicId)
        {
            return _db.Topics.FirstOrDefault(obj => obj.TopId == TopicId);
        }

        public IEnumerable<Student> DeleteStudent(Student Student)
        {
                _db.Students.Remove(Student);
                _db.SaveChanges();
                return _db.Students.ToList();
        }

       
    }
}

